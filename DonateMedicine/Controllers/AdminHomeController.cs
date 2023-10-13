using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Data;

namespace DonateMedicine.Controllers
{
    public class AdminHomeController : Controller
    {
        private HealthcareDbContext context;

        public AdminHomeController(HealthcareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/adminhome")]
        public IActionResult Index()
        {
            //ViewBag.allMedicines = context.Medicines.ToList();
            var AllMedicines = context.Medicines.ToList();
            return View(AllMedicines);
        }
    }
}
