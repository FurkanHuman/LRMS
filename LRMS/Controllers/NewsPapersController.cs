using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsPapersController : ControllerBase
    {
        private readonly INewsPaperService _newsPaperService;

        public NewsPapersController(INewsPaperService newsPaperService)
        {
            _newsPaperService = newsPaperService;
        }
    }
}
