using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComposersController : ControllerBase
    {
        private readonly IComposerService _composerService;

        public ComposersController(IComposerService composerService)
        {
            _composerService = composerService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Composer composer)
        {
            var result = _composerService.Add(composer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoAdd")]
        public IActionResult DtoAdd(ComposerAddDto composerAdd)
        {
            var result = _composerService.DtoAdd(composerAdd);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _composerService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _composerService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Composer composer)
        {
            var result = _composerService.Update(composer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoUpdate")]
        public IActionResult DtoUpdate(ComposerUpdateDto composerDto)
        {
            var result = _composerService.DtoUpdate(composerDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _composerService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetById")]
        public IActionResult DtoGetById(Guid id)
        {
            var result = _composerService.DtoGetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _composerService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByName")]
        public IActionResult DtoGetAllByName(string name)
        {
            var result = _composerService.DtoGetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllBySurname")]
        public IActionResult GetAllBySurname(string surname)
        {
            var result = _composerService.GetAllBySurname(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllBySurname")]
        public IActionResult DtoGetAllBySurname(string surname)
        {
            var result = _composerService.DtoGetAllBySurname(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByNamePreAttachment")]
        public IActionResult GetAllNamePreAttachment(string namePreAttachment)
        {
            var result = _composerService.GetAllByNamePreAttachment(namePreAttachment);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByNamePreAttachment")]
        public IActionResult DtoGetAllNamePreAttachment(string namePreAttachment)
        {
            var result = _composerService.DtoGetAllByNamePreAttachment(namePreAttachment);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Composer, bool>>? filter = null)
        {
            var result = _composerService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByFilter")]
        public IActionResult DtoGetAllByFilter(Expression<Func<Composer, bool>>? filter = null)
        {
            var result = _composerService.DtoGetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByIsDeleted")]
        public IActionResult GetAllByIsDeleted()
        {
            var result = _composerService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult DtoGetAllByIsDeleted()
        {
            var result = _composerService.DtoGetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _composerService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAll")]
        public IActionResult DtoGetAll()
        {
            var result = _composerService.DtoGetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
