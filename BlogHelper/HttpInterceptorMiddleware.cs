
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using ModelEFCore.Migrations;



public class HttpInterceptorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDistributedCache _cache;
    //注入一个可以判断token是否存在的redis服务

    public HttpInterceptorMiddleware(RequestDelegate next, IDistributedCache cache)
    {
        _next = next;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            if (context.Request.Path == "/Login")
            {
                await _next(context);
                return;
            }
            string token = context.Request.Headers["Authorization"];
            //去掉token 前缀bearer
            int index = token.IndexOf("xxx"); // 查找"xxx"的位置
            if (index != -1) // 如果找到了"xxx"
            {
                string part1 = token.Substring(0, index); // 第一段字符串，即"xxx"前的部分
                string part2 = token.Substring(index + 3); // 第二段字符串，即"xxx"后的部分
                string result = part2.Trim('/').Trim('"');
                if (await _cache.GetStringAsync(part1) == part2)
                {
                    context.Items["UserId"] = part1;
                    //如果token存在，则继续执行下一个中间件
                    await _next(context);
                    return;
                }
                else
                {
                    //如果token不存在，则拦截请求
                    context.Response.StatusCode = 401; // 设置状态码为401（未授权）
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
            }
            await _next(context);
        }
        catch (Exception ex)
        {
            return;
        }  
    }
}