using Business.Abstract;
using Entities.Concrete.Infos;
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

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _technicalPlaceholderService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByColumnCode")]
        public IActionResult GetByColumnCode(string columnCode)
        {
            var result = _technicalPlaceholderService.GetByColumnCode(columnCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByRowCode")]
        public IActionResult GetByRowCode(string rowCode)
        {
            var result = _technicalPlaceholderService.GetByRowCode(rowCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetBySpecialLocation")]
        public IActionResult GetBySpecialLocation(string specialLocation)
        {
            var result = _technicalPlaceholderService.GetBySpecialLocation(specialLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<TechnicalPlaceholder, bool>>? filter = null)
        {
            var result = _technicalPlaceholderService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _technicalPlaceholderService.GetAllBySecrets();
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
