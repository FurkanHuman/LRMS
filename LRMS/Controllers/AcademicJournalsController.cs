using Business.Abstract;
using Entities.Concrete;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Entities.Concrete.Infos;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicJournalsController : ControllerBase
    {
        private readonly IAcademicJournalService _academicJournalService;

        public AcademicJournalsController(IAcademicJournalService academicJournalService)
        {
            _academicJournalService = academicJournalService;
        }

        [HttpPost("Add")]
        public IActionResult Add(AcademicJournal academicJournal)
        {
            var result = _academicJournalService.Add(academicJournal);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _academicJournalService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _academicJournalService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(AcademicJournal academicJournal)
        {
            var result = _academicJournalService.Update(academicJournal);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _academicJournalService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAJNumber")]
        public IActionResult GetByAJNumber(ushort ajNumber)
        {
            var result = _academicJournalService.GetByAJNumber(ajNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCategories")]
        public IActionResult GetByCategories(int[] categoryIds)
        {
            var result = _academicJournalService.GetByCategories(categoryIds);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDateOfYear")]
        public IActionResult GetByDateOfYear(ushort dateOfYear)
        {
            var result = _academicJournalService.GetByDateOfYear(dateOfYear);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDescriptionFinder")]
        public IActionResult GetByDescriptionFinder(string description)
        {
            var result = _academicJournalService.GetByDescriptionFinder(description);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDimension")]
        public IActionResult GetByDimension(Guid id)
        {
            var result = _academicJournalService.GetByDimension(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditor")]
        public IActionResult GetByEditor(Guid editorId)
        {
            var result = _academicJournalService.GetByEditor(editorId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditor")]
        public IActionResult GetByEditor(Guid[] editorId)
        {
            var result = _academicJournalService.GetByEditor(editorId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEMFiles")]
        public IActionResult GetByEMFiles(Guid id)
        {
            var result = _academicJournalService.GetByEMFiles(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _academicJournalService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPageRange")]
        public IActionResult GetByPageRange(ushort min, ushort max)
        {
            var result = _academicJournalService.GetByPageRange(min, max);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPublisher")]
        public IActionResult GetByPublisher(Guid publisherId)
        {
            var result = _academicJournalService.GetByPublisher(publisherId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByPublisherDateOfPublication")]
        public IActionResult GetByPublisherDateOfPublication(DateTime dateOfPublication)
        {
            var result = _academicJournalService.GetByPublisherDateOfPublication(dateOfPublication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByReferenceDate")]
        public IActionResult GetByReferenceDate(DateTime referenceDate)
        {
            var result = _academicJournalService.GetByReferenceDate(referenceDate);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByReferenceId")]
        public IActionResult GetByReferenceId(Guid referenceId)
        {
            var result = _academicJournalService.GetByReferenceId(referenceId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByReferenceOwner")]
        public IActionResult GetByReferenceOwner(string owner)
        {
            var result = _academicJournalService.GetByReferenceOwner(owner);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByResearcher")]
        public IActionResult GetByResearcher(Guid researcherId)
        {
            var result = _academicJournalService.GetByResearcher(researcherId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByResearcher")]
        public IActionResult GetByResearcher(Guid[] researcherId)
        {
            var result = _academicJournalService.GetByResearcher(researcherId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByTitles")]
        public IActionResult GetByTitles(string title)
        {
            var result = _academicJournalService.GetByTitles(title);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByVolume")]
        public IActionResult GetByVolume(ushort volume)
        {
            var result = _academicJournalService.GetByVolume(volume);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPost("GetSecretLevel")]
        public IActionResult GetSecretLevel(Guid id)
        {
            var result = _academicJournalService.GetSecretLevel(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetState")]
        public IActionResult GetState(Guid id)
        {
            var result = _academicJournalService.GetState(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<AcademicJournal, bool>>? filter = null)
        {
            var result = _academicJournalService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _academicJournalService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _academicJournalService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
