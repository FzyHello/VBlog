using System.ComponentModel.DataAnnotations;

namespace ModelEFCore
{
    public class Article
    {
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
        [Key]
        public string? Uuid { get; set; }

        /// <summary>
        /// 关联用户id
        /// </summary>
        public string? Account_Id { get; set; }
        /// <summary>
        /// 文章图片
        /// </summary>
        public string? Article_Image_Src { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string? Article_Title { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string? Article_Content { get; set; }

        /// <summary>
        /// 文章类型
        /// </summary>
        public string? Article_Type { get; set; }

        /// <summary>
        /// 文章点赞量
        /// </summary>
        public string? Article_Good { get; set; }

        /// <summary>
        /// 此次更改时间
        /// </summary>
        public DateTime? Last_UpdateTime { get; set; }

        /// <summary>
        /// 文章创建时间
        /// </summary>
        public DateTime? Create_Time { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? Delete_Time { get; set; }

        /// <summary>
        /// 是否有效（0:有效 1:可正常登录）
        /// </summary>
        public bool Is_Deleted { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string? Remark { get; set; }
    }
}
