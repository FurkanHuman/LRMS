using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionsController : ControllerBase
    {
        private readonly IDimensionService _dimensionsService;

        public DimensionsController(IDimensionService dimensionsService)
        {
            _dimensionsService = dimensionsService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Dimension dimension)
        {
            var result = _dimensionsService.Add(dimension);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _dimensionsService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _dimensionsService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Dimension dimension)
        {
            var result = _dimensionsService.Update(dimension);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _dimensionsService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _dimensionsService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDimension")]
        public IActionResult GetByDimension(Dimension dimension)
        {
            var result = _dimensionsService.GetByDimension(dimension);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByXandY")]
        public IActionResult GetAllByXandY(double xMM, double yMM)
        {
            var result = _dimensionsService.GetAllByXandY(xMM, yMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByYandZ")]
        public IActionResult GetAllByYandZ(double yMM, double zMM)
        {
            var result = _dimensionsService.GetAllByYandZ(yMM, zMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByZandX")]
        public IActionResult GetAllByZandX(double zMM, double xMM)
        {
            var result = _dimensionsService.GetAllByZandX(zMM, xMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByXYZMinMax")]
        public IActionResult GetAllByXYZMinMax(double xMinMM, double? xMaxMM, double yMinMM, double? yMaxMM, double zMinMM, double? zMaxMM)
        {
            var result = _dimensionsService.GetAllByXYZMinMax(xMinMM, xMaxMM, yMinMM, yMaxMM, zMinMM, zMaxMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByX")]
        public IActionResult GetAllByX(double xMM)
        {
            var result = _dimensionsService.GetAllByX(xMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByY")]
        public IActionResult GetAllByY(double yMM)
        {
            var result = _dimensionsService.GetAllByY(yMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByZ")]
        public IActionResult GetAllByZ(double zMM)
        {
            var result = _dimensionsService.GetAllByZ(zMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Dimension, bool>>? filter = null)
        {
            var result = _dimensionsService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecret")]
        public IActionResult GetAllBySecret()
        {
            var result = _dimensionsService.GetAllBySecret();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _dimensionsService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
