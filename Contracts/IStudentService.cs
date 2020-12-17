using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Models;

namespace Academia.Web.Contracts
{
    public interface IStudentService
    {
        Task<bool> Create(Student model);
        Task<List<Student>> GetAlList();
        Task<Student> GetById(int id);
        Task<bool> Edit(Student model);
        Task<bool> Delete(int id);
    }
}
