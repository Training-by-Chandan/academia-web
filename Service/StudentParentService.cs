using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Contracts;
using Academia.Web.Data;
using Academia.Web.Models;
using Academia.Web.ViewModel;

namespace Academia.Web.Service
{
    public class StudentParentService: IStudentParentService
    {
        private readonly AcademiaWebContext _context;
        public StudentParentService(AcademiaWebContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(StudentParentViewModel model)
        {
            try
            {
                //Create Student
                Student s=new Student();
                s.FirstName = model.StudentFirstName;
                s.LastName = model.StudentLastName;
                s.MiddleName = model.StudentMiddleName;
                s.Email = model.StudentEmail;
                var studentres=await this._context.Students.AddAsync(s);
                

                //Create Father
                var father=new Parents();
                father.FirstName = model.FatherFirstName;
                father.LastName = model.FatherLastName;
                father.MiddleName = model.FatherMiddleName;
                father.PhoneNumber = model.FatherPhoneNumber;
                father.GuardianType = GuardianType.Father;
                var fatherres=await this._context.Parents.AddAsync(father);

                //Create Mother
                var mother = new Parents();
                mother.FirstName = model.MotherFirstName;
                mother.LastName = model.MotherLastName;
                mother.MiddleName = model.MotherMiddleName;
                mother.PhoneNumber = model.MotherPhoneNumber;
                mother.GuardianType = GuardianType.Mother;
                var motherres=await this._context.Parents.AddAsync(mother);


                //commit the changes
                await this._context.SaveChangesAsync();

                //Create Relationship of student and father and mother
                var fatherstudent=new ParentStudent();
                fatherstudent.ParentId = fatherres.Entity.Id;
                fatherstudent.StudentId = studentres.Entity.Id;
                await this._context.ParentStudents.AddAsync(fatherstudent);

                var motherstudent = new ParentStudent();
                motherstudent.ParentId = motherres.Entity.Id;
                motherstudent.StudentId = studentres.Entity.Id;
                await this._context.ParentStudents.AddAsync(motherstudent);

                //commit the changes
                await this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }
    }
}
