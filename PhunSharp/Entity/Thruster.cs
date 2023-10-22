namespace PhunSharp.Entity
{
    public sealed class Thruster : BaseEntity, IPosition, ISize, IFollowGeometry, IRotation
    {
        public string Size { get; set; }
        public string Pos { get; set; }
        public string FollowGeometry { get; set; }
        /// <summary>
        /// 推力大小
        /// </summary>
        public string Force { get; set; }
        public string Rotation { get; set; }
    }
}
