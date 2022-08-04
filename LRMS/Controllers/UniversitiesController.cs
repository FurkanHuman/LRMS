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

        [HttpPost("GetAllByBranchId")]
        public IActionResult GetAllByBranchId(int id)
        {
            var result = _universityService.GetAllByBranchId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByBranchName")]
        public IActionResult GetAllByBranchName(string name)
        {
            var result = _universityService.GetAllByBranchName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCityId")]
        public IActionResult GetAllByCityId(int id)
        {
            var result = _universityService.GetAllByCityId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCityName")]
        public IActionResult GetAllByCityNames(string name)
        {
            var result = _universityService.GetAllByCityName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCountryId")]
        public IActionResult GetAllByCountryId(int id)
        {
            var result = _universityService.GetAllByCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCountryName")]
        public IActionResult GetAllByCountryName(string name)
        {
            var result = _universityService.GetAllByCountryName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByInstituteName")]
        public IActionResult GetAllByInstituteName(string name)
        {
            var result = _universityService.GetAllByInstituteName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<University, bool>>? filter = null)
        {
            var result = _universityService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _universityService.GetAllByIsDeleted();
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
