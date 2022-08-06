using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicroformsController : ControllerBase
    {
        private readonly IMicroformService _microformService;

        public MicroformsController(IMicroformService microformService)
        {
            _microformService = microformService;
        }
    }
}
