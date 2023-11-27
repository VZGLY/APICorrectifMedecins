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
    public class DoctorRepository : Repository, IDoctorRepository
    {
        public DoctorRepository(string connectionString) : base(connectionString)
        {
        }

        public Doctor? Create(Doctor entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Doctor OUTPUT inserted.id VALUES(" +
                    " @Email , " +
                    " @Lastname , " +
                    " @Firstname , " +
                    " @Password , " +
                    " @Address )";

                cmd.Parameters.AddWithValue("Email", entity.Email);
                cmd.Parameters.AddWithValue("Password", entity.Password);
                cmd.Parameters.AddWithValue("Firstname", entity.Firstname);
                cmd.Parameters.AddWithValue("Lastname", entity.Lastname);
                cmd.Parameters.AddWithValue("Address", entity.Address);

                entity.Id = Convert.ToInt32(cmd.CustomScalar(ConnectionString));

                return entity;
            }
        }

        public bool Delete(Doctor entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Doctor WHERE id = @id";

                cmd.Parameters.AddWithValue("Id", entity.Id);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Doctor";

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToDoctor(x));
            }
        }

        public Doctor? GetByEmail(string email)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * FROM Doctor WHERE Email = @Email";

                cmd.Parameters.AddWithValue("Email", email);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToDoctor(x)).SingleOrDefault();
            }
        }

        public Doctor? GetById(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * FROM Doctor WHERE Id = @Id";

                cmd.Parameters.AddWithValue("Id", id);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToDoctor(x)).SingleOrDefault();
            }
        }

        public bool Update(Doctor entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Doctor " +
                    "Set Email = @Email, " +
                    "Password = @Password, " +
                    "Firstname = @Firstname, " +
                    "Lastname = @Lastname, " +
                    "Address = @Address " +
                    "WHERE id = @id";

                cmd.Parameters.AddWithValue("Id", entity.Id);
                cmd.Parameters.AddWithValue("Email", entity.Email);
                cmd.Parameters.AddWithValue("Firstname", entity.Firstname);
                cmd.Parameters.AddWithValue("Lastname", entity.Lastname);
                cmd.Parameters.AddWithValue("Password", entity.Password);
                cmd.Parameters.AddWithValue("Address", entity.Address);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}
