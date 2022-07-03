using Business.Abstract;
using Entities.Concrete;
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

        [HttpPost("GetByCategories")]
        public IActionResult GetByCategories([FromForm] int[] id)
        {
            var result = _audioRecordService.GetByCategories(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByDescriptionFinder")]
        public IActionResult GetByDescriptionFinder([FromForm] string description)
        {
            var result = _audioRecordService.GetByDescriptionFinder(description);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByDimension")]
        public IActionResult GetByDimension([FromForm] Guid dimension)
        {
            var result = _audioRecordService.GetByDimension(dimension);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByEMFiles")]
        public IActionResult GetByEMFiles([FromForm] Guid id)
        {
            var result = _audioRecordService.GetByEMFiles(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames([FromForm] string names)
        {
            var result = _audioRecordService.GetByNames(names);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByOwnerNames")]
        public IActionResult GetByOwnerNames([FromForm] string names)
        {
            var result = _audioRecordService.GetByOwnerNames(names);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByPrice")]
        public IActionResult GetByPrice([FromForm] decimal price)
        {
            var result = _audioRecordService.GetByPrice(price);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByPriceMinMax")]
        public IActionResult GetByPriceMinMax([FromForm] decimal min, decimal max)
        {
            var result = _audioRecordService.GetByPrice(min, max);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByRecordDate")]
        public IActionResult GetByRecordDate([FromForm] DateTime recordDate)
        {
            var result = _audioRecordService.GetByRecordDate(recordDate);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByRecordDateMinMax")]
        public IActionResult GetByRecordDateMinMax([FromForm] DateTime min, DateTime max)
        {
            var result = _audioRecordService.GetByRecordDate(min, max);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByRecordingLength")]
        public IActionResult GetByRecordingLength([FromForm] float recordingLength)
        {
            var result = _audioRecordService.GetByRecordingLength(recordingLength);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByRecordingLengthMinMax")]
        public IActionResult GetByRecordingLengthMinMax([FromForm] float min, float max)
        {
            var result = _audioRecordService.GetByRecordingLength(min, max);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("GetByTechnicalPlaceholders")]
        public IActionResult GetByTechnicalPlaceholders(Guid id)
        {
            var result = _audioRecordService.GetByTechnicalPlaceholders(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByTitles")]
        public IActionResult GetByTitles([FromForm] string titles)
        {
            var result = _audioRecordService.GetByTitles(titles);
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

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _audioRecordService.GetAllBySecrets();
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