
using Microsoft.AspNetCore.Mvc;
using MVC_Deel1.Entities;
using MVC_Deel1.Services;
using MVC_Deel1.ViewModels;
using System.Security.Cryptography.X509Certificates;
namespace MVC_Deel1.Controllers
{
    [Route("[controller]")]
    public class BuildingController : Controller

    {
        private readonly IBuildingData _buildingData;
        private IUserData _userData;

        public BuildingController(IBuildingData buildingData)
        {
            _buildingData = buildingData;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var buildings = _buildingData.GetAll();
            return new ObjectResult(buildings);
        }


        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var building = _buildingData.Get(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(_buildingData.Get(id));
        }
        [HttpPost()]
        public IActionResult Create([FromBody] BuildingCreateViewModel buildingCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBuilding = new Building
            {
                Name = buildingCreateViewModel.Name,
                BuildingType = buildingCreateViewModel.BuildingType
            };

            _buildingData.Add(newBuilding);
            return CreatedAtAction(nameof(Detail), new { newBuilding.Id }, newBuilding);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var building = _buildingData.Get(id);
            if (building == null)
            {
                return NotFound();
            }
            _buildingData.Delete(building);

            return NoContent();
        }
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody] BuildingUpdateViewModel buildingUpdateViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var building = _buildingData.Get(Id);
            if (building == null)
            {
                return NotFound();
            }
            var UptedBuilding = new Building
            {
                Id = building.Id,
                Name = buildingUpdateViewModel.Name,
                BuildingType = buildingUpdateViewModel.BuildingType

            };
            _buildingData.Update(UptedBuilding);
            return NoContent();



        }
    }

}
