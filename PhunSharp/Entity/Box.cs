namespace PhunSharp.Entity
{
    /// <summary>
    /// 矩形
    /// </summary>
    public sealed class Box : GeomEntity, IGeomExtra
    {
        public string ControllerAcc { get; set; }
        public string ControllerInvertX { get; set; }
        public string ControllerInvertY { get; set; }
        public string ControllerReverseXY { get; set; }
        public string Density { get; set; }
        public string Vel { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public string Size { get; set; }
        public string AngVel { get; set; }
        public string InertiaMultiplier { get; set; }
        public string AirFrictionMult { get; set; }
        public string ShowForceArrows { get; set; }
        public string ShowMomentum { get; set; }
        public string ShowVelocity { get; set; }
        /// <summary>
        /// 是否作为直尺
        /// </summary>
        public string Ruler { get; set; }
        /// <summary>
        /// 文字
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 文字颜色
        /// </summary>
        public string TextColor { get; set; }
        /// <summary>
        /// 文字大小自适应
        /// </summary>
        public string TextConstrained { get; set; }
        /// <summary>
        /// 文字字体
        /// </summary>
        public string TextFont { get; set; }
        /// <summary>
        /// 文字字体解析度
        /// </summary>
        public string TextFontSize { get; set; }
        /// <summary>
        /// 文字尺寸
        /// </summary>
        public string TextScale { get; set; }

    }
}
