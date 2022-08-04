using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverCapsController : ControllerBase
    {
        private readonly ICoverCapService _coverCapService;

        public CoverCapsController(ICoverCapService coverCapService)
        {
            _coverCapService = coverCapService;
        }

        [HttpPost("Add")]
        public IActionResult Add(CoverCap coverCap)
        {
            var result = _coverCapService.Add(coverCap);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(byte id)
        {
            var result = _coverCapService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(byte id)
        {
            var result = _coverCapService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(CoverCap coverCap)
        {
            var result = _coverCapService.Update(coverCap);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(byte id)
        {
            var result = _coverCapService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _coverCapService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<CoverCap, bool>>? filter = null)
        {
            var result = _coverCapService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _coverCapService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            var result = _coverCapService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
