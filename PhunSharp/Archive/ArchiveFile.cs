using System.Collections.Generic;

namespace PhunSharp.Archive
{
    /// <summary>
    /// Phn文件
    /// </summary>
    public sealed class ArchiveFile
    {
        public ArchiveFile()
        {
            Settings = new Dictionary<string, ArchiveSetting>();
            Entities = new Dictionary<int, BaseEntity>();
            Info = new ArchiveInfo();
        }

        /// <summary>
        /// 存档信息
        /// </summary>
        public ArchiveInfo Info { get; }

        /// <summary>
        /// 存档设定
        /// </summary>
        public Dictionary<string, ArchiveSetting> Settings { get; }

        /// <summary>
        /// 存档中包含的场景对象集合
        /// </summary>
        public Dictionary<int, BaseEntity> Entities { get; }
    }
}
