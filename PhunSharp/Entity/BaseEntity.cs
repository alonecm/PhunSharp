using Dex.Interfaces;

namespace PhunSharp.Entity
{

    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class BaseEntity : IIDentity
    {
        /// <summary>
        /// 实体ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 点击时执行的代码
        /// </summary>
        public string OnClick { get; set; }
        /// <summary>
        /// 销毁时执行的代码
        /// </summary>
        public string OnDie { get; set; }
        /// <summary>
        /// 按键时执行的代码
        /// </summary>
        public string OnKey { get; set; }
        /// <summary>
        /// 生成时执行的代码
        /// </summary>
        public string OnSpawn { get; set; }
        /// <summary>
        /// 运行场景后执行的代码
        /// </summary>
        public string PostStep { get; set; }
        /// <summary>
        /// 软件启动后运行的代码
        /// </summary>
        public string Update { get; set; }
        /// <summary>
        /// Z方向深度值
        /// </summary>
        public string ZDepth { get; set; }
        /// <summary>
        /// 存在时间
        /// </summary>
        public string Timetolive { get; set; }
        /// <summary>
        /// 资源
        /// </summary>
        public string Resources { get; set; }
        /// <summary>
        /// HSVA颜色
        /// </summary>
        public string ColorHSVA { get; set; }
        /// <summary>
        /// ARGB颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 边框是否不透明
        /// </summary>
        public string OpaqueBorders { get; set; }
    }
}
