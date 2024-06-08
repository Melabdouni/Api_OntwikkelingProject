using MVC_Deel1.Entities;
using MVC_Deel1.Services;
using MVC_Deel1.ViewModels;

namespace MVC_Deel1.Services
{
    public interface IUtilityData
    {
        IEnumerable<Utility> GetAll();
        Utility Get(int Id);
        IEnumerable<UtilityGetViewModel> GetUtilityByUser(int UserId);
        void Add(Utility utility);
        void Delete(Utility utility);
        void Update(Utility utility);
        Utility Get(Utility utilityType);
        public IEnumerable<string> GetUtilityTypes();
    }


}
