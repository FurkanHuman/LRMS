using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Branch branch)
        {
            var result = _branchService.Add(branch);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _branchService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(int id)
        {
            var result = _branchService.ShadowDelete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Branch branch)
        {
            var result = _branchService.Update(branch);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _branchService.GetByNames(name);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("GetByFilterLists")]
        public IActionResult GetByFilterLists(Expression<Func<Branch, bool>>? filter = null)
        {
            var result = _branchService.GetByFilterLists(filter);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _branchService.GetAllBySecrets();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _branchService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
