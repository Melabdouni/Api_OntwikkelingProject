using MVC_Deel1.Entities;
using MVC_Deel1.Services;
using MVC_Deel1.Controllers;
namespace MVC_Deel1.ViewModels

{
    public class BuildingGetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User User { get; set; }
    }
}
