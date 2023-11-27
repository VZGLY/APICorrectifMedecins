using BLL.Models.DTO;
using BLL.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<DoctorDTO> GetAll();

        DoctorDTO GetById(int id);

        DoctorDTO GetByEmail(string email);

        DoctorDTO Create(DoctorForm form);

        bool Update(int id, DoctorForm form);

        bool Delete(int id);


    }
}
