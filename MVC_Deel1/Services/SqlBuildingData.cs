/*using MVC_Deel1.Entities;
using MVC_Deel1.Services;
using MVC_Deel1.Controllers;

namespace MVC_Deel1.Services
{
    public class SqlBuildingData : IBuildingData
    {

        private MVCDbContext _context;
    }
   public SqlBuildingData(MVCDbContext context)
    {
        _context = context;

    }
    public IEnumerable<Building> GetAll()
    {
        return _context.Buildings;
    }
    public Building Get(int id)
    {
        return _buildings.FirstOrDefault(x => x.Id == id);
    }
    public void Add(Building building)
    {
        building.Id = _buildings.Max(x => x.Id) + 1;
        _buildings.Add(building);
    }

    public void Delete(Building building)
    {
        _buildings.Remove(building);
    }
    public void Update(Building building)
    {
        var oldBuilding = Get(building.Id);
        oldBuilding.Name = building.Name;
        oldBuilding.BuildingType = building.BuildingType;
    }
    public IEnumerable<User> GetUsersByBuilding(int buildingId)
    {
        var building = (buildingId);
        if (building == null)
            return Enumerable.Empty<User>();

        var users = new List<User>();

        return _userData.GetAll().Where(u => u.BuildingId == buildingId);
    }
}
*/