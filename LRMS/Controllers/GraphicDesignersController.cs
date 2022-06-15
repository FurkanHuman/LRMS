using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphicDesignersController : ControllerBase
    {
        private readonly IGraphicDesignerService _graphicDesignerService;

        public GraphicDesignersController(IGraphicDesignerService graphicDesignerService)
        {
            _graphicDesignerService = graphicDesignerService;
        }

        [HttpPost("Add")]
        public IActionResult Add(GraphicDesigner entity)
        {
            var result = _graphicDesignerService.Add(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _graphicDesignerService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _graphicDesignerService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(GraphicDesigner entity)
        {
            var result = _graphicDesignerService.Update(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _graphicDesignerService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _graphicDesignerService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetBySurnames")]
        public IActionResult GetBySurnames(string surname)
        {
            var result = _graphicDesignerService.GetBySurnames(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<GraphicDesigner, bool>>? filter = null)
        {
            var result = _graphicDesignerService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _graphicDesignerService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _graphicDesignerService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
