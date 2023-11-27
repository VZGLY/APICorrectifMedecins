using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DoctorDTO Doctor { get; set; }

        public PatientDTO Patient { get; set; }

        public string Desc { get; set; }

        public double Price { get; set; }
    }
}
