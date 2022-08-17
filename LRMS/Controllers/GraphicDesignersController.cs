using Business.Abstract;
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

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _graphicDesignerService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllBySurname")]
        public IActionResult GetAllBySurname(string surname)
        {
            var result = _graphicDesignerService.GetAllBySurname(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilter(Expression<Func<GraphicDesigner, bool>>? filter = null)
        {
            var result = _graphicDesignerService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _graphicDesignerService.GetAllByIsDeleted();
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
