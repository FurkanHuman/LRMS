using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private readonly IReferenceService _referenceService;

        public ReferencesController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Reference reference)
        {
            var result = _referenceService.Add(reference);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _referenceService.Delete(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _referenceService.ShadowDelete(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Reference reference)
        {
            var result = _referenceService.Update(reference);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _referenceService.GetById(id);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _referenceService.GetAllByName(name);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByOwner")]
        public IActionResult GetAllByOwner(string ownerStr)
        {
            var result = _referenceService.GetAllByOwner(ownerStr);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByReferenceDate")]
        public IActionResult GetAllByReferenceDate(DateTime referenceDate)
        {
            var result = _referenceService.GetAllByReferenceDate(referenceDate);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("GetAllBySubText")]
        public IActionResult GetAllBySubText(string subText)
        {
            var result = _referenceService.GetAllBySubText(subText);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Reference, bool>>? filter = null)
        {
            var result = _referenceService.GetAllByFilter(filter);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            var result = _referenceService.GetAll();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
    }
}
