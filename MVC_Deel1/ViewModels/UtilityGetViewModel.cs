using MVC_Deel1.Entities;
using MVC_Deel1.Services;
using MVC_Deel1.Controllers;

namespace MVC_Deel1.ViewModels
{
    public class UtilityGetViewModel
    {
         public int UserId { get; set; }
        public string UserName { get; set; }
         public string BtwNummer { get; set; }
        public string Type { get; set; }

        public string Utility { get; set; }
    };
}
