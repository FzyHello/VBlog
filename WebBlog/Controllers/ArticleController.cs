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
    public class ArticleController : ControllerBase
    {
        private readonly MyDbContext dbCtx;
        private readonly GenerateToken _tokenGenerator;
        private readonly ILogger<LoginController> _logger;
        private readonly IDistributedCache _cache;

        public ArticleController(MyDbContext dbCtx, GenerateToken tokenGenerator, IDistributedCache cache)
        {
            this.dbCtx = dbCtx;
            _tokenGenerator = tokenGenerator;
            _cache = cache;
        }

        #region ��ȡ���û���ʱ��˳������£�����չʾ�鵵��¼
        [HttpPost("record")]
        public ActionResult<List<String>> ObtainPersonArticleRecord([FromBody] Account account)
        {
            //дһ���жϱ�֤�˻����벻Ϊ��
            if (string.IsNullOrEmpty(account.User_Name) || string.IsNullOrEmpty(account.Password))
            {
                return BadRequest("�û��������벻��Ϊ��");
            }

            var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == account.User_Name && a.Password == account.Password && a.Is_Deleted == false);

            // ����ѯ����Ƿ�Ϊ�ջ��ߵ���0�����Ϊ�ջ��ߵ���0�򷵻ش�����Ϣ�����򷵻سɹ���Ϣ
            if (result != null)
            {
                //���ظ��û������µ����б����ʱ�䣬��ʱ������󷵻��б�
                var articles = dbCtx.Articles.Where(a => a.Account_Id == account.Uuid && a.Is_Deleted
                == false).OrderByDescending(a => a.Create_Time).ToList(); //���ظ��û������µ����б����ʱ�䣬��ʱ��
                
                return Ok(articles.Select(a => a.ToString()).ToList()); //���ظ��û������µ����б�ǩ��ȥ�غ󷵻��б�
            }
            else
            {
                return BadRequest("�û���������������������룡");
            }

        }
        #endregion

        #region ��ȡ���û����е����±�ǩ������չʾ��ǩ����
        [HttpPost("lable")]
        public ActionResult<List<String>> ObtainArticleLable([FromBody] Account account)
        {
            //дһ���жϱ�֤�˻����벻Ϊ��
            if (string.IsNullOrEmpty(account.User_Name) || string.IsNullOrEmpty(account.Password))
            {
                return BadRequest("�û��������벻��Ϊ��");
            }

            var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == account.User_Name && a.Password == account.Password && a.Is_Deleted == false);

            // ����ѯ����Ƿ�Ϊ�ջ��ߵ���0�����Ϊ�ջ��ߵ���0�򷵻ش�����Ϣ�����򷵻سɹ���Ϣ
            if (result != null)
            {
                //���ظ��û������µ����б�ǩ
                var articles = dbCtx.Articles.Where(a => a.Account_Id == account.Uuid && a.Is_Deleted == false).Select(a => a.
                    Article_Type ).Distinct().ToList(); //���ظ��û������µ����б�ǩ��ȥ�غ󷵻��б�
                //��articlesתΪList<String>�����ͷ��أ���Ϊǰ����Ҫ���Ǳ�ǩ�б������������б�
                return Ok(articles.Select(a => a.ToString()).ToList()); //���ظ��û������µ����б�ǩ��ȥ�غ󷵻��б�
            }
            else
            {
                return BadRequest("�û���������������������룡");
            }

        }
        #endregion

        #region ��ȡ���û���������������б�������ҳչʾ
        [HttpPost("article")]
        public ActionResult<List<Article>> ObtainArticle([FromBody] Account account)
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
                //���ظ��û��Ľ���5�������б�������ҳչʾ������ʱ�䵹�����У�ȡǰ5��
                var articles = dbCtx.Articles.Where(a => a.Account_Id == account.Uuid).OrderByDescending(
                    a => a.Create_Time);
                //����articles��ǰ5����������ҳչʾ�������Ƿ���List<Article>����
                return Ok(articles.Take(5).ToList()); //���ظ��û��Ľ���5�������б�������ҳչʾ������ʱ�䵹�����У�
            }else
            {
                return BadRequest("�û���������������������룡");
            }                 
        }
        #endregion

    }
}