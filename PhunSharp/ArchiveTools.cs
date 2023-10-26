using PhunSharp.Archive;
using PhunSharp.ArchiveSyntax;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhunSharp
{

    /// <summary>
    /// 存档工具
    /// </summary>
    public sealed class ArchiveTools
    {
        /// <summary>
        /// 解压指定路径下多个phz文件
        /// </summary>
        /// <param name="phzPath">指定的phz文件地址集合</param>
        /// <returns>phz文件解压后得到的Phun包集合</returns>
        public static ArchiveZip[] DeCompress(params string[] phzPath)
        {
            List<ArchiveZip> packages = new List<ArchiveZip>();
            foreach (var path in phzPath)
            {
                packages.Add(DeCompress(path));
            }
            return packages.ToArray();
        }

        /// <summary>
        /// 解压指定路径下单个phz文件
        /// </summary>
        /// <param name="phzPath">指定的phz文件</param>
        /// <returns>phz文件解压后得到的Phun包</returns>
        public static ArchiveZip DeCompress(string phzPath)
        {
            //初始化存档文件
            ArchiveZip zip = new ArchiveZip();
            //加载文件
            using (FileStream fs = new FileStream(phzPath, FileMode.Open))
            {
                //解压文件
                using (ZipArchive phz = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    //赋值操作
                    foreach (var item in phz.Entries)//这块直接就读取文件无视内部文件夹
                    {
                        //启动解包流
                        using (DeflateStream tfs = (DeflateStream)item.Open())
                        {
                            //从流中解包
                            switch (item.Name)
                            {
                                case "thumb.png"://缩略图
                                    zip.Thumb = new Bitmap(tfs);
                                    break;

                                case "scene.phn"://场景信息
                                    StringBuilder sbs = new StringBuilder();
                                    byte[] buffers = new byte[item.Length];
                                    while (true)
                                    {
                                        if (tfs.Read(buffers, 0, buffers.Length) == 0)
                                            break;
                                        else
                                            sbs.Append(Encoding.UTF8.GetString(buffers));
                                    }
                                    zip.Phn = AnalyzeScene(sbs.ToString());//分析并生成场景信息集
                                    break;

                                case "checksums.txt"://检查码
                                    using (StreamReader sr = new StreamReader(tfs))
                                    {
                                        //逐行读取
                                        while (true)
                                        {
                                            string s = sr.ReadLine();
                                            if (s == null)
                                                break;
                                            else
                                                zip.CheckNums.Add(s.Substring(0, s.LastIndexOf(' ')), s.Substring(s.LastIndexOf(' ') + 1));
                                        }
                                    }
                                    break;

                                default://贴图文件
                                    zip.Textures.Add(item.Name, new Bitmap(tfs));
                                    break;
                            }
                        }
                    }
                }
                return zip;
            }
        }

        /// <summary>
        /// 压缩指定的Phun包
        /// </summary>
        /// <param name="package">指定的phun包</param>
        /// <param name="path">指定的存放路径</param>
        public static void Compress(ArchiveZip package, string path)
        {
            //创建临时文件夹
            DirectoryInfo dirTemp = Directory.CreateDirectory(Path.GetDirectoryName(path) + "\\" + "Temp");
            //创建缩略图
            using (FileStream fs = new FileStream(dirTemp.FullName + "\\thumb.png", FileMode.Create))
            {
                byte[] image = BitmapToByteArray(new Bitmap(package.Thumb));
                fs.Write(image, 0, image.Length);
            }
            //创建材质包
            foreach (var item in package.Textures)
            {
                //创建材质临时文件夹
                DirectoryInfo textureDirTemp = Directory.CreateDirectory(Path.GetDirectoryName(path) + "\\Temp\\texture");
                using (FileStream fs = new FileStream(dirTemp.FullName + $"\\texture\\{item.Key}", FileMode.Create))
                {
                    byte[] image = BitmapToByteArray(new Bitmap(item.Value));
                    fs.Write(image, 0, image.Length);
                }
            }
            //创建存档文件(这里需要修一修)
            using (FileStream fs = new FileStream(dirTemp.FullName + "\\scene.phn", FileMode.Create))
            {
                //将设置信息罗列出来，之前怎么弄得就怎么弄回去，将对象信息加上去
                StringBuilder sb = new StringBuilder("// FileVersion PH_10\n// Algodoo scene created by PhunSharp v1.0 \n\n");
                //字符串化设置
                sb.Append(package.Phn.Variables);
                foreach (var item in package.Phn.Settings.Values)
                {
                    sb.AppendLine(item.ToString());
                }
                foreach (var item in package.Phn.Objects)
                {
                    sb.AppendLine(item.ToString());
                }
                byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }
            //创建checkNum文件
            using (FileStream fs = new FileStream(dirTemp.FullName + "\\checksums.txt", FileMode.Create))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in package.CheckNums)
                {
                    sb.AppendLine($"{item.Key} {item.Value}");
                }
                byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
                fs.Write(bytes, 0, bytes.Length);
            }
            //如果之前的文件存在则删除
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            //创建文件
            ZipFile.CreateFromDirectory(dirTemp.FullName, path, CompressionLevel.Fastest, false);
            //删除临时文件夹
            dirTemp.Delete(true);
        }

        /// <summary>
        /// 解析scene.phn文件成Phun存档
        /// </summary>
        /// <param name="sceneThyme">scene.phn 文件内容</param>
        /// <returns>Phun存档</returns>
        private static ArchiveFile AnalyzeScene(string sceneThyme)
        {
            return ArchiveAnalyzer.GetInstance.Transform(sceneThyme);
        }

        /// <summary>
        /// Bitmap转换为字节数组
        /// </summary>
        /// <param name="bitmap">指定bitmap</param>
        /// <returns>bitmap的字节数组</returns>
        private static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            byte[] bytes;
            //创建内存流
            using (MemoryStream ms = new MemoryStream())
            {
                //将bitmap导入到流中
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //重置流起始点
                ms.Seek(0, SeekOrigin.Begin);
                //创建字节数组并导入
                bytes = new byte[ms.Length];
                ms.Read(bytes, 0, bytes.Length);
            }
            return bytes;
        }
    }
}
