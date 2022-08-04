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

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _graphicDirectorService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllBySurname")]
        public IActionResult GetAllBySurname(string surname)
        {
            var result = _graphicDirectorService.GetAllBySurname(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<GraphicDirector, bool>>? filter = null)
        {
            var result = _graphicDirectorService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _graphicDirectorService.GetAllByIsDeleted();
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
