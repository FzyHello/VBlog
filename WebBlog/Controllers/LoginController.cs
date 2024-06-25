using BlogHelper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using ModelEFCore;

namespace WebBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext dbCtx;
        private readonly GenerateToken _tokenGenerator;
        private readonly ILogger<LoginController> _logger;
        private readonly IDistributedCache _cache;

        public LoginController(MyDbContext dbCtx, GenerateToken tokenGenerator, IDistributedCache cache)
        {
            this.dbCtx = dbCtx;
            _tokenGenerator = tokenGenerator;
            _cache = cache;
        }

        # region 登录验证
        [HttpPost]
        public ActionResult<Account> Login([FromBody] Account account)
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
                // 判断是否是管理员账号，如果是则返回管理员权限，否则返回普通用户权限
                if (result.Role == 0)
                {
                    // 管理员权限。
                    return Ok("管理员登录成功!");
                }
                else
                {
                    //普通用户权限
                    if(result.Is_Deleted == true)
                    {
                        //判断账户是否已经被注销
                        return BadRequest("该账户已被注销，请联系管理员！");
                    }
                    else
                    {
                        // 普通用户权限正常登录
                        //更新这条记录的登录时间
                        result.Last_LoginTime = DateTime.Now; // 假设这是更新登录时间的代码。

                        try
                        {
                            // 保存更改到数据库
                            dbCtx.SaveChanges();
                            string token = _tokenGenerator.LoginToken(result);
                            _cache.SetString(result.User_Name, token); // 假设这是将token存储到缓存的代码。
                            return Ok("普通用户登录成功!" + token);
                        }
                        catch (Exception ex)
                        {
                            // 捕获并处理异常
                            return StatusCode(500, $"保存更改时发生错误: {ex.Message}");
                        }
                    }
                }
            }else
            {
                return BadRequest("用户名或密码错误，请重新输入！");
            }                 
        }
        #endregion
    }
}