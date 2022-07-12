using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphicalImagesController : ControllerBase
    {
        private readonly IGraphicalImageService _graphicalImageService;

        public GraphicalImagesController(IGraphicalImageService graphicalImageService)
        {
            _graphicalImageService = graphicalImageService;
        }
    }
}
