using Business.Abstract;
using Entities.Concrete.Infos;
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

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string names)
        {
            var result = _consultantService.GetAllByName(names);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPost("GetAllBySurname")]
        public IActionResult GetBySurname(string surnames)
        {
            var result = _consultantService.GetAllBySurname(surnames);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByNamePreAttachment")]
        public IActionResult GetAllNamePreAttachment(string namePreAttachment)
        {
            var result = _consultantService.GetAllByNamePreAttachment(namePreAttachment);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Consultant, bool>>? filter = null)
        {
            var result = _consultantService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _consultantService.GetAllByIsDeleted();
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
