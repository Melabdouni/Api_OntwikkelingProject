using MVC_Deel1.Entities;

namespace MVC_Deel1.Services
{
    public interface IBuildingData
    {
        IEnumerable<Building> GetAll();
        Building Get(int id);
        void Add (Building building);
        void Delete (Building building);
        void Update (Building building);
        
    }
}
