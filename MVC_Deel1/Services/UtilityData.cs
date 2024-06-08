using MVC_Deel1.Services;
using MVC_Deel1.Entities;
using System.Security.Cryptography.X509Certificates;
using MVC_Deel1.ViewModels;

namespace MVC_Deel1.Services
{
    public class InMemoryUtilityData : IUtilityData
    {
        private static List<Utility> _utilities;
        private IUserData _userData;

     
        static InMemoryUtilityData()
        {

            _utilities = new List<Utility>
            {
                new Utility {Id=1 , Type = "gas", UserId=0},
                new Utility {Id=1 , Type = "gas", UserId=1},
                new Utility {Id=2 ,Type= "electricity", UserId = 1},
                new Utility {Id=3 ,Type = "water", UserId = 1},
                new Utility {Id=1 , Type = "gas", UserId=2},
                new Utility {Id=2 ,Type= "electricity", UserId = 2},
                new Utility {Id=3 ,Type = "water", UserId = 2},
                new Utility {Id=1 , Type = "gas", UserId=3},
                new Utility {Id=2 ,Type= "electricity", UserId = 3},
                new Utility {Id=3 ,Type = "water", UserId = 3},
                new Utility {Id=1 , Type = "gas", UserId= 4},
                new Utility {Id=2 ,Type= "electricity", UserId = 4},
                new Utility {Id=3 ,Type = "water", UserId = 4},
                new Utility {Id=2 ,Type = "electricity", UserId = 5},
                new Utility {Id=3 ,Type = "water", UserId = 6},
                new Utility {Id=1 ,Type = "gas", UserId = 7},
                new Utility {Id=2 ,Type = "electricity", UserId = 7},


            };
        }


        public InMemoryUtilityData(IUserData userData)
        {
            _userData = userData;

            foreach (var utility in _utilities)
            {
                var user = _userData.Get(utility.UserId);
                if (user != null)
                {
                    user.Utilities.Add(utility);
                    utility.User = user;
                }
            
            }
        }

        public IEnumerable<Utility> GetAll()
            {
            return _utilities;
            }
        public IEnumerable<string> GetUtilityTypes()
        {
            var uniqueUtilityTypes = _utilities.Select(u => u.Type).Distinct();
            return uniqueUtilityTypes;
        }

        public Utility Get(int id)
        {
            return _utilities.FirstOrDefault(x => x.Id == id);
        }
        /*List<Utility> _utilities;*/

        public Utility Get(Utility utility)
        {
            if (utility == null)
            {
                throw new ArgumentNullException(nameof(utility));
            }

            return _utilities.FirstOrDefault(x => x.Id == utility.Id);
        }
        public void Add(Utility utility)
        {
            utility.Id = _utilities.Max(x => x.Id) + 1;
            _utilities.Add(utility);
        }
        public void Delete(Utility utility)
        {
            _utilities.Remove(utility);
        }

        public void Update(Utility utility)
        {
            utility.Id = _utilities.Max(y => y.Id) + 1;
        }


        public IEnumerable<UtilityGetViewModel> GetUtilityByUser(int UserId)
        {
            var user = _userData.Get(UserId);
            if (user == null) return null;

            var utilities = _utilities.Where(x => x.UserId == UserId);

            var utilityViewModels = utilities.Select(u => new UtilityGetViewModel
            {
                UserName = user.UserName,
                BtwNummer = user.BtwNummer,
                Utility  = u.Type
            });

            return utilityViewModels;
        }

    }
}
