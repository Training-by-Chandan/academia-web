using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Contracts;
using Academia.Web.Data;
using Academia.Web.Models;

namespace Academia.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var students = await this.studentService.GetAlList();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var student = await this.studentService.GetById(Id);
            if (student!=null)
            {
                return View(student);
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student model)
        {
            var result = await this.studentService.Edit(model);
            if (result)
            {
                //everything is ok and edited successfully
                return RedirectToAction("Index");
            }
            else
            {
                //editing failed
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id, bool confirm)
        {
            ViewBag.Id = Id;
            if (confirm)
            {
                var result=await this.studentService.Delete(Id);
                 
                return RedirectToAction("Index");
            }
            return View();
        }

        
         

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var student=await this.studentService.GetById(Id);
            if(student!=null)
            {

                return View(student);
            }
            else{
                 return View("Error", new ErrorViewModel());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            var result=await this.studentService.Create(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else{
                return View(model);
            }
        }
    }
}
