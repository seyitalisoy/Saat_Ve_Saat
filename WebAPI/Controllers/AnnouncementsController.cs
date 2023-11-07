using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        IAnnouncementService _service;

        public AnnouncementsController(IAnnouncementService service)
        {
            _service = service;
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _service.GetById(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Announcement announcement)
        {
            _service.Add(announcement);
            var result = _service.GetById(announcement.AnnouncementId);
            if (result is null)
            {
                return NotFound();
            }          
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _service.GetById(id);
            if (result is null)
            {
                return NotFound();
            }
            _service.Delete(result);
            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Announcement announcement)
        {
            var result = _service.GetById(announcement.AnnouncementId);
            if (result is null)
            {
                return NotFound();
            }
            _service.Update(announcement);
            return Ok(announcement);
        }
    }
}
