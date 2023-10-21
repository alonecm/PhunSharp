namespace PhunSharp.Entity
{
    /// <summary>
    /// 创建实体的额外部分
    /// </summary>
    public interface IGeomExtra
    {
        /// <summary>
        /// 惯性系数
        /// </summary>
        string InertiaMultiplier { get; set; }
        /// <summary>
        /// 空气摩擦力系数
        /// </summary>
        string AirFrictionMult { get; set; }
        /// <summary>
        /// 控制器加速度
        /// </summary>
        string ControllerAcc { get; set; }
        /// <summary>
        /// 是否反转X轴操作
        /// </summary>
        string ControllerInvertX { get; set; }
        /// <summary>
        /// 是否反转Y轴操作
        /// </summary>
        string ControllerInvertY { get; set; }
        /// <summary>
        /// 是否反转X轴与Y轴操作
        /// </summary>
        string ControllerReverseXY { get; set; }
        /// <summary>
        /// 密度
        /// </summary>
        string Density { get; set; }
        /// <summary>
        /// 瞬时速度
        /// </summary>
        string Vel { get; set; }
        /// <summary>
        /// 角速度
        /// </summary>
        string AngVel { get; set; }
        /// <summary>
        /// 绘制受力箭头
        /// </summary>
        string ShowForceArrows { get; set; }
        /// <summary>
        /// 绘制动量箭头
        /// </summary>
        string ShowMomentum { get; set; }
        /// <summary>
        /// 绘制速度箭头
        /// </summary>
        string ShowVelocity { get; set; }
    }
}
