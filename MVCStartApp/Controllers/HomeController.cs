using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCStartApp.DLL.Repository.Interfaces;
using MVCStartApp.BLL.Models;

namespace MVCStartApp.Controllers
{
    public class HomeController(IBlogRepository blogRepository) : Controller
    {
        private readonly IBlogRepository _blogRepository = blogRepository;

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Authors()
        {
            var authors = await _blogRepository.GetUsers();
            return View(authors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
