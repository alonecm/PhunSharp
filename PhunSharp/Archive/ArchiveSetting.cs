using System.Collections.Generic;

namespace PhunSharp.Archive
{
    /// <summary>
    /// 存档设定
    /// </summary>
    public sealed class ArchiveSetting
    {
        public ArchiveSetting(string groupName)
        {
            Items = new Dictionary<string, object>();
            GroupName = groupName;
        }
        /// <summary>
        /// 组名
        /// </summary>
        public string GroupName { get; }
        /// <summary>
        /// 设置项目
        /// </summary>
        public Dictionary<string, object> Items { get; }
    }
}
