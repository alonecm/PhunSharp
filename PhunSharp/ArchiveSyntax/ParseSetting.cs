using Dex.Analysis.Parser;
using Dex.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhunSharp.ArchiveSyntax
{
    /// <summary>
    /// 解析设置
    /// </summary>
    public sealed class ParseSetting : ExtendableObject
    {
        public ParseSetting(string settingTarget, string content) :
            base(new CharStream(content.Remove(0, 1).Remove(content.Length - 2, 1)).AnalyzeContent())

        {
            SettingTarget = settingTarget;
            
        }
        public string SettingTarget { get; }

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder($"{SettingTarget} -> ");
            sb.Append("{\n");
            var ps = this.GetProperties();
            foreach (var item in ps)
            {
                sb.AppendLine($"    {item.Key} = {item.Value};");
            }
            sb.Append("};");
            return sb.ToString();
        }
    }
}
