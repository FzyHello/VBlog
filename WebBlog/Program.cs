using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Configuration;
using ModelEFCore;
using BlogHelper;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Unicode;

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
    string connStr = builder.Configuration.GetSection("connStr").Value;
    opt.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        
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
app.UseMiddleware<HttpInterceptorMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
