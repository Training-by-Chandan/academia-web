using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Contracts;
using Academia.Web.ViewModel;

namespace Academia.Web.Controllers
{

    public class StudentParentController : Controller
    {
        private readonly IStudentParentService studentParentService;

        public StudentParentController(IStudentParentService studentParentService)
        {
            this.studentParentService = studentParentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!Request.Cookies.ContainsKey("Guid"))
            {
                Response.Cookies.Append("Guid",Guid.NewGuid().ToString());
            }
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentParentViewModel model)
        {

            var result = await this.studentParentService.Create(model);
          if (result)
          {
              return RedirectToAction("Index");
          }
          else
          {
            return View();
          }

        }
    }
}
