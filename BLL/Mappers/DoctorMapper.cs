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
    public static class DoctorMapper
    {
        public static Doctor ToDoctor(this DoctorForm form)
        {
            return new Doctor
            {
                Id = 0,
                Address = form.Address,
                Email = form.Email,
                Firstname = form.Firstname,
                Lastname = form.Lastname,
                Password = form.Password
            };
        }

        public static DoctorDTO ToDTO(this Doctor entity)
        {
            return new DoctorDTO
            {
                Id = entity.Id,
                Address = entity.Address,
                Email = entity.Email,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname
            };
        }
    }
}
