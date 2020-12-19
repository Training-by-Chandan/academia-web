using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Models;

namespace Academia.Web.Contracts
{
    public interface IParentStudentService
    {
        Task<bool> Create(ParentStudent model);
        Task<List<ParentStudent>> GetAlList();
        Task<ParentStudent> GetById(int id);
        Task<bool> Edit(ParentStudent model);
        Task<bool> Delete(int id);
    }
}
