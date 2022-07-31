using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Object3DsController : ControllerBase
    {
        private readonly IObject3DService _object3DService;

        public Object3DsController(IObject3DService object3DService)
        {
            _object3DService = object3DService;
        }
    }
}
