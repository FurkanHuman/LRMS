using Business.Abstract;
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

        [HttpPost("DtoAdd")]
        public IActionResult DtoAdd(CommunicationAddDto communicationAddDto)
        {
            var result = _communicationService.DtoAdd(communicationAddDto);
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

        [HttpPost("DtoUpdate")]
        public IActionResult DtoUpdate(CommunicationUpdateDto communicationUpdateDto)
        {
            var result = _communicationService.DtoUpdate(communicationUpdateDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _communicationService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetById")]
        public IActionResult DtoGetById(Guid id)
        {
            var result = _communicationService.DtoGetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _communicationService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByName")]
        public IActionResult DtoGetAllByName(string name)
        {
            var result = _communicationService.DtoGetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPhoneNumber")]
        public IActionResult GetByPhoneNumber(string phoneNumber)
        {
            var result = _communicationService.GetByPhoneNumber(phoneNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetByPhoneNumber")]
        public IActionResult DtoGetByPhoneNumber(string phoneNumber)
        {
            var result = _communicationService.DtoGetByPhoneNumber(phoneNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByFaxNumber")]
        public IActionResult GetByFaxNumber(string faxNumber)
        {
            var result = _communicationService.GetByFaxNumber(faxNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetByFaxNumber")]
        public IActionResult DtoGetByFaxNumber(string faxNumber)
        {
            var result = _communicationService.DtoGetByFaxNumber(faxNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEmail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _communicationService.GetByEmail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetByEmail")]
        public IActionResult DtoGetByEmail(string email)
        {
            var result = _communicationService.DtoGetByEmail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByWebSite")]
        public IActionResult GetByWebSite(string webSite)
        {
            var result = _communicationService.GetByWebSite(webSite);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetByWebSite")]
        public IActionResult DtoGetByWebSite(string webSite)
        {
            var result = _communicationService.DtoGetByWebSite(webSite);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Communication, bool>>? filter = null)
        {
            var result = _communicationService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByFilter")]
        public IActionResult DtoGetAllByFilter(Expression<Func<Communication, bool>>? filter = null)
        {
            var result = _communicationService.DtoGetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByIsDeleted")]
        public IActionResult GetAllByIsDeleted()
        {
            var result = _communicationService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult DtoGetAllByIsDeleted()
        {
            var result = _communicationService.DtoGetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _communicationService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAll")]
        public IActionResult DtoGetAll()
        {
            var result = _communicationService.DtoGetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
