using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpPost("Add")]
        public IActionResult Add(University university)
        {
            var result = _universityService.Add(university);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _universityService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _universityService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(University university)
        {
            var result = _universityService.Update(university);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _universityService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressId")]
        public IActionResult GetByAddressId(Guid id)
        {
            var result = _universityService.GetByAddressId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByBranchId")]
        public IActionResult GetByBranchId(int id)
        {
            var result = _universityService.GetByBranchId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByBranchNames")]
        public IActionResult GetByBranchNames(string name)
        {
            var result = _universityService.GetByBranchNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCityId")]
        public IActionResult GetByCityId(int id)
        {
            var result = _universityService.GetByCityId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCityNames")]
        public IActionResult GetByCityNames(string name)
        {
            var result = _universityService.GetByCityNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCountryId")]
        public IActionResult GetByCountryId(int id)
        {
            var result = _universityService.GetByCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCountryNames")]
        public IActionResult GetByCountryNames(string name)
        {
            var result = _universityService.GetByCountryNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByInstituteNames")]
        public IActionResult GetByInstituteNames(string name)
        {
            var result = _universityService.GetByInstituteNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<University, bool>>? filter = null)
        {
            var result = _universityService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _universityService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _universityService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
