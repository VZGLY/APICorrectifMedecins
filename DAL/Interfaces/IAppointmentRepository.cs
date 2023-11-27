using DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;

namespace DAL.Interfaces
{
    public interface IAppointmentRepository : IRepository<int, Appointment>
    {

        IEnumerable<Appointment> GetByDoctor(int doctorId);

        IEnumerable<Appointment> GetByPatient(string PatientRegNat);

    }
}
