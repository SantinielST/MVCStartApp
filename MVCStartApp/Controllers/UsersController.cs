using Microsoft.AspNetCore.Mvc;
using MVCStartApp.DLL.Repository.Interfaces;
using MVCStartApp.BLL.Models;
using MVCStartApp.Services;

namespace MVCStartApp.Controllers;

public class UsersController(IBlogRepository blogRepository, ILoggerService loggerService) : Controller
{
    private readonly IBlogRepository _blogRepository = blogRepository;
    private readonly ILoggerService _loggerService = loggerService;

    public async Task<IActionResult> Index()
    {
        var authors = await _blogRepository.GetUsers();
        return View(authors);
    }

    public async Task<IActionResult> Register()
    {
        var requestUrl = HttpContext.Items["Url"] as string;

        if (HttpContext.Items.TryGetValue("CurrentDateTime", out var dateTimeObj))
        {
           await _loggerService.Log(requestUrl, dateTimeObj);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User newUser)
    {
        await _blogRepository.Register(newUser);
        return View(newUser);
    }
}
