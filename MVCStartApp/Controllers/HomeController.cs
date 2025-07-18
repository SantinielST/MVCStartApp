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


        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
        {
            // Добавим создание нового пользователя
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrey",
                LastName = "Petrov",
                JoinDate = DateTime.Now
            };

            // Добавим в базу
            await _blogRepository.AddUser(newUser);

            // Выведем результат
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
