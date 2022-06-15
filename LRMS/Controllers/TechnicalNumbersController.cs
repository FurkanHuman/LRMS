using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalNumbersController : ControllerBase
    {
        private readonly ITechnicalNumberService _technicalNumberService;

        public TechnicalNumbersController(ITechnicalNumberService technicalNumberService)
        {
            _technicalNumberService = technicalNumberService;
        }

        [HttpPost("Add")]
        public IActionResult Add(TechnicalNumber technicalNumber)
        {
            var result = _technicalNumberService.Add(technicalNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _technicalNumberService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _technicalNumberService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(TechnicalNumber technicalNumber)
        {
            var result = _technicalNumberService.Update(technicalNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _technicalNumberService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByBarcode")]
        public IActionResult GetByBarcode(long barcode)
        {
            var result = _technicalNumberService.GetByBarcode(barcode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByISBN")]
        public IActionResult GetByISBN(ulong isbn)
        {
            var result = _technicalNumberService.GetByISBN(isbn);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCertificateNum")]
        public IActionResult GetByCertificateNum(string certificateNum)
        {
            var result = _technicalNumberService.GetByCertificateNum(certificateNum);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<TechnicalNumber, bool>>? filter = null)
        {
            var result = _technicalNumberService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _technicalNumberService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _technicalNumberService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
