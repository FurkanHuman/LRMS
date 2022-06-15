using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherPeoplesController : ControllerBase
    {
        private readonly IOtherPeopleService _otherPeopleService;

        public OtherPeoplesController(IOtherPeopleService otherPeopleService)
        {
            _otherPeopleService = otherPeopleService;
        }

        [HttpPost("Add")]
        public IActionResult Add(OtherPeople entity)
        {
            var result = _otherPeopleService.Add(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _otherPeopleService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _otherPeopleService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(OtherPeople entity)
        {
            var result = _otherPeopleService.Update(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _otherPeopleService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _otherPeopleService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetBySurnames")]
        public IActionResult GetBySurnames(string surname)
        {
            var result = _otherPeopleService.GetBySurnames(surname);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByTitles")]
        public IActionResult GetByTitles(string title)
        {
            var result = _otherPeopleService.GetByTitles(title);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNamePreAttach")]
        public IActionResult GetByNamePreAttach(string namePreAttach)
        {
            var result = _otherPeopleService.GetByNamePreAttach(namePreAttach);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<OtherPeople, bool>>? filter = null)
        {
            var result = _otherPeopleService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _otherPeopleService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _otherPeopleService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
