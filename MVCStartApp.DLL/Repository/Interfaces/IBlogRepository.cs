using MVCStartApp.BLL.Models;

namespace MVCStartApp.DLL.Repository.Interfaces;

public interface IBlogRepository
{
    Task AddUser(User user);
    Task<User[]> GetUsers();
    Task Register(User user);
}