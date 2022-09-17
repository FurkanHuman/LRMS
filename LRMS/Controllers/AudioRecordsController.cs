using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioRecordsController : ControllerBase
    {
        private readonly IAudioRecordService _audioRecordService;

        public AudioRecordsController(IAudioRecordService audioRecordService)
        {
            _audioRecordService = audioRecordService;
        }

        [HttpPost("Add")]
        public IActionResult Add(AudioRecord audioRecord)
        {
            var result = _audioRecordService.Add(audioRecord);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromForm] Guid id)
        {
            var result = _audioRecordService.Delete(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete([FromForm] Guid id)
        {
            var result = _audioRecordService.ShadowDelete(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(AudioRecord audioRecord)
        {
            var result = _audioRecordService.Update(audioRecord);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetById")]
        public IActionResult GetById([FromForm] Guid id)
        {
            var result = _audioRecordService.GetById(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByCategories")]
        public IActionResult GetAllByCategories([FromForm] int[] id)
        {
            var result = _audioRecordService.GetAllByCategories(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByDescriptionFinder")]
        public IActionResult GetAllByDescriptionFinder([FromForm] string description)
        {
            var result = _audioRecordService.GetAllByDescriptionFinder(description);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByDimension")]
        public IActionResult GetAllByDimension([FromForm] Guid dimension)
        {
            var result = _audioRecordService.GetAllByDimension(dimension);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByEMFile")]
        public IActionResult GetAllByEMFile([FromForm] Guid id)
        {
            var result = _audioRecordService.GetAllByEMFile(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName([FromForm] string names)
        {
            var result = _audioRecordService.GetAllByName(names);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByOwnerId")]
        public IActionResult GetAllByOwnerId([FromForm] Guid[] ids)
        {
            var result = _audioRecordService.GetAllByOwnerId(ids);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByPrice")]
        public IActionResult GetAllByPrice([FromForm] decimal price)
        {
            var result = _audioRecordService.GetAllByPrice(price);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByPriceMinMax")]
        public IActionResult GetAllByPriceMinMax([FromForm] decimal min, decimal max)
        {
            var result = _audioRecordService.GetAllByPrice(min, max);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByRecordDate")]
        public IActionResult GetAllByRecordDate([FromForm] DateTime recordDate)
        {
            var result = _audioRecordService.GetAllByRecordDate(recordDate);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByRecordDateMinMax")]
        public IActionResult GetAllByRecordDateMinMax([FromForm] DateTime min, DateTime max)
        {
            var result = _audioRecordService.GetAllByRecordDate(min, max);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByRecordingLength")]
        public IActionResult GetAllByRecordingLength([FromForm] float recordingLength)
        {
            var result = _audioRecordService.GetAllByRecordingLength(recordingLength);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByRecordingLengthMinMax")]
        public IActionResult GetAllByRecordingLengthMinMax([FromForm] float min, float max)
        {
            var result = _audioRecordService.GetAllByRecordingLength(min, max);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByTechnicalPlaceholder")]
        public IActionResult GetAllByTechnicalPlaceholder(Guid id)
        {
            var result = _audioRecordService.GetAllByTechnicalPlaceholder(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByTitle")]
        public IActionResult GetAllByTitle([FromForm] string title)
        {
            var result = _audioRecordService.GetAllByTitle(title);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetSecretLevel")]
        public IActionResult GetSecretLevel([FromForm] Guid id)
        {
            var result = _audioRecordService.GetSecretLevel(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetState")]
        public IActionResult GetState([FromForm] Guid id)
        {
            var result = _audioRecordService.GetState(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<AudioRecord, bool>>? filter = null)
        {
            var result = _audioRecordService.GetAllByFilter(filter);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _audioRecordService.GetAllByIsDeleted();
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _audioRecordService.GetAll();
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}