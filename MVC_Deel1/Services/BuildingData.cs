using Microsoft.EntityFrameworkCore;
using MVC_Deel1.Entities;
using MVC_Deel1.Services;

namespace MVC_Deel1.Services
{
 
        public class SqlBuildingData : IBuildingData
    {
        private static List<Building> _buildings;
        private IUserData _userData;
        

        private MVCDbContext _context;
        
        public SqlBuildingData (MVCDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Building> GetAll()
        {
            return _context.Buildings;
        }
        public Building Get(int id)
        {
            return _context.Buildings.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Building building)
        {
            building.Id = _context.Buildings.Max(x => x.Id) + 1;
            _context.Buildings.Add(building);
        }
        public void Delete(Building building)
        {
            _context.Buildings.Remove(building);
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



    public class InMemoryBuildingData : IBuildingData
    {
        private static List<Building> _buildings;
        private IUserData _userData;
        static InMemoryBuildingData()
        {
            _buildings = new List<Building>
            {
            new Building { Id = 1, Name = "Kaai 102", Adress = "Loodglansstraat 5", BuildingType= BuildingType.Kantoor },
            new Building { Id = 2, Name = "Den Dankaert", Adress = "Boudewijnweg 19", BuildingType= BuildingType.Werkplaats},
            new Building { Id = 3, Name = "Nautisch Cluster", Adress = "Blauwhoefstraat 15",BuildingType= BuildingType.Kantoor},
            new Building { Id = 4, Name = "Thornton", Adress = "Oosterweelsteenweg 234", BuildingType= BuildingType.PubliekGebouw},
            new Building { Id = 5, Name = "ZAS", Adress = "Potpolderweg 65", BuildingType=  BuildingType.Magazijn},
            new Building { Id = 6,Name = "VCS_B0S", Adress = "Adinkerkestraat 123", BuildingType= BuildingType.Werkplaats},
            new Building { Id = 7,Name = "Narvik", Adress = "Stanietstraat 24", BuildingType= BuildingType.Magazijn},
            new Building { Id = 8,Name = "Siberia", Adress = "Scheldelaan 1", BuildingType= BuildingType.Kantoor},
            new Building { Id = 9,Name = "Sluismeesterwoning", Adress = "Letlandstraat 34", BuildingType= BuildingType.Werkplaats }
            };
        }
        public IEnumerable<Building> GetAll()
        {
           return _buildings;
        }
        public  Building Get(int id)
        {
            return _buildings.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Building building)
        {
            building.Id = _buildings.Max(x => x.Id) + 1;
            _buildings.Add(building);
        }

        public void Delete (Building building) 
        {
            _buildings.Remove(building);
        }
        public void Update (Building building)
        {
            var oldBuilding= Get(building.Id);
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
}
