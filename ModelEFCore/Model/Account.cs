using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ModelEFCore.Model
{
    public class Account
    {
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
        [Key]
        [Comment("用户唯一标识符")]
        public string? Uuid { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        [Comment("登录账号")]
        public string? Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Comment("用户名")]
        public string? User_Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Comment("用户密码")]
        public string? Password { get; set; }

        /// <summary>
        /// 角色权限（0-管理员 1：普通用户）
        /// </summary>
        [Comment("角色权限（0-管理员 1：普通用户）")]
        public int Role { get; set; }

        /// <summary>
        /// 最近一次登录时间
        /// </summary>
        [Comment("最近一次登录时间")]
        public DateTime? Last_LoginTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Comment("创建时间")]
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
