
using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentService(IAppointmentRepository appointmentRepository,
            IPatientService patientService,
            IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _patientService = patientService;
            _doctorService = doctorService;

        }


        public AppointmentDTO Create(AppointmentForm form)
        {
            Appointment appointment = _appointmentRepository.Create(form.ToAppointment());

            PatientDTO patient = _patientService.GetById(appointment.PatientId);

            DoctorDTO doctor = _doctorService.GetById(appointment.DoctorId);

            return appointment.ToDTO(doctor, patient);
        }

        public IEnumerable<AppointmentDTO> GetAll()
        {
            return _appointmentRepository.GetAll().Select(x =>
            {
                PatientDTO p = _patientService.GetById(x.PatientId);

                DoctorDTO d = _doctorService.GetById(x.DoctorId);

                return x.ToDTO(d, p);
            });
        }

        public IEnumerable<AppointmentDTO> GetByDoctor(int id)
        {
            return _appointmentRepository.GetByDoctor(id).Select(x =>
            {
                PatientDTO p = _patientService.GetById(x.PatientId);

                DoctorDTO d = _doctorService.GetById(x.DoctorId);

                return x.ToDTO(d, p);
            });
        }

        public AppointmentDTO GetById(int id)
        {
            Appointment app = _appointmentRepository.GetById(id);

            DoctorDTO doc = _doctorService.GetById(app.DoctorId);

            PatientDTO pat = _patientService.GetById(app.PatientId);

            return app.ToDTO(doc, pat);
        }

        public IEnumerable<AppointmentDTO> GetByPatient(string id)
        {
            return _appointmentRepository.GetByPatient(id).Select(x =>
            {
                PatientDTO p = _patientService.GetById(x.PatientId);

                DoctorDTO d = _doctorService.GetById(x.DoctorId);

                return x.ToDTO(d, p);
            });
        }

        public bool Update(int id, AppointmentForm form)
        {
            Appointment app = form.ToAppointment();
            app.Id = id;
            return _appointmentRepository.Update(app);
        }
    }
}
