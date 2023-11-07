using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        IAnswerService _answerService;

        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _answerService.GetById(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _answerService.GetAll();
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Answer answer)
        {
            _answerService.Add(answer);
            var result = _answerService.GetById(answer.AnswerId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
