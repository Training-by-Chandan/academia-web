using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Web.ViewModel
{
    public class StudentClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActiveClass { get; set; }
    }

    public class StudentClassHistoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Classes { get; set; }
        public string Enrollyear { get; set; }
    }
}
