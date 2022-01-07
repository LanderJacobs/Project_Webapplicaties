using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Webapplicaties.Data.UnitOfWork; //anders werkt het niet in dit project

namespace Project_Webapplicaties.Controllers
{
    public class GearController : Controller
    {
        private readonly IUnitOfWork _uow;
        public GearController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
