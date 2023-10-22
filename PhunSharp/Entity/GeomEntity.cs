using PhunSharp.Archive;

namespace PhunSharp.Entity
{
    /// <summary>
    /// 几何实体
    /// </summary>
    public abstract class GeomEntity : BaseEntity, IPosition, ICollide
    {
        /// <summary>
        /// 黏着系数
        /// </summary>
        public string Adhesion { get; set; }
        /// <summary>
        /// 角度
        /// </summary>
        public string Angle { get; set; }
        /// <summary>
        /// 引力大小
        /// </summary>
        public string Attraction { get; set; }
        /// <summary>
        /// 引力类型
        /// </summary>
        public string AttractionType { get; set; }
        /// <summary>
        /// 是否绘制边框
        /// </summary>
        public string DrawBorder { get; set; }
        /// <summary>
        /// 是否边缘虚化
        /// </summary>
        public string EdgeBlur { get; set; }
        /// <summary>
        /// 摩擦系数
        /// </summary>
        public string Friction { get; set; }
        /// <summary>
        /// 是否被粘附
        /// </summary>
        public string Glued { get; set; }
        /// <summary>
        /// 是否无自身碰撞
        /// </summary>
        public string HeteroCollide { get; set; }
        /// <summary>
        /// 是否不灭
        /// </summary>
        public string Immortal { get; set; }
        /// <summary>
        /// 是否为杀手
        /// </summary>
        public string Killer { get; set; }
        /// <summary>
        /// 材质速度
        /// </summary>
        public string MaterialVelocity { get; set; }
        /// <summary>
        /// 材质名
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 被激光击打后执行的代码
        /// </summary>
        public string OnHitByLaser { get; set; }
        /// <summary>
        /// 表面光线反射率
        /// </summary>
        public string ReflectiveNess { get; set; }
        /// <summary>
        /// 透明体折光率
        /// </summary>
        public string RefractiveIndex { get; set; }
        /// <summary>
        /// 弹性系数
        /// </summary>
        public string Restitution { get; set; }
        /// <summary>
        /// 贴图
        /// </summary>
        public string Texture { get; set; }
        /// <summary>
        /// 贴图的轴向固定情况
        /// </summary>
        public string TextureClamped { get; set; }
        /// <summary>
        /// 贴图变换矩阵
        /// </summary>
        public string TextureMatrix { get; set; }
        /// <summary>
        /// 速度阻尼
        /// </summary>
        public string VelocityDamping { get; set; }
        public string Pos { get; set; }
        public string CollideSet { get; set; }
        public string CollideWater { get; set; }
        /// <summary>
        /// 碰撞时执行的代码
        /// </summary>
        public string OnCollide { get; set; }

    }
}
