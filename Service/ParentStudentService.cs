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
    public class ParentStudentService : IParentStudentService
    {
        private readonly AcademiaWebContext context;
        public ParentStudentService(AcademiaWebContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(ParentStudent model)
        {
            try
            {
                await this.context.ParentStudents.AddAsync(model);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<ParentStudent>> GetAlList()
        {
            try
            {
                return await this.context.ParentStudents.Include(p=>p.Parent).Include(p=>p.Student).ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ParentStudent> GetById(int id)
        {
            try
            {
                return await this.context.ParentStudents.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Edit(ParentStudent model)
        {
            try
            {
                var parentStudent = await this.context.ParentStudents.FindAsync(model.Id);
                if (parentStudent==null)
                {
                    return false;
                }
                else
                {
                   parentStudent.ParentId=model.ParentId;
                   parentStudent.StudentId=model.StudentId;
                    this.context.Entry<ParentStudent>(parentStudent).State = EntityState.Modified;
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
                var parentStudent = await this.context.ParentStudents.FindAsync(id);
                if (parentStudent!=null)
                {
                    this.context.ParentStudents.Remove(parentStudent);
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
