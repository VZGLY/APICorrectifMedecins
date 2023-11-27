using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDTO ToDTO(this Appointment appointment, DoctorDTO doctor, PatientDTO patient)
        {
            return new AppointmentDTO
            {
                Id = appointment.Id,
                Date = appointment.Date,
                Desc = appointment.Desc,
                Price = appointment.Price,
                Doctor = doctor,
                Patient = patient
            };
        }

        public static Appointment ToAppointment(this AppointmentForm form)
        {
            return new Appointment
            {
                PatientId = form.PatientId,
                Id = 0,
                Date = form.Date,
                Desc = form.Desc,
                DoctorId = form.DoctorId,
                Price = form.Price,
            };
        }
    }
}
