using MVCStartApp.BLL.Models;

namespace MVCStartApp.DLL.Repository.Interfaces;

public interface IRequestRepository
{
    Task AddRequest(Request request);
    Task<Request[]> GetRequests();
}
