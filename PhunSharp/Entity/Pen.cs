namespace PhunSharp.Entity
{
    public sealed class Pen : BaseEntity, IPosition, ISize, IRotation
    {
        public string Size { get; set; }
        public string Pos { get; set; }
        /// <summary>
        /// 渐变消失时间
        /// </summary>
        public string FadeTime { get; set; }
        /// <summary>
        /// 旋转过的弧度数
        /// </summary>
        public string Rotation { get; set; }
    }
}
