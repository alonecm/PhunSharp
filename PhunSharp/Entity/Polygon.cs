namespace PhunSharp.Entity
{
    /// <summary>
    /// 多边形
    /// </summary>
    public sealed class Polygon : GeomEntity, IGeomExtra
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
        public string ShowForceArrows { get; set; }
        public string ShowMomentum { get; set; }
        public string ShowVelocity { get; set; }
        /// <summary>
        /// 是否强行绘制多边形顶点
        /// </summary>
        public string ForceVertexDrawing { get; set; }
    }
}
