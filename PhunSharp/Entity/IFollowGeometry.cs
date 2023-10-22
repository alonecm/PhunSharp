namespace PhunSharp.Entity
{
    /// <summary>
    /// 提供跟随几何体变换的属性
    /// </summary>
    public interface IFollowGeometry
    {   
        /// <summary>
        /// 是否跟随几何体旋转
        /// </summary>
        string FollowGeometry { get; set; }
    }
}
