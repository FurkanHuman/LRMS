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

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _dimensionsService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDimension")]
        public IActionResult GetByDimension(Dimension dimension)
        {
            var result = _dimensionsService.GetByDimension(dimension);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByXandY")]
        public IActionResult GetByXandY(double xMM, double yMM)
        {
            var result = _dimensionsService.GetByXandY(xMM, yMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByYandZ")]
        public IActionResult GetByYandZ(double yMM, double zMM)
        {
            var result = _dimensionsService.GetByYandZ(yMM, zMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByZandX")]
        public IActionResult GetByZandX(double zMM, double xMM)
        {
            var result = _dimensionsService.GetByZandX(zMM, xMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByXYZMinMax")]
        public IActionResult GetByXYZMinMax(double xMinMM, double? xMaxMM, double yMinMM, double? yMaxMM, double zMinMM, double? zMaxMM)
        {
            var result = _dimensionsService.GetByXYZMinMax(xMinMM, xMaxMM, yMinMM, yMaxMM, zMinMM, zMaxMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByX")]
        public IActionResult GetByX(double xMM)
        {
            var result = _dimensionsService.GetByX(xMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByY")]
        public IActionResult GetByY(double yMM)
        {
            var result = _dimensionsService.GetByY(yMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByZ")]
        public IActionResult GetByZ(double zMM)
        {
            var result = _dimensionsService.GetByZ(zMM);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<Dimension, bool>>? filter = null)
        {
            var result = _dimensionsService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _dimensionsService.GetAllBySecrets();
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
