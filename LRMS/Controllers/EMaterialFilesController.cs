using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMaterialFilesController : ControllerBase
    {
        private readonly IEMaterialFileService _eMaterialFileService;

        public EMaterialFilesController(IEMaterialFileService eMaterialFileService)
        {
            _eMaterialFileService = eMaterialFileService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm] IFormFile file, EMaterialFile entity)
        {
            var result = _eMaterialFileService.Add(file, entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _eMaterialFileService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _eMaterialFileService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] IFormFile file, EMaterialFile entity)
        {
            var result = _eMaterialFileService.Update(file, entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _eMaterialFileService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _eMaterialFileService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<EMaterialFile, bool>>? filter = null)
        {
            var result = _eMaterialFileService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _eMaterialFileService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _eMaterialFileService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
