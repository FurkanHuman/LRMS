using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalPlaceholdersController : ControllerBase
    {
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;

        public TechnicalPlaceholdersController(ITechnicalPlaceholderService technicalPlaceholderService)
        {
            _technicalPlaceholderService = technicalPlaceholderService;
        }

        [HttpPost("Add")]
        public IActionResult Add(TechnicalPlaceholder technicalPlaceholder)
        {
            var result = _technicalPlaceholderService.Add(technicalPlaceholder);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _technicalPlaceholderService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _technicalPlaceholderService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(TechnicalPlaceholder technicalPlaceholder)
        {
            var result = _technicalPlaceholderService.Update(technicalPlaceholder);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _technicalPlaceholderService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _technicalPlaceholderService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByColumnCode")]
        public IActionResult GetAllByColumnCode(string columnCode)
        {
            var result = _technicalPlaceholderService.GetAllByColumnCode(columnCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByRowCode")]
        public IActionResult GetAllByRowCode(string rowCode)
        {
            var result = _technicalPlaceholderService.GetAllByRowCode(rowCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllBySpecialLocation")]
        public IActionResult GetAllBySpecialLocation(string specialLocation)
        {
            var result = _technicalPlaceholderService.GetAllBySpecialLocation(specialLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<TechnicalPlaceholder, bool>>? filter = null)
        {
            var result = _technicalPlaceholderService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _technicalPlaceholderService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _technicalPlaceholderService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
