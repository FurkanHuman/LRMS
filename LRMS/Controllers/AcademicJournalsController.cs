using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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

        [HttpPost("GetAllByAJNumber")]
        public IActionResult GetAllByAJNumber(ushort ajNumber)
        {
            var result = _academicJournalService.GetAllByAJNumber(ajNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCategories")]
        public IActionResult GetAllByCategories(int[] categoryIds)
        {
            var result = _academicJournalService.GetAllByCategories(categoryIds);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByDateOfYear")]
        public IActionResult GetAllByDateOfYear(ushort dateOfYear)
        {
            var result = _academicJournalService.GetAllByDateOfYear(dateOfYear);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByDescriptionFinder")]
        public IActionResult GetAllByDescriptionFinder(string description)
        {
            var result = _academicJournalService.GetAllByDescriptionFinder(description);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByDimension")]
        public IActionResult GetAllByDimension(Guid id)
        {
            var result = _academicJournalService.GetAllByDimension(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditor")]
        public IActionResult GetAllByEditor(Guid editorId)
        {
            var result = _academicJournalService.GetAllByEditor(editorId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditors")]
        public IActionResult GetAllByEditors(Guid[] editorId)
        {
            var result = _academicJournalService.GetAllByEditors(editorId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEMFile")]
        public IActionResult GetAllByEMFile(Guid id)
        {
            var result = _academicJournalService.GetAllByEMFile(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _academicJournalService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPageRange")]
        public IActionResult GetAllByPageRange(ushort min, ushort max)
        {
            var result = _academicJournalService.GetAllByPageRange(min, max);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisher")]
        public IActionResult GetAllByPublisher(Guid publisherId)
        {
            var result = _academicJournalService.GetAllByPublisher(publisherId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPublisherDateOfPublication")]
        public IActionResult GetAllByPublisherDateOfPublication(DateTime dateOfPublication)
        {
            var result = _academicJournalService.GetAllByPublisherDateOfPublication(dateOfPublication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByReferenceDate")]
        public IActionResult GetAllByReferenceDate(DateTime referenceDate)
        {
            var result = _academicJournalService.GetAllByReferenceDate(referenceDate);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByReferenceId")]
        public IActionResult GetAllByReferenceId(Guid referenceId)
        {
            var result = _academicJournalService.GetAllByReferenceId(referenceId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByReferenceOwner")]
        public IActionResult GetAllByReferenceOwner(Guid[] owner)
        {
            var result = _academicJournalService.GetAllByReferenceOwnerId(owner);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByResearcher")]
        public IActionResult GetAllByResearcher(Guid researcherId)
        {
            var result = _academicJournalService.GetAllByResearcher(researcherId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByResearchers")]
        public IActionResult GetAllByResearchers(Guid[] researcherIds)
        {
            var result = _academicJournalService.GetAllByResearchers(researcherIds);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByTechnicalPlaceholder")]
        public IActionResult GetAllByTechnicalPlaceholder(Guid id)
        {
            var result = _academicJournalService.GetAllByTechnicalPlaceholder(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByTitle")]
        public IActionResult GetAllByTitle(string title)
        {
            var result = _academicJournalService.GetAllByTitle(title);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByVolume")]
        public IActionResult GetAllByVolume(ushort volume)
        {
            var result = _academicJournalService.GetAllByVolume(volume);
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

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _academicJournalService.GetAllByIsDeleted();
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
