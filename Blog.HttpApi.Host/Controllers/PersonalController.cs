using BlogHelper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using ModelEFCore;
using ModelEFCore.Model;

namespace WebBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalController : ControllerBase
    {
        private readonly MyDbContext dbCtx;
        private readonly GenerateToken _tokenGenerator;
        private readonly ILogger<LoginController> _logger;
        private readonly IDistributedCache _cache;

        public PersonalController(MyDbContext dbCtx, GenerateToken tokenGenerator, IDistributedCache cache)
        {
            this.dbCtx = dbCtx;
            _tokenGenerator = tokenGenerator;
            _cache = cache;
        }

        # region 获取个人信息
        [HttpPost]
        public ActionResult<UserInfo> ObtainPersonal([FromBody] Account account)
        {
            //写一个判断保证账户密码不为空
            if (string.IsNullOrEmpty(account.User_Name) || string.IsNullOrEmpty(account.Password))
            {
                return BadRequest("用户名和密码不能为空");
            }

            var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == account.User_Name && a.Password == account.Password);

            // 检查查询结果是否为空或者等于0，如果为空或者等于0则返回错误信息，否则返回成功信息
            if (result != null )
            {
                try
                {
                    var personalResult = dbCtx.UserInfos.FirstOrDefault(a => a.Account_Id == result.Uuid);
                    return Ok(personalResult);
                }
                catch (Exception ex)
                {
                    // 捕获并处理异常
                    return BadRequest("错误了！");
                }
            }else
            {
                return BadRequest("信息有误！");
            }                 
        }
        #endregion
    }
}