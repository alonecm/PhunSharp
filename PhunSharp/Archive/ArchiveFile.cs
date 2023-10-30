using Dex.Common;
using PhunSharp.ArchiveSyntax;
using System.Collections.Generic;

namespace PhunSharp.Archive
{
    /// <summary>
    /// Phn文件
    /// </summary>
    public sealed class ArchiveFile
    {
        /// <summary>
        /// 存档设置
        /// </summary>
        public Dictionary<string, ParseSetting> Settings { get; internal set; }
        /// <summary>
        /// 存档对象
        /// </summary>
        public Container<ParseObject> Objects { get; internal set; }
        /// <summary>
        /// 存档设定项
        /// </summary>
        public Container<ParseSet> Sets { get; internal set; }
        /// <summary>
        /// 全局变量
        /// </summary>
        public ParseVariables Variables { get; internal set; }
        /// <summary>
        /// 存档变量
        /// </summary>
        public ParseSceneMyVars SceneVariables { get; internal set; }
    }
}
