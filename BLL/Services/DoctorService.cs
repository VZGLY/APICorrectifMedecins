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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public DoctorDTO Create(DoctorForm form)
        {
            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            form.Email = form.Email.ToLower();
            return _doctorRepository.Create(form.ToDoctor()).ToDTO();
        }

        public bool Delete(int id)
        {
            Doctor? doctor = _doctorRepository.GetById(id);

            if (doctor is null)
            {
                return false;
            }
            return _doctorRepository.Delete(doctor);
        }

        public IEnumerable<DoctorDTO> GetAll()
        {
            return _doctorRepository.GetAll().Select(x => x.ToDTO());
        }

        public DoctorDTO GetByEmail(string email)
        {
            email = email.ToLower();
            return _doctorRepository.GetByEmail(email).ToDTO();
        }

        public DoctorDTO GetById(int id)
        {
            return _doctorRepository.GetById(id).ToDTO();
        }

        public bool Update(int id, DoctorForm form)
        {
            form.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
            form.Email = form.Email.ToLower();

            Doctor doc = form.ToDoctor();

            doc.Id = id;

            return _doctorRepository.Update(doc);
        }
    }
}
