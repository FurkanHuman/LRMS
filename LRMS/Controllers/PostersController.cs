using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostersController : ControllerBase
    {
        private readonly IPosterService _posterService;

        public PostersController(IPosterService posterService)
        {
            _posterService = posterService;
        }
    }
}
