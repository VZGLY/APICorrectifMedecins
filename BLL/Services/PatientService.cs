using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PatientService : IPatientService
    {


        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public PatientDTO Create(PatientForm entity)
        {
            return _patientRepository.Create(entity.ToPatient()).ToDTO();
        }

        public IEnumerable<PatientDTO> GetAll()
        {
            return _patientRepository.GetAll().Select(x => x.ToDTO());
        }

        public PatientDTO GetById(string id)
        {
            return _patientRepository.GetById(id).ToDTO();
        }

        public bool Update(PatientForm entity)
        {
            return _patientRepository.Update(entity.ToPatient());
        }
    }
}
