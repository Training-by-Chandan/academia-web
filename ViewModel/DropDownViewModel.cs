using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Web.ViewModel
{
    public class DropDownViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<DropDownItem> Items { get; set; }
    }

    public class DropDownItem
    {
        public string Href { get; set; }
        public string ItemName { get; set; }
        
    }
}
