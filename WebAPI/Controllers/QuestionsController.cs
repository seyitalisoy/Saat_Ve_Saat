using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _questionService.GetById(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _questionService.GetAll();
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Question question)
        {
            _questionService.Add(question);
            var result = _questionService.GetById(question.QuestionId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
       


    }
}

