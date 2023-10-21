namespace PhunSharp.Entity
{
    public sealed class Laser : BaseEntity, IPosition, ISize, ICollide
    {
        public string Size { get; set; }
        public string Pos { get; set; }
        public string CollideSet { get; set; }
        public string CollideWater { get; set; }
        /// <summary>
        /// 是否作为切割器
        /// </summary>
        public string Cutter { get; set; }
        /// <summary>
        /// 渐变距离
        /// </summary>
        public string FadeDist { get; set; }
        /// <summary>
        /// 是否跟随几何体旋转
        /// </summary>
        public string FollowGeometry { get; set; }
        /// <summary>
        /// 是否使用传统模式
        /// </summary>
        public string LegacyMode { get; set; }
        /// <summary>
        /// 最大切割距离乘数
        /// </summary>
        public string MaxCuts { get; set; }
        /// <summary>
        /// 最大光路距离乘数
        /// </summary>
        public string MaxRays { get; set; }
        /// <summary>
        /// 当激光照射到物体上时执行的代码
        /// </summary>
        public string OnLaserHit { get; set; }
        /// <summary>
        /// 旋转过的弧度数
        /// </summary>
        public string Rotation { get; set; }
        /// <summary>
        /// 是否显示激光笔自身
        /// </summary>
        public string ShowLaserBodyAttrib { get; set; }
        /// <summary>
        /// 光速
        /// </summary>
        public string Velocity { get; set; }
    }
}
