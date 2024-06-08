using MVC_Deel1.Entities;
using MVC_Deel1.Services;
using MVC_Deel1.Controllers;

namespace MVC_Deel1.Services
{
    public class InMemoryUserData: IUserData
    {
        private static List<User> _users;
        private IBuildingData _buildingData;
        
        static InMemoryUserData() 
        {
            _users = new List<User>
            {
                new User {Id= 0, UserName= "QA", BtwNummer= "BE12343", BuildingId= 1},
                new User {Id= 1, UserName= "QA", BtwNummer= "BE12343", BuildingId= 1},
                new User {Id= 2, UserName= "BI",BtwNummer= "BE15643", BuildingId= 2 },
                new User {Id= 3, UserName= "MI",BtwNummer= "BE12876", BuildingId= 3},
                new User {Id= 4, UserName= "OP",BtwNummer= "BE65443", BuildingId= 4}, 
                new User {Id= 5, UserName= "CRO",BtwNummer= "BE00964", BuildingId= 4},
                new User {Id= 6, UserName= "INT",BtwNummer= "BE11987", BuildingId= 3},
                new User {Id= 7, UserName= "FBI",BtwNummer= "BE98543", BuildingId= 1},
                new User {Id= 8, UserName= "COM",BtwNummer= "BE43891", BuildingId= 4},
                new User {Id= 9, UserName= "REG",BtwNummer= "BE50225", BuildingId= 5},
                new User {Id= 10, UserName= "REG",BtwNummer= "BE50225", BuildingId= 7},
                new User {Id= 11, UserName= "REG",BtwNummer= "BE50225", BuildingId= 6}

            };
        }
        public InMemoryUserData(IBuildingData buildingData)
        {
            _buildingData = buildingData;

            //  users met de buildings
            foreach (var user in _users)
            {
                var building = _buildingData.Get(user.BuildingId);
                if (building != null)
                {
                    building.Users.Add(user);
                    user.Building = building;
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
          

        public User Get(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
        public void Add(User user)
        {
            user.Id = _users.Max(x => x.Id) + 1;
            _users.Add(user);
        }
        public void Delete(User userName)
        {
            _users.Remove(userName);
        }
        public void Update(User user)
        {
            user.Id = _users.Max(y => y.Id) + 1;
        }
        public Building GetBuilding(int id)
        {
            var user = Get(id);
            return user?.Building;
        }


    }
}
