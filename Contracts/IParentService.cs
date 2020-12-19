using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Models;

namespace Academia.Web.Contracts
{
    public interface IParentService
    {
        Task<bool> Create(Parents model);
        Task<List<Parents>> GetAlList();
        Task<Parents> GetById(int id);
        Task<bool> Edit(Parents model);
        Task<bool> Delete(int id);
    }
}
