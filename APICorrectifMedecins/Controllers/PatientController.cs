using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICorrectifMedecins.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientDTO>> GetAll()
        {
            return Ok(_patientService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<PatientDTO> GetById(string id)
        {
            PatientDTO patient = _patientService.GetById(id);

            return patient is not null ? Ok(patient) : NotFound();
        }

        [HttpPost]
        public ActionResult<PatientDTO> Create(PatientForm form)
        {
            PatientDTO patient = _patientService.Create(form);

            return patient is not null ? Ok(patient) : BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, PatientForm form) 
        {
            bool result = _patientService.Update(form);

            return result ? NoContent() : BadRequest();
        }

    }
}
