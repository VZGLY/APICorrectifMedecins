using BLL.Interfaces;
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
    public class AuthService : IAuthService
    {
        private readonly IDoctorRepository _doctorRepository;

        public AuthService(IDoctorRepository docRepo)
        {
            _doctorRepository = docRepo;
        }

        public Doctor? Login(LoginForm form)
        {
            Doctor? doctor = _doctorRepository.GetByEmail(form.Email);

            if (doctor is null)
            {
                return null;
            }

            if (BCrypt.Net.BCrypt.Verify(form.Password, doctor.Password))
            {
                return doctor;
            }

            return null;
        }
    }
}
