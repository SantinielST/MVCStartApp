using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models;
using MVCStartApp.Repository.Interfaces;

namespace MVCStartApp.Repository;

public class RequestRepository(BlogContext context) : IRequestRepository
{
    private readonly BlogContext _context = context;

    [HttpPost]
    public async Task AddRequest(Request request)
    {
        var entry = _context.Entry(request);
        if (entry.State == EntityState.Detached)
            await _context.Requests.AddAsync(request);

        // Сохранение изменений
        await _context.SaveChangesAsync();
    }

    public async Task<Request[]> GetRequests()
    {
        return await _context.Requests.OrderByDescending(r => r.Date).ToArrayAsync();
    }
}
