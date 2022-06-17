using Business.Abstract;
using Entities.Concrete.Infos;
using Entities.DTOs.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WritersController([FromForm] IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Writer writer)
        {
            var result = _writerService.Add(writer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoAdd")]
        public IActionResult Add([FromForm] WriterDto writer)
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

        [HttpPost("DtoUpdate")]
        public IActionResult Update([FromForm] WriterDto writer)
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

        [HttpPost("GetByNames")]
        public IActionResult GetByNames([FromForm] string name)
        {
            var result = _writerService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetByNames")]
        public IActionResult DtoGetByNames([FromForm] string name)
        {
            var result = _writerService.DtoGetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetBySurnames")]
        public IActionResult GetBySurnames([FromForm] string surname)
        {
            var result = _writerService.GetBySurnames(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetBySurnames")]
        public IActionResult DtoGetBySurnames([FromForm] string surname)
        {
            var result = _writerService.DtoGetBySurnames(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetNamePreAttachmentList")]
        public IActionResult GetNamePreAttachmentList([FromForm] string name)
        {
            var result = _writerService.GetNamePreAttachmentList(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetNamePreAttachmentList")]
        public IActionResult DtoGetNamePreAttachmentList([FromForm] string name)
        {
            var result = _writerService.DtoGetNamePreAttachmentList(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<Writer, bool>>? filter = null)
        {
            var result = _writerService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _writerService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllBySecrets")]
        public IActionResult DtoGetAllBySecrets()
        {
            var result = _writerService.DtoGetAllBySecrets();
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
