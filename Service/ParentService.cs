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
    public class ParentService : IParentService
    {
        private readonly AcademiaWebContext context;
        public ParentService(AcademiaWebContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(Parents model)
        {
            try
            {
                await this.context.Parents.AddAsync(model);
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Parents>> GetAlList()
        {
            try
            {
                return await this.context.Parents.Include(p=>p.ParentStudents).ThenInclude(p=>p.Student).ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Parents> GetById(int id)
        {
            try
            {
                return await this.context.Parents.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Edit(Parents model)
        {
            try
            {
                var parent = await this.context.Parents.FindAsync(model.Id);
                if (parent==null)
                {
                    return false;
                }
                else
                {
                    parent.FirstName = model.FirstName;
                    parent.LastName = model.LastName;
                    parent.MiddleName = model.MiddleName;
                    parent.PhoneNumber = model.PhoneNumber;
                    this.context.Entry<Parents>(parent).State = EntityState.Modified;
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
                var parents = await this.context.Parents.FindAsync(id);
                if (parents!=null)
                {
                    this.context.Parents.Remove(parents);
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
