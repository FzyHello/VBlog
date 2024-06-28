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
        public ActionResult<List<String>> ObtainPersonArticleRecord([FromBody] Account account)
        {
            //写一个判断保证账户密码不为空
            if (string.IsNullOrEmpty(account.User_Name) || string.IsNullOrEmpty(account.Password))
            {
                return BadRequest("用户名和密码不能为空");
            }

            var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == account.User_Name && a.Password == account.Password && a.Is_Deleted == false);

            // 检查查询结果是否为空或者等于0，如果为空或者等于0则返回错误信息，否则返回成功信息
            if (result != null)
            {
                //返回该用户的文章的所有标题和时间，按时间排序后返回列表。
                var articles = dbCtx.Articles.Where(a => a.Account_Id == account.Uuid && a.Is_Deleted
                == false).OrderByDescending(a => a.Create_Time).ToList(); //返回该用户的文章的所有标题和时间，按时间
                
                return Ok(articles.Select(a => a.ToString()).ToList()); //返回该用户的文章的所有标签，去重后返回列表。
            }
            else
            {
                return BadRequest("用户名或密码错误，请重新输入！");
            }

        }
        #endregion

        #region 获取该用户所有的文章标签，用于展示标签分类
        [HttpPost("lable")]
        public ActionResult<List<String>> ObtainArticleLable([FromBody] Account account)
        {
            //写一个判断保证账户密码不为空
            if (string.IsNullOrEmpty(account.User_Name) || string.IsNullOrEmpty(account.Password))
            {
                return BadRequest("用户名和密码不能为空");
            }

            var result = dbCtx.Accounts.FirstOrDefault(a => a.User_Name == account.User_Name && a.Password == account.Password && a.Is_Deleted == false);

            // 检查查询结果是否为空或者等于0，如果为空或者等于0则返回错误信息，否则返回成功信息
            if (result != null)
            {
                //返回该用户的文章的所有标签
                var articles = dbCtx.Articles.Where(a => a.Account_Id == account.Uuid && a.Is_Deleted == false).Select(a => a.
                    Article_Type ).Distinct().ToList(); //返回该用户的文章的所有标签，去重后返回列表。
                //将articles转为List<String>的类型返回，因为前端需要的是标签列表，而不是文章列表。
                return Ok(articles.Select(a => a.ToString()).ToList()); //返回该用户的文章的所有标签，去重后返回列表。
            }
            else
            {
                return BadRequest("用户名或密码错误，请重新输入！");
            }

        }
        #endregion

        #region 获取该用户最近的五条文章列表，用于首页展示
        [HttpPost("article")]
        public ActionResult<List<Article>> ObtainArticle([FromBody] Account account)
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
                //返回该用户的近期5条文章列表，用于首页展示，按照时间倒序排列，取前5条
                var articles = dbCtx.Articles.Where(a => a.Account_Id == account.Uuid).OrderByDescending(
                    a => a.Create_Time);
                //返回articles的前5条，用于首页展示。并且是返回List<Article>类型
                return Ok(articles.Take(5).ToList()); //返回该用户的近期5条文章列表，用于首页展示，按照时间倒序排列，
            }else
            {
                return BadRequest("用户名或密码错误，请重新输入！");
            }                 
        }
        #endregion

    }
}