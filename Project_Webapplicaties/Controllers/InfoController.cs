using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Information()
        {
            return View();
        }
    }
}
