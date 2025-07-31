using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCStartApp.DLL.Repository.Interfaces;
using MVCStartApp.BLL.Models;

namespace MVCStartApp.DLL.Repository
{
    public class BlogRepository(BlogContext context) : IBlogRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context = context;

        public async Task AddUser(User user)
        {
            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            // Получим всех активных пользователей
            return await _context.Users.ToArrayAsync();
        }

        [HttpPost]
        public async Task Register(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изменений
            await _context.SaveChangesAsync();
        }
    }
}
