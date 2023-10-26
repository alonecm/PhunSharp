using Dex.Analysis.Parser;
using Dex.Common;
using PhunSharp.Archive;
using PhunSharp.ArchiveSyntax;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace PhunSharp.ArchiveSyntax
{
    /// <summary>
    /// 单例模式档案解析器
    /// </summary>
    public sealed partial class ArchiveAnalyzer
    {
        private static ArchiveAnalyzer instance;
        private static readonly object lockObject = new object();

        /// <summary>
        /// 获取<see cref="ArchiveAnalyzer"/>实例
        /// </summary>
        public static ArchiveAnalyzer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance = new ArchiveAnalyzer();
                    }
                }
                return instance;
            }
        }

        private ArchiveAnalyzer()
        {
        }
        
        /// <summary>
        /// 转换存档内容
        /// </summary>
        /// <param name="archiveContent"></param>
        /// <returns></returns>
        public ArchiveFile Transform(string archiveContent)
        {
            ParseVariables vars = null;
            var st = new Dictionary<string, ParseSetting>();
            var s = new Container<ParseSet>();
            var o = new Container<ParseObject>();
            //记录
            var phn = new ArchiveParser(archiveContent).Parse();
            foreach (var item in phn.Objs)
            {
                switch (item)
                {
                    case ParseVariables pv:
                        vars = pv;
                        break;
                    case ParseSetting pst:
                        st.Add(pst.SettingTarget, pst);
                        break;
                    case ParseObject po:
                        o.Add(po);
                        break;
                    case ParseSet ps:
                        s.Add(ps);
                        break;
                    default:
                        break;
                }
            }
            return new ArchiveFile() { Variables = vars, Settings = st, Sets = s, Objects = o };
        }
    }
}
