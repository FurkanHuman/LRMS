using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationsController : ControllerBase
    {
        private readonly ICommunicationService _communicationService;

        public CommunicationsController(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Communication communication)
        {
            var result = _communicationService.Add(communication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _communicationService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _communicationService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Communication communication)
        {
            var result = _communicationService.Update(communication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _communicationService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _communicationService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPhoneNumber")]
        public IActionResult GetByPhoneNumber(string phoneNumber)
        {
            var result = _communicationService.GetByPhoneNumber(phoneNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByFaxNumber")]
        public IActionResult GetByFaxNumber(string faxNumber)
        {
            var result = _communicationService.GetByFaxNumber(faxNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEmail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _communicationService.GetByEmail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByWebSite")]
        public IActionResult GetByWebSite(string webSite)
        {
            var result = _communicationService.GetByWebSite(webSite);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Communication, bool>>? filter = null)
        {
            var result = _communicationService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecret")]
        public IActionResult GetAllBySecret()
        {
            var result = _communicationService.GetAllBySecret();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _communicationService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
