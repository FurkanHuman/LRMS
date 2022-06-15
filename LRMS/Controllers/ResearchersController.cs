using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchersController : ControllerBase
    {
        private readonly IResearcherService _researcherService;

        public ResearchersController(IResearcherService researcherService)
        {
            _researcherService = researcherService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Researcher researcher)
        {
            var result = _researcherService.Add(researcher);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _researcherService.Delete(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _researcherService.ShadowDelete(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Researcher researcher)
        {
            var result = _researcherService.Update(researcher);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _researcherService.GetById(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<Researcher, bool>>? filter = null)
        {
            var result = _researcherService.GetAllByFilter(filter);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _researcherService.GetAllBySecrets();
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _researcherService.GetAll();
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }



























    }
}
