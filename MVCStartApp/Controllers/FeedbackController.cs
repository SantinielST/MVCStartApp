using Microsoft.AspNetCore.Mvc;
using MVCStartApp.BLL.Models;
using MVCStartApp.Services;
using System.Diagnostics;

namespace MVCStartApp.Controllers;

public class FeedbackController(ILoggerService loggerService) : Controller
{
    private readonly ILoggerService _loggerService = loggerService;

    /// <summary>
    ///  Метод, возвращающий страницу с отзывами
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var requestUrl = HttpContext.Items["Url"] as string;

        if (HttpContext.Items.TryGetValue("CurrentDateTime", out var dateTimeObj))
        {
            await _loggerService.Log(requestUrl, dateTimeObj);
        }

        return View();
    }

    /// <summary>
    /// Метод для Ajax-запросов
    /// </summary>
    [HttpPost]
    public IActionResult Add(Feedback feedback)
    {
        return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
