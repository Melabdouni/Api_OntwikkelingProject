using MVC_Deel1.Entities;
using System.ComponentModel.DataAnnotations;
namespace MVC_Deel1.ViewModels
{
    public class BuildingCreateViewModel

    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public string Adress { get; set; }
        public BuildingType BuildingType { get; set; }    
    }
}
