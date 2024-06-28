using System.ComponentModel.DataAnnotations;

namespace Blog.Articles
{
    public class UserInfo
    {
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
       public Guid Uuid { get; set; }

        /// <summary>
        /// 关联用户登录表id
        /// </summary>
        public string? Account_Id { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string? User_Image_Src { get; set; }
        /// <summary>
        /// 账号经验（每日登录5积分，签到3积分，发表文章3积分，每日点赞文章1积分上限5，发表评论1积分上限5）
        /// </summary>
        public int? User_Experience { get; set; }
        /// <summary>
        /// 账号邮箱
        /// </summary>
        public int? User_Email { get; set; }
        /// <summary>
        /// 账号年龄
        /// </summary>
        public int? User_Age { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string? User_Phone { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public string? User_Autograph { get; set; }

        /// <summary>
        /// 签到天数
        /// </summary>
        public string? User_Day { get; set; }

        /// <summary>
        /// 创建时间
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
