using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace ModelEFCore
{
    public class MyDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; } // 定义一个DbSet属性，用于表示Account表的实体集合。
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            base.OnConfiguring(optionsBuilder); // 调用基类的OnConfiguring方法。
        }// 配置数据库连接字符串。

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly); // 自动应用配置类。
        }
    }
}
