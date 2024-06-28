using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Blog.Accounts;
using Blog.Articles;
using Microsoft.EntityFrameworkCore;

namespace Blog.EntityFrameworkCore
{
    //public class DbContext : IDbContext
    //{
    //    public DbSet<ArticleComments> ArticleComments { get; set; }
    //    public DbSet<Article> Articles { get; set; }
    //    public DbSet<UserInfo> UserInfos { get; set; }
    //    public DbSet<Account> Accounts { get; set; } // 定义一个DbSet属性，用于表示Account表的实体集合。

        //public DbContext(DbContextOptions<DbContext> options) : base(options)
        //{

        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{ 
        //    base.OnConfiguring(optionsBuilder); // 调用基类的OnConfiguring方法。
        //}// 配置数据库连接字符串。

        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); // 自动应用配置类。
        //}
   // }
}
