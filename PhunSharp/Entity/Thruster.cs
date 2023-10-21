namespace PhunSharp.Entity
{
    public sealed class Thruster : BaseEntity, IPosition, ISize
    {
        public string Size { get; set; }
        public string Pos { get; set; }
        /// <summary>
        /// 是否跟随几何体旋转
        /// </summary>
        public string FollowGeometry { get; set; }
        /// <summary>
        /// 推力大小
        /// </summary>
        public string Force { get; set; }
        /// <summary>
        /// 旋转过的弧度数
        /// </summary>
        public string Rotation { get; set; }
    }
}
