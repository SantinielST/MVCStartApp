using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCStartApp.DLL.Repository.Interfaces;
using MVCStartApp.Models;

namespace MVCStartApp.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IBlogRepository blogRepository) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IBlogRepository _blogRepository = blogRepository;


        // ������� ����� �����������
        public async Task<IActionResult> Index()
        {
            // ������� �������� ������ ������������
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrey",
                LastName = "Petrov",
                JoinDate = DateTime.Now
            };

            // ������� � ����
            await _blogRepository.AddUser(newUser);

            // ������� ���������
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

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
