using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncyclopediasController : ControllerBase
    {
        private readonly IEncyclopediaService _encyclopediaService;

        public EncyclopediasController(IEncyclopediaService encyclopediaService)
        {
            _encyclopediaService = encyclopediaService;
        }
    }
}
