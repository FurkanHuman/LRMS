using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantService _consultantService;

        public ConsultantsController(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Consultant consultant)
        {
            var result = _consultantService.Add(consultant);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _consultantService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _consultantService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Consultant consultant)
        {
            var result = _consultantService.Update(consultant);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _consultantService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string names)
        {
            var result = _consultantService.GetByNames(names);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPost("GetBySurnames")]
        public IActionResult GetBySurnames(string surnames)
        {
            var result = _consultantService.GetBySurnames(surnames);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetNamePreAttachmentLists")]
        public IActionResult GetNamePreAttachmentLists(string namePreAttachment)
        {
            var result = _consultantService.GetNamePreAttachmentLists(namePreAttachment);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByFilterLists")]
        public IActionResult GetAllByFilterLists(Expression<Func<Consultant, bool>>? filter = null)
        {
            var result = _consultantService.GetByFilterLists(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _consultantService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _consultantService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
