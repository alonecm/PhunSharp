using Dex.IO;
using PhunSharp;
using PhunSharp.ArchiveSyntax;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //解包
            var c =  ArchiveTools.DeCompress(@"C:\Users\ASUS\Documents\Algodoo\scenes\downloads\95463_3D_World.phz");
            //打包
            ArchiveTools.Compress(c, @"E:\临时文件\test.phz");
            Console.WriteLine("导出完毕");
            Console.ReadKey();
        }
    }
}
