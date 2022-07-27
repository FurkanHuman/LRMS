using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicalNotesController : ControllerBase
    {
        private readonly IMusicalNoteService _musicalNoteService;

        public MusicalNotesController(IMusicalNoteService musicalNoteService)
        {
            _musicalNoteService = musicalNoteService;
        }
    }
}
