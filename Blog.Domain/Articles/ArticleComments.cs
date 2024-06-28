using System.ComponentModel.DataAnnotations;


namespace Blog.Articles
{
    public class ArticleComments
    {
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
        public Guid Uuid { get; set; }

        /// <summary>
        /// 关联用户id
        /// </summary>
        public string? Account_Id { get; set; }

        /// <summary>
        /// 关联文章id
        /// </summary>
        public string? Article_Id { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string? Comment_Text { get; set; }

        /// <summary>
        /// 评论点赞量
        /// </summary>
        public int? Comment_Good { get; set; }

        /// <summary>
        /// 评论创建时间
        /// </summary>
        public DateTime? Create_Time { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? Delete_Time { get; set; }

        /// <summary>
        /// 是否有效（0:有效 1:已删除）
        /// </summary>
        public bool Is_Deleted { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string? Remark { get; set; }
    }
}
