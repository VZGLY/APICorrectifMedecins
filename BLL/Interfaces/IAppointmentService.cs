using BLL.Models.DTO;
using BLL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAppointmentService
    {

        AppointmentDTO Create(AppointmentForm form);

        bool Update(int id, AppointmentForm form);

        IEnumerable<AppointmentDTO> GetAll();

        IEnumerable<AppointmentDTO> GetByDoctor(int id);

        IEnumerable<AppointmentDTO> GetByPatient(string id);

        AppointmentDTO GetById(int id);



    }
}
