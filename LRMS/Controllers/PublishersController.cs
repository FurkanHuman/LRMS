using Business.Abstract;
using Entities.Concrete.Infos;
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

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _publisherService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressId")]
        public IActionResult GetByAddressId(Guid id)
        {
            var result = _publisherService.GetByAddressId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressName")]
        public IActionResult GetByAddressName(string name)
        {
            var result = _publisherService.GetByAddressName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressLines")]
        public IActionResult GetByAddressLines(string line)
        {
            var result = _publisherService.GetByAddressLines(line);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPublisherInCityId")]
        public IActionResult GetByPublisherInCityId(int id)
        {
            var result = _publisherService.GetByPublisherInCityId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPublisherInCityName")]
        public IActionResult GetByPublisherInCityName(string name)
        {
            var result = _publisherService.GetByPublisherInCityName(name);
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

        [HttpPost("GetByCommunicationNames")]
        public IActionResult GetByCommunicationNames(string name)
        {
            var result = _publisherService.GetByCommunicationName(name);
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

        [HttpPost("GetByPublisherInCountryId")]
        public IActionResult GetByPublisherInCountryId(int id)
        {
            var result = _publisherService.GetByPublisherInCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPublisherInCountryName")]
        public IActionResult GetByPublisherInCountryName(string name)
        {
            var result = _publisherService.GetByPublisherInCountryName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPublisherInCountryCode")]
        public IActionResult GetByPublisherInCountryCode(string code)
        {
            var result = _publisherService.GetByPublisherInCountryCode(code);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPublisherInGeoLocation")]
        public IActionResult GetByPublisherInGeoLocation(string geoLocation)
        {
            var result = _publisherService.GetByPublisherInGeoLocation(geoLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPublisherInPostalCode")]
        public IActionResult GetByPublisherInPostalCode(string postalCode)
        {
            var result = _publisherService.GetByPublisherInPostalCode(postalCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDateOfPublication")]
        public IActionResult GetByDateOfPublication(DateTime dateOfPublication)
        {
            var result = _publisherService.GetByDateOfPublication(dateOfPublication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDateOfPublicationRange")]
        public IActionResult GetByDateOfPublicationRange(DateTime from, DateTime to)
        {
            var result = _publisherService.GetByDateOfPublicationMinMax(from, to);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByFilterLists")]
        public IActionResult GetByFilterLists(Expression<Func<Publisher, bool>>? filter = null)
        {
            var result = _publisherService.GetByFilterLists(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _publisherService.GetAllBySecrets();
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
