using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedactionsController : ControllerBase
    {
        private readonly IRedactionService _redactionService;

        public RedactionsController(IRedactionService redactionService)
        {
            _redactionService = redactionService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Redaction redaction)
        {
            var result = _redactionService.Add(redaction);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _redactionService.Delete(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _redactionService.ShadowDelete(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Redaction redaction)
        {
            var result = _redactionService.Update(redaction);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _redactionService.GetById(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _redactionService.GetAllByName(name);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllBySurname")]
        public IActionResult GetAllBySurname(string surname)
        {
            var result = _redactionService.GetAllBySurname(surname);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilter(Expression<Func<Redaction, bool>>? filter = null)
        {
            var result = _redactionService.GetAllByFilter(filter);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _redactionService.GetAllByIsDeleted();
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _redactionService.GetAll();
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
