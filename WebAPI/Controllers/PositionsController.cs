using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _positionService.GetAll();
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Position position)
        {
            _positionService.Add(position);
            var result = _positionService.GetById(position.PositionId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
