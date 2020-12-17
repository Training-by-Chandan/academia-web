using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Contracts;
using Academia.Web.Data;
using Academia.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia.Web.Service
{
    public class StudentService : IStudentService
    {
        private readonly AcademiaWebContext context;
        public StudentService(AcademiaWebContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(Student model)
        {
            try
            {
                await this.context.Students.AddAsync(model);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Student>> GetAlList()
        {
            try
            {
                return await this.context.Students.Include(p=>p.ParentStudents).ThenInclude(p=>p.Parent).ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Student> GetById(int id)
        {
            try
            {
                return await this.context.Students.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Edit(Student model)
        {
            try
            {
                var student = await this.context.Students.FindAsync(model.Id);
                if (student==null)
                {
                    return false;
                }
                else
                {
                    student.FirstName = model.FirstName;
                    student.LastName = model.LastName;
                    student.MiddleName = model.MiddleName;
                    student.Email = model.Email;
                    this.context.Entry<Student>(student).State = EntityState.Modified;
                    await this.context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var student = await this.context.Students.FindAsync(id);
                if (student!=null)
                {
                    this.context.Students.Remove(student);
                    await this.context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
