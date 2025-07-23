using MVCStartApp.Models;

namespace MVCStartApp.Repository.Interfaces;

public interface IRequestRepository
{
    Task AddRequest(Request request);
    Task<Request[]> GetRequests();
}
