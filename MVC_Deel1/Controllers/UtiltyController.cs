using Microsoft.AspNetCore.Mvc;
using MVC_Deel1.Entities;
using MVC_Deel1.Services;
using MVC_Deel1.ViewModels;

namespace MVC_Deel1.Controllers
{
    [Route("[controller]")]
    public class UtiltyController : Controller
    {
        private readonly IUtilityData _utilityData;
        private readonly IUserData _userData;
        private readonly IEnumerable<Utility> _utilities;

        public UtiltyController(IUtilityData utilityData, IUserData userData)
        {
            _utilityData = utilityData;
            _userData = userData;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var utilitieTypes = _utilityData.GetUtilityTypes();
            return new ObjectResult(utilitieTypes);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var utilitieType = _utilityData.GetUtilityTypes();
            if (utilitieType == null)
            {
                return NotFound();
            }
            return Ok(_utilityData.Get(id));
        }

        [HttpGet]
        [Route("User/{utilityId}/Utility")]
        public IActionResult GetUtilityByUser(int utilityId)

        {   
            if (utilityId == null)
            {
                return NotFound();
            }

            var userWithUtility = _utilityData.GetAll().Where(u => u.Id == utilityId); ;
            if (!userWithUtility.Any())
            {
                return NotFound();
            }

            var usersWithGivenUtilityId = userWithUtility.Select(u => u.UserId).Distinct();
            if (userWithUtility == null)
            {
                return NotFound();
            }

            return Ok(userWithUtility);
        }

        [HttpPost("PostNewUserWithUtility")]
        public IActionResult Create([FromBody] UtilityCreateViewModel utilityCreateViewModel)
        {
            if (utilityCreateViewModel == null)
            {
                return BadRequest("Inval data");
            }

            var existingUser = _userData.GetAll().FirstOrDefault(u => u.Id == utilityCreateViewModel.UserId);
            if (existingUser != null)
            {
                return BadRequest("User already exist");
            }
            var newUser = new User
            {
                Id = utilityCreateViewModel.UserId,
                UserName = utilityCreateViewModel.UserName,
            };
            _userData.Add(newUser);

            var newUtility = new Utility
            {
                User = newUser,
                UserId = utilityCreateViewModel.UserId,
                Type = utilityCreateViewModel.Type,

            };

            _utilityData.Add(newUtility);
            return CreatedAtAction(nameof(Details), new { id = newUtility.Id }, newUtility);
        }



    }
}
       