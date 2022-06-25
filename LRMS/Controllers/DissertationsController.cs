using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DissertationsController : ControllerBase
    {
        private readonly IDissertationService _dissertationService;

        public DissertationsController(IDissertationService dissertationService)
        {
            _dissertationService = dissertationService;
        }
    }
}
