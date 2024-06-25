using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Configuration;
using ModelEFCore;
using BlogHelper;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<GenerateToken>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(opt => {
    opt.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions
    {
        EndPoints = { "localhost:6379" }, // Redis 服务器地址和端口
        Password = "137624351",  // Redis 密码
    };
    opt.InstanceName = "cache_";
});
builder.Services.AddCors(opt => {
    opt.AddDefaultPolicy(b => {
        b.WithOrigins(new string[] { "http://localhost:5173" }).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});
builder.Services.AddDbContext<MyDbContext>(opt => {
#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
    string connStr = builder.Configuration.GetSection("connStr").Value;
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
    opt.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
    //写一个输出显示到控制台 是否成功连接数据库的代码  
        
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine("连接数据库成功！");
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
