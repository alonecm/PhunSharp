using Dex.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhunSharp.ArchiveSyntax
{
    /// <summary>
    /// 全局变量集
    /// </summary>
    public sealed class ParseVariables : ExtendableObject
    {
        public ParseVariables(Dictionary<string, object> vars) : base (vars)
        {
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var ps = this.GetProperties();
            foreach (var item in ps)
            {
                sb.AppendLine($"{item.Key} := {item.Value};");
            }
            return sb.ToString();
        }
    }
}
