using MVC_Deel1.Entities;

namespace MVC_Deel1.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string BtwNummer { get; set; }

        public int BuildingId { get; set; }
        public Building Building {  get; set; }
        public int UtilityId { get; set; }
        public Utility Utility { get; set; }
        public ICollection<Utility> Utilities { get; set; } = new List<Utility>();
    };
}
