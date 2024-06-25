using System.ComponentModel.DataAnnotations;

namespace ModelEFCore
{
    public class Account
    {
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
        [Key]
        public string? Uuid { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string? User_Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// 角色权限（0-管理员 1：普通用户）
        /// </summary>
        public int Role { get; set; }

        /// <summary>
        /// 最近一次登录时间
        /// </summary>
        public DateTime? Last_LoginTime { get; set; }

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
