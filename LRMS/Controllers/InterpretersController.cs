using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterpretersController : ControllerBase
    {
        private readonly IInterpretersService _interpreterService;

        public InterpretersController(IInterpretersService interpreterService)
        {
            _interpreterService = interpreterService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Interpreters entity)
        {
            var result = _interpreterService.Add(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _interpreterService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _interpreterService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Interpreters entity)
        {
            var result = _interpreterService.Update(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _interpreterService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _interpreterService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetBySurnames")]
        public IActionResult GetBySurnames(string surname)
        {
            var result = _interpreterService.GetBySurnames(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByWhichToLanguageList")]
        public IActionResult GetByWhichToLanguageList(string langName)
        {
            var result = _interpreterService.GetByWhichToLanguageList(langName);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _interpreterService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _interpreterService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}