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
        public PersonalController(MyDbContext dbCtx, GenerateToken tokenGenerator, ILogger<LoginController> logger)
        {
            this.dbCtx = dbCtx;
            _tokenGenerator = tokenGenerator;
            _logger = logger;
        }

        # region ��ȡ������Ϣ
        [HttpPost]

        public ActionResult<UserInfo> ObtainPersonal()
        {
            try
            {
                if (HttpContext.Items.ContainsKey("UserId"))
                {
                    string userId = HttpContext.Items["UserId"].ToString();
                    var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == userId);
                    var personalResult = dbCtx.UserInfos.FirstOrDefault(a => a.Account_Id == result.Uuid);
                    return Ok(personalResult);
                }
                else
                {
                    return BadRequest("�����ˣ�");
                }
            }
            catch (Exception ex)
            {
                // ���񲢴����쳣
                return BadRequest("�����ˣ�");
            } 
        }
        #endregion
    }
}