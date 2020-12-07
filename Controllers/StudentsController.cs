using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academia.Web.Data;
using Academia.Web.ViewModel;

namespace Academia.Web.Controllers
{
    [Route("data-student")]
    public class StudentsController : Controller
    {
        private readonly AcademiaWebContext _context;
        private readonly AcademiaWebContext1 _context1;
        private readonly AcademiaWebContext2 _context2;
        private readonly AcademiaWebContext3 _context3;
        private readonly AcademiaWebContext4 _context4=new AcademiaWebContext4(null);

        public StudentsController(AcademiaWebContext context, AcademiaWebContext1 context1, AcademiaWebContext2 context2, AcademiaWebContext3 context3)
        {
            _context = context;
            _context1 = context1;
            _context2 = context2;
            _context3 = context3;
           
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            List<DropDownItem> items = new List<DropDownItem>();
            items.Add(new DropDownItem { Href = "#", ItemName = "One" });
            items.Add(new DropDownItem { Href = "#", ItemName = "Two" });
            items.Add(new DropDownItem { Href = "#", ItemName = "Three" });
            items.Add(new DropDownItem { Href = "https://google.com", ItemName = "Google" });
            DropDownViewModel drop = new DropDownViewModel() { Id="dropdown", Name="My DropDown", Items=items};

            ViewBag.Drop = drop;

            return View(await _context.Student.ToListAsync());
        }

        [Route("details/{id}")]
        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [Route("create")]
        // GET: Students/Create
        public IActionResult Create()
        {
            Func1();

            ///.....
            Func2();


            ////
            ///
            _context3.Add(null);
            return View();
        }

        private void Func1()
        {
            _context1.Add(null);
        }
        private void Func2()
        {
            _context2.Add(null);
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Password,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        [Route("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Password,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [Route("delete")]
        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [Route("delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
