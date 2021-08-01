using Microsoft.AspNetCore.Mvc;
using WaterJugAPI.Core.Entities;
using WaterJugAPI.Infrastructure;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterJugAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterJugController : ControllerBase
    {
        private readonly IWaterJugService _waterJugService;
        public WaterJugController(IWaterJugService waterJugService)
        {
            _waterJugService = waterJugService;
        }
        // POST api/<WaterJugController>
        [HttpPost]
        public IActionResult Post([FromBody] WaterJug waterJug)
        {
            if (waterJug == null)
                return BadRequest(new { message = "Value cannot be null" });

            int bucketX = waterJug.BucketX;
            int bucketY = waterJug.BucketY;
            int mazureBuckets = waterJug.MazureBuckets;

            if (bucketX < 1 || bucketY < 1 || mazureBuckets < 1)
                return BadRequest(new { message = "Values cannot be less then 1" });

            return Ok(_waterJugService.MinSteps(bucketX, bucketY, mazureBuckets));
        }
    }
}
