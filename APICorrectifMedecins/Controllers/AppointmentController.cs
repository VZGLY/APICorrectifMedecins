using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APICorrectifMedecins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppointmentDTO>> GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<AppointmentDTO> GetById(int id)
        {
            AppointmentDTO app = _appointmentService.GetById(id);

            return app is not null ? Ok(app) : NotFound();
        }

        [HttpGet("doctor/{id:int}")]
        public ActionResult<IEnumerable<AppointmentDTO>> GetByDoctor(int id) 
        {
          
            return Ok(_appointmentService.GetByDoctor(id));
        }

        [HttpGet("doctor")]
        public ActionResult<IEnumerable<AppointmentDTO>> GetByDoctor()
        {

            var docClaims = User.Claims;

            string docId = docClaims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;

            

            if (docId is null)
            {
                return NotFound();
            }

            int id;
            id = Convert.ToInt32(docId);

            return Ok(_appointmentService.GetByDoctor(id));
        }

        [HttpGet("patient/{id}")]
        public ActionResult<IEnumerable<AppointmentDTO>> GetByDoctor(string id)
        {

            return Ok(_appointmentService.GetByPatient(id));
        }

        [HttpPost]
        public ActionResult<AppointmentDTO> Create(AppointmentForm form)
        {
            AppointmentDTO app = _appointmentService.Create(form);

            return app is not null ? Ok(form) : NotFound();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, AppointmentForm form)
        {
            bool result = _appointmentService.Update(id, form);

            return result ? NoContent() : NotFound();
        }

    }
}
