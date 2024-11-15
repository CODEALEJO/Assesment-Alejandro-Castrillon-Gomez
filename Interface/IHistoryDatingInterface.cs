using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface
{
    public interface IHistoryDatingInterface
    {
        Task<HistoryDating> Add(HistoryDating historyDating);
        Task<IEnumerable<HistoryDating>> GetAll();
        Task<HistoryDating> GetById(int id);
        Task Update(HistoryDating historyDating);
        Task Delete(int id);
        Task<IEnumerable<HistoryDating>> GetFiltered(int? patientId, DateTime? date, string reason);
    }
}