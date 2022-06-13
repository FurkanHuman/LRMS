using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphicDirectorsController : ControllerBase
    {
        private readonly IGraphicDirectorService _graphicDirectorService;

        public GraphicDirectorsController(IGraphicDirectorService graphicDirectorService)
        {
            _graphicDirectorService = graphicDirectorService;
        }

        [HttpPost("Add")]
        public IActionResult Add(GraphicDirector entity)
        {
            var result = _graphicDirectorService.Add(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _graphicDirectorService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _graphicDirectorService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(GraphicDirector entity)
        {
            var result = _graphicDirectorService.Update(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _graphicDirectorService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _graphicDirectorService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetBySurnames")]
        public IActionResult GetBySurnames(string surname)
        {
            var result = _graphicDirectorService.GetBySurnames(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByFilterLists")]
        public IActionResult GetByFilterLists(Expression<Func<GraphicDirector, bool>>? filter = null)
        {
            var result = _graphicDirectorService.GetByFilterLists(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _graphicDirectorService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            var result = _graphicDirectorService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
