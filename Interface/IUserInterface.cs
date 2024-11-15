using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment_Alejandro_Castrillon_Gomez_bernslee.Models;

namespace Assesment_Alejandro_Castrillon_Gomez_bernslee.Interface;
public interface IUserInterface
{
    Task Register(User user);
    Task<User> Add(User user);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task Update(User user);
    Task Delete(int id);
}