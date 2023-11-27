using DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class DbMapper
    {
        public static Doctor ToDoctor(this SqlDataReader reader)
        {
            return new Doctor
            {
                Id = Convert.ToInt32(reader["Id"]),
                Email = reader["Email"].ToString(),
                Lastname = reader["Lastname"].ToString(),
                Firstname = reader["Firstname"] == DBNull.Value ? null : reader["Firstname"].ToString(),
                Password = reader["Password"].ToString(),
                Address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString()
            };
        }

        public static Patient ToPatient(this SqlDataReader reader)
        {
            return new Patient
            {
                Id = reader["RegNat"].ToString(),
                Birthdate = Convert.ToDateTime(reader["Birthdate"]),
                Lastname = reader["Lastname"].ToString(),
                Firstname = reader["Firstname"] == DBNull.Value ? null : reader["Firstname"].ToString(),
                Email = reader["Email"].ToString()
            };
        }

        public static Appointment ToAppointment(this SqlDataReader reader)
        {
            return new Appointment
            {
                Id = Convert.ToInt32(reader["Id"]),
                Date = Convert.ToDateTime(reader["Date"]),
                Desc = reader["Description"].ToString(),
                DoctorId = Convert.ToInt32(reader["Doctor_Id"]),
                PatientId = reader["Patient_RegNat"].ToString(),
                Price = Convert.ToDouble(reader["Price"])
            };
        }

    }
}
