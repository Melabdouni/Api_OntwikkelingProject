using MVC_Deel1.Entities;

namespace MVC_Deel1.Services
{
    public interface IUserData
    {
        IEnumerable<User> GetAll();
        User Get(int Id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);


    }
}
