using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartographicMaterialsController : ControllerBase
    {
        private readonly ICartographicMaterialService _cartographicMaterialService;

        public CartographicMaterialsController(ICartographicMaterialService cartographicMaterialService)
        {
            _cartographicMaterialService = cartographicMaterialService;
        }
    }
}
