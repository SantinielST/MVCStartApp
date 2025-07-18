using Microsoft.AspNetCore.Mvc;
using MVCStartApp.DLL.Repository.Interfaces;

namespace MVCStartApp.Controllers;

public class UsersController(IBlogRepository blogRepository) : Controller
{
    private readonly IBlogRepository _blogRepository = blogRepository;

    public async Task<IActionResult> Index()
    {
        var authors = await _blogRepository.GetUsers();
        return View(authors);
    }
}
