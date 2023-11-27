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
    public static class PatientMapper
    {
        public static Patient ToPatient(this PatientForm form)
        {
            return new Patient
            {
                Id = form.Id,
                Birthdate = form.Birthdate,
                Email = form.Email,
                Firstname = form.Firstname,
                Lastname = form.Lastname,
            };
        }

        public static PatientDTO ToDTO(this Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                Birthdate = patient.Birthdate,
                Email = patient.Email,
                Firstname = patient.Firstname,
                Lastname = patient.Lastname,
            };
        }
    }
}
