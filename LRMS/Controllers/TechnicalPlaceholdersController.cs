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

        [HttpPost("GetByStockCode")]
        public IActionResult GetByStockCode(string stockCode)
        {
            var result = _technicalPlaceholderService.GetByStockCode(stockCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByStockNumber")]
        public IActionResult GetByStockNumber(ulong stockNumber)
        {
            var result = _technicalPlaceholderService.GetByStockNumber(stockNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByWhereIsMaterial")]
        public IActionResult GetByWhereIsMaterial(string whereIsMaterial)
        {
            var result = _technicalPlaceholderService.GetByWhereIsMaterial(whereIsMaterial);
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
