using Dex.Analysis.Parser;
using Dex.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhunSharp.ArchiveSyntax
{
    /// <summary>
    /// 解析对象
    /// </summary>
    public sealed class ParseObject : ExtendableObject
    {
        public ParseObject(string objectType, string content) :
            base(new CharStream(content.Remove(0, 1).Remove(content.Length - 2, 1)).AnalyzeContent())
        {
            ObjectType = objectType;
        }
        public string ObjectType { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Scene.add{ObjectType} ");
            sb.Append("{\n");
            var ps = this.GetProperties();
            foreach (var item in ps)
            {
                sb.AppendLine($"    {item.Key} := {item.Value};");
            }
            sb.Append("};");
            return sb.ToString();
        }
    }
}
