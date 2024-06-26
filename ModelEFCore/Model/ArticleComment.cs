using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace ModelEFCore.Model
{
    public class ArticleComment
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
        /// 关联文章id
        /// </summary>
        [Comment("关联文章id")]
        public string? Article_Id { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [Comment("评论内容")]
        public string? Comment_Text { get; set; }

        /// <summary>
        /// 评论点赞量
        /// </summary>
        [Comment("评论点赞量")]
        public int? Comment_Good { get; set; }

        /// <summary>
        /// 评论创建时间
        /// </summary>
        [Comment("评论创建时间")]
        public DateTime? Create_Time { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Comment("删除时间")]
        public DateTime? Delete_Time { get; set; }

        /// <summary>
        /// 是否有效（0:有效 1:已删除）
        /// </summary>
        [Comment("是否有效（0:有效 1:已删除）")]
        public bool Is_Deleted { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [Comment("备注信息")]
        public string? Remark { get; set; }
    }
}
