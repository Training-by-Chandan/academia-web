using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Web.Controllers
{
    [Route("data/test/1/2/{controller}")]
    public class StController : Controller
    {
        [Route("test/{i}/details")]
        public IActionResult Index(int i)
        {
            if (true)
            {

            }
            else if (true)
            {

            }
            else if (true)
            {

            }
            else
            {

            }
            return View();
        }
    }
}
