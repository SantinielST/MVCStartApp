namespace MVCStartApp.Middlewares;

/// <summary>
///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
/// </summary>
public class LoggingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    /// <summary>
    ///  Необходимо реализовать метод Invoke  или InvokeAsync
    /// </summary>
    /// <summary>
    ///  Необходимо реализовать метод Invoke  или InvokeAsync
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        // Для логирования данных о запросе используем свойста объекта HttpContext
        Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

        var url = $"http://{context.Request.Host.Value + context.Request.Path}";
        var dateTimeRequest = DateTime.Now;

        context.Items["CurrentDateTime"] = dateTimeRequest;
        context.Items["Url"] = url;

        // Передача запроса далее по конвейеру
        await _next.Invoke(context);
    }
}
