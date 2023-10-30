using Dex.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhunSharp.ArchiveSyntax
{
    public sealed class ParseSceneMyVars : ExtendableObject
    {
        public ParseSceneMyVars(Dictionary<string, object> vars) : base(vars)
        {
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var dic = this.GetProperties();
            foreach (var item in dic)
            {
                sb.AppendLine($"{item.Key} := {item.Value};");
            }
            return sb.ToString();
        }
    }
}
