using Microsoft.AspNetCore.Mvc;
using ZooApi.Data;
using ZooApi.DTOs;
using ZooApi.Models;
using ZooApi.Services;

namespace ZooApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZooController : ControllerBase
    {
        private readonly ZooService _zooService;

        public ZooController(DataContext dataContext)
        {
            this._zooService = new ZooService(dataContext);
        }

        [HttpGet("animalData")]
        public async Task<IActionResult> GetAnimals()
        {
            return Ok(await _zooService.GetAnimals());
        }

        [HttpPost("animalData/add")]
        public async Task<IActionResult> AddAnimal([FromBody] NewAnimalDTO newAnimalDto)
        {
            Animal animal = new Animal
            {
                Name = newAnimalDto.Name,
                Species = newAnimalDto.Species,
                Count = newAnimalDto.Count,
                Gender = newAnimalDto.Gender,
                Health = newAnimalDto.Health,
                Status = newAnimalDto.Status,
                Longitude = newAnimalDto.Longitude,
                Latitude = newAnimalDto.Latitude,
                Feeding = newAnimalDto.Feeding,
                Image = newAnimalDto.Image,
            };

            await _zooService.AddAnimal(animal);

            return Ok(animal);
        }

        [HttpPut("animalData/{id}/status")]
        public async Task<IActionResult> EditAnimalStatus(int id, [FromBody] AnimalStatusUpdateDTO updateDto)
        {
            Animal animal = await _zooService.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }

            animal.Status = updateDto.Status;
            await _zooService.UpdateAnimal(animal);
            return Ok(animal);
        }






        [HttpGet("zooStatus")]
        public async Task<IActionResult> GetZooStatus()
        {
            //List<ZooStatus> list = await _zooService.GetZooStatus();
            //ZooStatus status = list[0];

            ZooStatus status = (await _zooService.GetZooStatus()).FirstOrDefault();

            if (status == null)
            {
                return NotFound("Zoo status does not exist");
            }

            return Ok(status.Status);
        }

        [HttpPost("zooStatus/initial")]
        public async Task<IActionResult> InitializeZooStatus()
        {
            ZooStatus existing = (await _zooService.GetZooStatus()).FirstOrDefault();

            if (existing != null)
            {
                return BadRequest("Zoo status already exists");
            }

            ZooStatus newStatus = new ZooStatus();
            newStatus.Status = "Open";

            await _zooService.AddZooStatus(newStatus);

            return Ok(newStatus);
        }

        [HttpPut("zooStatus/change")]
        public async Task<IActionResult> ChangeZooStatus([FromBody] ZooStatusUpdateDTO newZooDto)
        {
            //List<ZooStatus> list = await _zooService.GetZooStatus();
            ZooStatus status = (await _zooService.GetZooStatus()).FirstOrDefault();
            status.Status = newZooDto.Status;

            _zooService.UpdateZooStatus(status);

            return Ok(status.Status);
        }





        [HttpGet("visitorCount")]
        public async Task<IActionResult> GetVisitorCount()
        {
            //List<Visitor> list = await _zooService.GetVisitors();
            //Visitor visitor = list[0];

            Visitor visitor = (await _zooService.GetVisitors()).FirstOrDefault();

            if (visitor == null)
            {
                return NotFound("Visitor count does not exist");
            }

            return Ok(visitor.Count.ToString());
        }

        [HttpPost("visitorCount/initial")]
        public async Task<IActionResult> InitializeVisitorCount()
        {
            Visitor existing = (await _zooService.GetVisitors()).FirstOrDefault();

            if (existing != null)
            {
                return BadRequest("Zoo status already exists");
            }

            Visitor newVisitor = new Visitor();
            newVisitor.Count = 50;

            await _zooService.AddVisitor(newVisitor);

            return Ok(newVisitor);
        }

        [HttpPut("visitorCount/change")]
        public async Task<IActionResult> ChangeVisitorCount([FromBody] VisitorCountUpdateDTO newVisitorDto)
        {
            //List<Visitor> list = await _zooService.GetVisitors();
            //Visitor visitor = list[0];

            Visitor visitor = (await _zooService.GetVisitors()).FirstOrDefault();
            visitor.Count = newVisitorDto.Count;

            await _zooService.UpdateVisitorCount(visitor);

            return Ok(await _zooService.GetVisitors());
        }
    }
}
