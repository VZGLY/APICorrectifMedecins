using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms
{
    public class AppointmentForm
    {
        public DateTime Date { get; set; }

        public int DoctorId { get; set; }

        public string PatientId { get; set; }

        public string Desc { get; set; }

        public double Price { get; set; }
    }
}
