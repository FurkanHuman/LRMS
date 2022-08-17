using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Publisher publisher)
        {
            var result = _publisherService.Add(publisher);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _publisherService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _publisherService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Publisher publisher)
        {
            var result = _publisherService.Update(publisher);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _publisherService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _publisherService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressId")]
        public IActionResult GetByAddressId(Guid id)
        {
            var result = _publisherService.GetByAddressId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByAddressName")]
        public IActionResult GetAllByAddressName(string name)
        {
            var result = _publisherService.GetAllByAddressName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByAddressLine")]
        public IActionResult GetAllByAddressLine(string line)
        {
            var result = _publisherService.GetAllByAddressLine(line);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisherInCityId")]
        public IActionResult GetAllByPublisherInCityId(int id)
        {
            var result = _publisherService.GetAllByPublisherInCityId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisherInCityName")]
        public IActionResult GetAllByPublisherInCityName(string name)
        {
            var result = _publisherService.GetAllByPublisherInCityName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationId")]
        public IActionResult GetByCommunicationId(Guid id)
        {
            var result = _publisherService.GetByCommunicationId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationEmail")]
        public IActionResult GetByCommunicationEmail(string email)
        {
            var result = _publisherService.GetByCommunicationEmail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationFaxNumber")]
        public IActionResult GetByCommunicationFaxNumber(string faxNumber)
        {
            var result = _publisherService.GetByCommunicationFaxNumber(faxNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCommunicationName")]
        public IActionResult GetAllByCommunicationName(string name)
        {
            var result = _publisherService.GetAllByCommunicationName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationPhone")]
        public IActionResult GetByCommunicationPhone(string phone)
        {
            var result = _publisherService.GetByCommunicationPhone(phone);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationWebSites")]
        public IActionResult GetByCommunicationWebSite(string webSite)
        {
            var result = _publisherService.GetByCommunicationWebSite(webSite);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisherInCountryId")]
        public IActionResult GetAllByPublisherInCountryId(int id)
        {
            var result = _publisherService.GetAllByPublisherInCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisherInCountryName")]
        public IActionResult GetAllByPublisherInCountryName(string name)
        {
            var result = _publisherService.GetAllByPublisherInCountryName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisherInCountryCode")]
        public IActionResult GetAllByPublisherInCountryCode(string code)
        {
            var result = _publisherService.GetAllByPublisherInCountryCode(code);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisherInGeoLocation")]
        public IActionResult GetAllByPublisherInGeoLocation(string geoLocation)
        {
            var result = _publisherService.GetAllByPublisherInGeoLocation(geoLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisherInPostalCode")]
        public IActionResult GetAllByPublisherInPostalCode(string postalCode)
        {
            var result = _publisherService.GetAllByPublisherInPostalCode(postalCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByDateOfPublication")]
        public IActionResult GetAllByDateOfPublication(DateTime dateOfPublication)
        {
            var result = _publisherService.GetAllByDateOfPublication(dateOfPublication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByDateOfPublicationRange")]
        public IActionResult GetAllByDateOfPublicationRange(DateTime from, DateTime to)
        {
            var result = _publisherService.GetAllByDateOfPublicationMinMax(from, to);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Publisher, bool>>? filter = null)
        {
            var result = _publisherService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _publisherService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _publisherService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
