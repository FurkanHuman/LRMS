using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepictionsController : ControllerBase
    {
        private readonly IDepictionService _depictionService;

        public DepictionsController(IDepictionService depictionService)
        {
            _depictionService = depictionService;
        }
    }
}
