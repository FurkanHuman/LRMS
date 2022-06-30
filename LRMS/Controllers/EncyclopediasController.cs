using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncyclopediasController : ControllerBase
    {
        private readonly IEncyclopediaService _encyclopediaService;
    }
}
