using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;

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
