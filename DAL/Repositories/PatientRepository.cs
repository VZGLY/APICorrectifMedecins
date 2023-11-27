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
    public class PatientRepository : Repository, IPatientRepository
    {
        public PatientRepository(string connectionString) : base(connectionString)
        {
        }

        public Patient? Create(Patient entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Patient VALUES( " +
                    "@RegNat, @Lastname, @Firstname, @Email, @Birthdate )";

                cmd.Parameters.AddWithValue("RegNat", entity.Id);
                cmd.Parameters.AddWithValue("Lastname", entity.Lastname);
                cmd.Parameters.AddWithValue("Firstname", entity.Firstname);
                cmd.Parameters.AddWithValue("Email", entity.Email);
                cmd.Parameters.AddWithValue("Birthdate", entity.Birthdate);

                return cmd.CustomNonQuery(ConnectionString) == 1 ? entity : null;
               
            }
        }

        public bool Delete(Patient entity)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Patient WHERE RegNat = @RegNat";

                cmd.Parameters.AddWithValue("RegNat", entity.Id);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            using(SqlCommand cmd = new SqlCommand()) 
            {
                cmd.CommandText = "Select * FROM Patient";

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToPatient(x));
            }
        }

        public Patient? GetById(string id)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Patient WHERE RegNat = @regnat";

                cmd.Parameters.AddWithValue("regnat", id);

                return cmd.CustomReader(ConnectionString, x => DbMapper.ToPatient(x)).SingleOrDefault();
            }
        }

        public bool Update(Patient entity)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Patient " +
                    "SET Firstname = @Firstname, " +
                    "Lastname = @Lastname, " +
                    "Email = @Email, " +
                    "Birthdate = @Birthdate " +
                    "WHERE RegNAt = @RegNat";

                cmd.Parameters.AddWithValue("Firstname", entity.Firstname);
                cmd.Parameters.AddWithValue("Lastname", entity.Lastname);
                cmd.Parameters.AddWithValue("Email", entity.Email);
                cmd.Parameters.AddWithValue("RegNat", entity.Id);
                cmd.Parameters.AddWithValue("Birthdate", entity.Birthdate);

                return cmd.CustomNonQuery(ConnectionString) == 1;
            }
        }
    }
}
