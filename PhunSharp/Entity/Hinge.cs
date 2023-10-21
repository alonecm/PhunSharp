namespace PhunSharp.Entity
{
    public sealed class Hinge : BaseEntity, ISize
    {
        public string Size { get; set; }
        /// <summary>
        /// 是否允许直接求解
        /// </summary>
        public string AllowDirectSolve { get; set; }
        /// <summary>
        /// 是否允许自动折弯
        /// </summary>
        public string AutoBend { get; set; }
        /// <summary>
        /// 是否自动刹闸
        /// </summary>
        public string AutoBrake { get; set; }
        /// <summary>
        /// 是否折弯
        /// </summary>
        public string Bend { get; set; }
        /// <summary>
        /// 折弯常数
        /// </summary>
        public string BendConstant { get; set; }
        /// <summary>
        /// 折弯目标
        /// </summary>
        public string BendTarget { get; set; }
        /// <summary>
        /// 轴承是否反转
        /// </summary>
        public string Ccw { get; set; }
        /// <summary>
        /// 轴承偏离轴心距离限值
        /// </summary>
        public string DistanceLimit { get; set; }
        /// <summary>
        /// 是否强行直接求解
        /// </summary>
        public string ForceDirectSolve { get; set; }
        /// <summary>
        /// 铰链常数
        /// </summary>
        public string HingeConstant { get; set; }
        /// <summary>
        /// 冲击破坏力上限
        /// </summary>
        public string ImpulseLimit { get; set; }
        /// <summary>
        /// 传统模式
        /// </summary>
        public string LegacyMode { get; set; }
        /// <summary>
        /// 马达
        /// </summary>
        public string Motor { get; set; }
        /// <summary>
        /// 马达速度
        /// </summary>
        public string MotorSpeed { get; set; }
        /// <summary>
        /// 马达扭矩
        /// </summary>
        public string MotorTorque { get; set; }
    }
}
