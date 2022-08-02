using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThesisesController : ControllerBase
    {
        private readonly IThesisService _thesisService;

        public ThesisesController(IThesisService thesisService)
        {
            _thesisService = thesisService;
        }
    }
}
