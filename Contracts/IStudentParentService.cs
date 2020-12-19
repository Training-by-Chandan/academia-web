using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.ViewModel;

namespace Academia.Web.Contracts
{
    public interface IStudentParentService
    {
        Task<bool> Create(StudentParentViewModel model);
    }
}
