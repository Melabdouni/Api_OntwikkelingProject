using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MVC_Deel1.Entities;
using MVC_Deel1.Services;
using MVC_Deel1.ViewModels;

namespace MVC_Deel1.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserData _userData;
        private IBuildingData _buildingData;
        private IUtilityData _utilityData;
        public UserController(IUserData userData, IBuildingData buildingData)
        {
            _userData = userData;
            _buildingData = buildingData;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userData.GetAll();
            return new ObjectResult(users);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var user = _userData.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_userData.Get(id));
        }

        [HttpGet("GetUsersByBuilding/{BuildingId}")]
        public IActionResult GetUsersByBuilding(int BuildingId)
        {
            var building = _buildingData.Get(BuildingId);
            if (building == null || building.Users == null)
            {
                return NotFound();
            }
            return Ok(building.Users);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreateViewModel userCreateViewModel)  
        {
            var newUser = new User 

            {
                UserName = userCreateViewModel.UserName, 
                BtwNummer = userCreateViewModel.BtwNummer,
                BuildingId = userCreateViewModel.BuildingId,
            };
            _userData.Add(newUser);
            return CreatedAtAction(nameof(Create), new { newUser.Id }, newUser);
        }

        [HttpPost("AddUtility")]
        public IActionResult AddUtility([FromBody] UtilityAssignmentViewModel utilityAssignmentViewModel)
        {

            if (utilityAssignmentViewModel == null)
            {
                return BadRequest();
            }

            var newUser = _userData.Get(utilityAssignmentViewModel.UserId);
            if (newUser == null)
            {
                return NotFound("User not found");
            }

            var newUtility = _utilityData.Get(utilityAssignmentViewModel.UtilityType);
            

            if (newUser.Utilities == null)
            {
                newUser.Utilities = new List<Utility>();
            }

            newUser.Utilities.Add(newUtility);
            newUtility.User = newUser;

            return Ok(new { utilityAssignmentViewModel.UserId, utilityAssignmentViewModel.UtilityType });
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var userName = _userData.Get(id);
            if (userName == null)
            {
                return NotFound();
            }
            _userData.Delete(userName);
             return NoContent();
        }
        
    }
}

