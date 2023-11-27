using BLL.Interfaces;
using BLL.Models.DTO;
using BLL.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace APICorrectifMedecins.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorDTO>> GetAll()
        {
            return Ok(_doctorService.GetAll()) ;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByID(int id) 
        { 
            DoctorDTO doctor = _doctorService.GetById(id);

            return doctor == null ? NotFound() : Ok(doctor);
        }

        [HttpGet("{email}")]
        public IActionResult GetByEmail(string email)
        {
            DoctorDTO doctor = _doctorService.GetByEmail(email);

            return doctor == null ? NotFound() : Ok(doctor);
        }

        [HttpPost]
        public ActionResult<DoctorDTO> Create(DoctorForm form) 
        { 
            DoctorDTO doctor = _doctorService.Create(form);

            return doctor == null ? BadRequest() : Ok(doctor);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, DoctorForm form)
        {
            bool result = _doctorService.Update(id, form);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            bool result = _doctorService.Delete(id);

            return result ? NoContent() : BadRequest();
        }
    }
}
