using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitsController : ControllerBase
    {
        private readonly IKitService _kitService;

        public KitsController(IKitService kitService)
        {
            _kitService = kitService;
        }
    }
}
