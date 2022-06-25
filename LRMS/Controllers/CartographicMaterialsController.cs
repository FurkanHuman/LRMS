using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

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
