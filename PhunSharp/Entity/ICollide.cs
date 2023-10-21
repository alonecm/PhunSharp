namespace PhunSharp.Entity
{
    /// <summary>
    /// 提供参与碰撞的属性
    /// </summary>
    public interface ICollide
    {
        string CollideSet { get; set; }
        string CollideWater { get; set; }
    }
}
