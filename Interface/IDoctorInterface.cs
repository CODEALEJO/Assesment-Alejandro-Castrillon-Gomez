using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface
{
    public interface IDoctorInterface
    {
        Task<Doctor> Add(Doctor doctor);
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> GetById(int id);
        Task<Doctor> Update(Doctor doctor); 
        Task Delete(int id);
    }

}