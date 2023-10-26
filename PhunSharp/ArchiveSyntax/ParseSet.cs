using Dex.Analysis.Parser;
using Dex.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhunSharp.ArchiveSyntax
{
    /// <summary>
    /// 解析设定项
    /// </summary>
    public sealed class ParseSet : ExtendableObject
    {
        public ParseSet(string setItem, string content) :
            base(new CharStream(content.Remove(0, 1).Remove(content.Length - 2, 1)).AnalyzeContent())
        {
            SetItem = setItem;
        }
        public string SetItem { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Scene.set{SetItem} ");
            sb.Append("{\n");
            var ps = this.GetProperties();
            foreach (var item in ps)
            {
                sb.AppendLine($"    {item.Key}:={item.Value};");
            }
            sb.Append("};");
            return sb.ToString();
        }
    }
}
