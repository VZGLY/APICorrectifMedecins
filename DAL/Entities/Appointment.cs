using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Services;

namespace DAL.Entities
{
    public class Appointment : IEntity<int>
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int DoctorId { get; set; }

        public string PatientId { get; set; }

        public string Desc { get; set; }

        public double Price { get; set; }
    }
}
