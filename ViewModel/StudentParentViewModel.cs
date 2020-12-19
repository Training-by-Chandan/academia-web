using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Web.ViewModel
{

    public class StudentParentViewModel
    {
        public int StudentId {get;set;}
        public int FatherId {get;set;}
        public int MotherId {get;set;}
        public string StudentFirstName {get;set;}
        public string StudentLastName {get;set;}
        public string StudentMiddleName {get;set;}
        public string StudentEmail { get; set; }

        public string FatherFirstName {get;set;}
        public string FatherLastName {get;set;}
        public string FatherMiddleName {get;set;}
        public string FatherPhoneNumber { get; set; }

        public string MotherFirstName {get;set;}
        public string MotherLastName {get;set;}
        public string MotherMiddleName {get;set;}
        public string MotherPhoneNumber { get; set; }

    }
}