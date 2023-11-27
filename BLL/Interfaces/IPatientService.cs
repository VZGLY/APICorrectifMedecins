using BLL.Models.DTO;
using BLL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<PatientDTO> GetAll();

        PatientDTO GetById(string id);

        bool Update(PatientForm entity);


        PatientDTO Create(PatientForm entity);

    }
}
