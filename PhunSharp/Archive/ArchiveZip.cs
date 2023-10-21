using System.Collections.Generic;
using System.Drawing;

namespace PhunSharp.Archive
{
    /// <summary>
    /// 存档压缩包
    /// </summary>
    public sealed class ArchiveZip
    {
        public ArchiveZip()
        {
            Phn = new ArchiveFile();
            CheckNums = new Dictionary<string, string>();
            Textures = new Dictionary<string, Image>();
        }

        /// <summary>
        /// 存档文件
        /// </summary>
        public ArchiveFile Phn { get; set; }

        /// <summary>
        /// 存档缩略图
        /// </summary>
        public Image Thumb { get; set; }

        /// <summary>
        /// 存档检查码
        /// </summary>
        public Dictionary<string, string> CheckNums { get; }

        /// <summary>
        /// 存档所用贴图
        /// </summary>
        public Dictionary<string, Image> Textures { get; }
    }
}
