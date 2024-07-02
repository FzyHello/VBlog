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

        #region 获取该用户按时间顺序的文章，用于展示归档记录
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
                    return BadRequest("错误了！");
                }
            }
            catch (Exception ex)
            {
                // 捕获并处理异常
                return BadRequest("错误了！");
            }
        }
        #endregion

        #region 获取该用户所有的文章标签，用于展示标签分类
        [HttpPost("lable")]
        public ActionResult<List<String>> ObtainArticleLable()
        {
            try
            {
                if (HttpContext.Items.ContainsKey("UserId"))
                {
                    string userId = HttpContext.Items["UserId"].ToString();
                    var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == userId);
                    var articles = dbCtx.Articles.Where(a => a.Account_Id == result.Uuid && a.Is_Deleted == false).Select(a => a.Article_Type).Distinct().ToList(); //返回该用户的文章的所有标签，去重后返回列表。
                    return Ok(articles.Select(a => a.ToString()).ToList()); //返回该用户的文章的所有标签，去重后返回列表。
                }
                else
                {
                    return BadRequest("错误了！");
                }
            }
            catch (Exception ex)
            {
                // 捕获并处理异常
                return BadRequest("错误了！");
            }
        }
        #endregion

        #region 获取该用户最近的五条文章列表，用于首页展示
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
                    return BadRequest("错误了！");
                }
            }
            catch (Exception ex)
            {
                // 捕获并处理异常
                return BadRequest("错误了！");
            }
        }
        #endregion

    }
}