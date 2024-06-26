using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ModelEFCore.Model
{
    public class Article
    {
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
        [Key]
        [Comment("用户唯一标识符")]
        public string? Uuid { get; set; }

        /// <summary>
        /// 关联用户id
        /// </summary>
        [Comment("关联用户id")]
        public string? Account_Id { get; set; }
        /// <summary>
        /// 文章图片
        /// </summary>
        [Comment("文章图片")]
        public string? Article_Image_Src { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        [Comment("文章标题")]
        public string? Article_Title { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        [Comment("文章内容")]
        public string? Article_Content { get; set; }

        /// <summary>
        /// 文章类型
        /// </summary>
        [Comment("文章类型")]
        public string? Article_Type { get; set; }

        /// <summary>
        /// 文章点赞量
        /// </summary>
        [Comment("文章点赞量")]
        public string? Article_Good { get; set; }

        /// <summary>
        /// 此次更改时间
        /// </summary>
        [Comment("此次更改时间")]
        public DateTime? Last_UpdateTime { get; set; }

        /// <summary>
        /// 文章创建时间
        /// </summary>
        [Comment("文章创建时间")]
        public DateTime? Create_Time { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Comment("删除时间")]
        public DateTime? Delete_Time { get; set; }

        /// <summary>
        /// 是否有效（0:有效 1:可正常登录）
        /// </summary>
        [Comment("是否有效（0:有效 1:可正常登录）")]
        public bool Is_Deleted { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [Comment("备注信息")]
        public string? Remark { get; set; }
    }
}
