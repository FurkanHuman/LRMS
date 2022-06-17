using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSeriesController : ControllerBase
    {
        private readonly IBookSeriesService _bookSeriesService;

        public BookSeriesController(IBookSeriesService bookSeriesService)
        {
            _bookSeriesService = bookSeriesService;
        }
    }
}
