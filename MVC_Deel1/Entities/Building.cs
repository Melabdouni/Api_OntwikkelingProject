
using MVC_Deel1.Entities;
using MVC_Deel1.ViewModels;
using MVC_Deel1.Services;
namespace MVC_Deel1.Entities

{
    public enum BuildingType
    {
        Kantoor,
        Werkplaats,
        Magazijn,
        PubliekGebouw
    }
    public class Building
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public BuildingType BuildingType { get; set; }

        /* deze heb ik aangevuld*//*
        public User User { get; set; }*/
        public ICollection<User> Users { get; set; }= new List<User>();

        public ICollection<Utility> Utilities { get; set; }


    }
}
