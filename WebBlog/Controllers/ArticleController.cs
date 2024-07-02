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
        public ActionResult<List<String>> ObtainPersonArticleRecord()
        {
            try
            {
                if (HttpContext.Items.ContainsKey("UserId"))
                {
                    string userId = HttpContext.Items["UserId"].ToString();
                    var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == userId);
                    var articles = dbCtx.Articles.Where(a => a.Account_Id == result.Uuid && a.Is_Deleted == false).OrderByDescending(a => a.Create_Time).ToList();
                    return Ok(articles.Select(a => a.ToString()).ToList());
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

        #region ��ȡ���û����е����±�ǩ������չʾ��ǩ����
        [HttpPost("lable")]
        public ActionResult<List<String>> ObtainArticleLable()
        {
            try
            {
                if (HttpContext.Items.ContainsKey("UserId"))
                {
                    string userId = HttpContext.Items["UserId"].ToString();
                    var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == userId);
                    var articles = dbCtx.Articles.Where(a => a.Account_Id == result.Uuid && a.Is_Deleted == false).Select(a => a.Article_Type).Distinct().ToList(); //���ظ��û������µ����б�ǩ��ȥ�غ󷵻��б�
                    return Ok(articles.Select(a => a.ToString()).ToList()); //���ظ��û������µ����б�ǩ��ȥ�غ󷵻��б�
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

        #region ��ȡ���û���������������б�������ҳչʾ
        [HttpPost("article")]
        public ActionResult<List<Article>> ObtainArticle()
        {
            try
            {
                if (HttpContext.Items.ContainsKey("UserId"))
                {
                    string userId = HttpContext.Items["UserId"].ToString();
                    var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == userId);
                    var articles = dbCtx.Articles.Where(a => a.Account_Id == result.Uuid).OrderByDescending(a => a.Create_Time);
                    return Ok(articles.ToList());
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