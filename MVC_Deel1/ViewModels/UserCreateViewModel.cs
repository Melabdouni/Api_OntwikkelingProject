using MVC_Deel1.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVC_Deel1.ViewModels
{
    public class UserCreateViewModel
    {
        [Required, MaxLength(80)]
        public string UserName { get; set; }
        public string BtwNummer { get; set; }
        /*public List<int> UtilityIds { get; set; }*/
        public int BuildingId { get; set; }

    }
}
