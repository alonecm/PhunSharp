using Dex.Interfaces;

namespace PhunSharp.Archive
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class BaseEntity : IIDentity
    {
        public string ID { get; set; }
    }
}
