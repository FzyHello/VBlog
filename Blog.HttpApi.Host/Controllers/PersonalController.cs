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

        # region ��ȡ������Ϣ
        [HttpPost]
        public ActionResult<UserInfo> ObtainPersonal([FromBody] Account account)
        {
            //дһ���жϱ�֤�˻����벻Ϊ��
            if (string.IsNullOrEmpty(account.User_Name) || string.IsNullOrEmpty(account.Password))
            {
                return BadRequest("�û��������벻��Ϊ��");
            }

            var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == account.User_Name && a.Password == account.Password);

            // ����ѯ����Ƿ�Ϊ�ջ��ߵ���0�����Ϊ�ջ��ߵ���0�򷵻ش�����Ϣ�����򷵻سɹ���Ϣ
            if (result != null )
            {
                try
                {
                    var personalResult = dbCtx.UserInfos.FirstOrDefault(a => a.Account_Id == result.Uuid);
                    return Ok(personalResult);
                }
                catch (Exception ex)
                {
                    // ���񲢴����쳣
                    return BadRequest("�����ˣ�");
                }
            }else
            {
                return BadRequest("��Ϣ����");
            }                 
        }
        #endregion
    }
}