using MVC_Deel1.Entities;

namespace MVC_Deel1.Entities
{
    public class Utility
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<UserUtility> UserUtility { get; set; } 

    }
}
