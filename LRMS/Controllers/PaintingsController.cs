using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintingsController : ControllerBase
    {
        private readonly IPaintingService _paintingService;

        public PaintingsController(IPaintingService paintingService)
        {
            _paintingService = paintingService;
        }
    }
}
