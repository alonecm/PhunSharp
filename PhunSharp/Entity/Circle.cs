namespace PhunSharp.Entity
{
    /// <summary>
    /// 圆形
    /// </summary>
    public sealed class Circle : GeomEntity, IGeomExtra
    {
        public string ControllerAcc { get; set; }
        public string ControllerInvertX { get; set; }
        public string ControllerInvertY { get; set; }
        public string ControllerReverseXY { get; set; }
        public string Density { get; set; }
        public string Vel { get; set; }
        public string AngVel { get; set; }
        public string InertiaMultiplier { get; set; }
        public string AirFrictionMult { get; set; }
        /// <summary>
        /// 是否绘制扇形标志
        /// </summary>
        public string DrawCake { get; set; }
        /// <summary>
        /// 半径
        /// </summary>
        public string Radius { get; set; }
        public string ShowForceArrows { get; set; }
        public string ShowMomentum { get; set; }
        public string ShowVelocity { get; set; }
        /// <summary>
        /// 是否作为量角器
        /// </summary>
        public string Protractor { get; set; }
    }
}
