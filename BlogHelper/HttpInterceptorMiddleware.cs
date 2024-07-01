
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;



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



        // 在这里添加你的拦截逻辑
        //路径为/Login的请求不拦截 切继续执行/Login请求

        // 遍历Redis中的键值对
        if (context.Request.Path == "/Login")
        {
            await _next(context);
            return; 
        }
        string token = context.Request.Headers["Authorization"];
        //去掉token 前缀bearer
        if (!string.IsNullOrEmpty(token))token = token.Split(" ")[1];
        var data = await _cache.GetAsync(token);

        //根据token去判断redis中是否存在token，如果存在则继续执行，否则拦截请求。
        //string key = _cache.Get("20240701233251LOVE12345627525");// 拦截请求，不继续执行下一个中间件。


        // 如果不需要拦截，继续执行下一个中间件
        await _next(context);
    }
}