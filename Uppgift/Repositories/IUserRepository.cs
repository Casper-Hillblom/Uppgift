using Uppgift.Models;

namespace Uppgift.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(int id);   
        Task Delete(int id);
        Task Update(User user);
        Task<User> Create(User user);
    }
}
