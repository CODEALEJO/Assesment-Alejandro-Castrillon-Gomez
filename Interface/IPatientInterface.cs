using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface
{
    public interface IPatientInterface
    {
        Task<Patient> Add(Patient patient);
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient> GetById(int id);
        Task Update(Patient patient);
        Task Delete(int id);

    }
}