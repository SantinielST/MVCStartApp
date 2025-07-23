using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Repository.Interfaces;
using MVCStartApp.Services;

namespace MVCStartApp.Controllers;

public class RequestsController(IRequestRepository requestRepository, ILoggerService loggerService) : Controller
{
    private readonly IRequestRepository _requestRepository = requestRepository;
    private readonly ILoggerService _loggerService = loggerService;

    [HttpGet]
    public async Task<IActionResult> Logs()
    {
        var requestUrl = HttpContext.Items["Url"] as string;

        if (HttpContext.Items.TryGetValue("CurrentDateTime", out var dateTimeObj))
        {
            await _loggerService.Log(requestUrl, dateTimeObj);
        }

        var Logs = await _requestRepository.GetRequests();

        return View(Logs);
    }
}