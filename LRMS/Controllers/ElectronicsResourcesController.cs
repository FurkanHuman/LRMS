using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicsResourcesController : ControllerBase
    {
        private readonly IElectronicsResourceService _electronicsResourceService;

        public ElectronicsResourcesController(IElectronicsResourceService electronicsResourceService)
        {
            _electronicsResourceService = electronicsResourceService;
        }
    }
}
