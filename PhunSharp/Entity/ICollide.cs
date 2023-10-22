namespace PhunSharp.Entity
{
    /// <summary>
    /// 提供参与碰撞的属性
    /// </summary>
    public interface ICollide
    {
        /// <summary>
        /// 碰撞层设定
        /// </summary>
        string CollideSet { get; set; }
        /// <summary>
        /// 是否与水碰撞
        /// </summary>
        string CollideWater { get; set; }
    }
}
