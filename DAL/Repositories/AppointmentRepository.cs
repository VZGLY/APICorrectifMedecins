using DAL.Entities;
using DAL.Interfaces;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
using ToolBox.Services;

namespace DAL.Repositories
{
    public class AppointmentRepository : Repository, IAppointmentRepository
    {
        public AppointmentRepository(string connectionString) : base(connectionString)
        {
        }

        public Appointment? Create(Appointment entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Appointment OUTPUT inserted.id VALUES( " +
                    "@Date, @Doctor, @Patient, @Price, @Desc )";

                cmd.Parameters.AddWithValue("Date", entity.Date);
                cmd.Parameters.AddWithValue("Doctor", entity.DoctorId);
                cmd.Parameters.AddWithValue("Patient", entity.PatientId);
                cmd.Parameters.AddWithValue("Price", entity.Price);
                cmd.Parameters.AddWithValue("Desc", entity.Desc);

                entity.Id = Convert.ToInt32(cmd.CustomScalar(ConnectionString)) ;

                return entity;
            }
        }

        public bool Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Appointment";

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToAppointment(x));
            }
        }

        public IEnumerable<Appointment> GetByDoctor(int doctorId)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Appointment WHERE Doctor_Id = @id";

                cmd.Parameters.AddWithValue("id", doctorId);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToAppointment(x));
            }
        }

        public Appointment? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Appointment WHERE Id = @id";

                cmd.Parameters.AddWithValue("id", id);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToAppointment(x)).SingleOrDefault();
            }
        }

        public IEnumerable<Appointment> GetByPatient(string PatientRegNat)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Appointment WHERE Patient_Id = @id";

                cmd.Parameters.AddWithValue("id", PatientRegNat);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToAppointment(x));
            }
        }

        public bool Update(Appointment entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Appointment SET " +
                    "Doctor_ID = @DoctorId, " +
                    "Patient_ID = @PatientId, " +
                    "Date = @Date, " +
                    "Desc = @Desc, " +
                    "Price = @Price " +
                    "WHERE Id = @id";

                cmd.Parameters.AddWithValue("DoctorId", entity.DoctorId);
                cmd.Parameters.AddWithValue("PatientId", entity.PatientId);
                cmd.Parameters.AddWithValue("Date", entity.Date);
                cmd.Parameters.AddWithValue("Desc", entity.Desc);
                cmd.Parameters.AddWithValue("Price", entity.Price);
                cmd.Parameters.AddWithValue("id", entity.Id);
                cmd.Parameters.AddWithValue("DoctorId", entity.DoctorId);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}
