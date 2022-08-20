using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WritersController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Writer writer)
        {
            var result = _writerService.Add(writer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromForm] Guid id)
        {
            var result = _writerService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete([FromForm] Guid id)
        {
            var result = _writerService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Writer writer)
        {
            var result = _writerService.Update(writer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById([FromForm] Guid id)
        {
            var result = _writerService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetById")]
        public IActionResult DtoGetById([FromForm] Guid id)
        {
            var result = _writerService.DtoGetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByIds")]
        public IActionResult GetAllByIds([FromForm] Guid[] ids)
        {
            var result = _writerService.GetAllByIds(ids);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByIds")]
        public IActionResult DtoGetAllByIds([FromForm] Guid[] ids)
        {
            var result = _writerService.DtoGetAllByIds(ids);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName([FromForm] string name)
        {
            var result = _writerService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByName")]
        public IActionResult DtoGetAllByName([FromForm] string name)
        {
            var result = _writerService.DtoGetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllBySurname")]
        public IActionResult GetAllBySurname([FromForm] string surname)
        {
            var result = _writerService.GetAllBySurname(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllBySurname")]
        public IActionResult DtoGetAllBySurname([FromForm] string surname)
        {
            var result = _writerService.DtoGetAllBySurname(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllNamePreAttachment")]
        public IActionResult GetAllNamePreAttachment([FromForm] string name)
        {
            var result = _writerService.GetAllNamePreAttachment(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllNamePreAttachment")]
        public IActionResult DtoGetAllNamePreAttachment([FromForm] string name)
        {
            var result = _writerService.DtoGetAllNamePreAttachment(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Writer, bool>>? filter = null)
        {
            var result = _writerService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByFilter")]
        public IActionResult DtoGetAllByFilter(Expression<Func<Writer, bool>>? filter = null)
        {
            var result = _writerService.DtoGetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _writerService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult DtoGetAllBySecret()
        {
            var result = _writerService.DtoGetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _writerService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAll")]
        public IActionResult DtoGetAll()
        {
            var result = _writerService.DtoGetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
