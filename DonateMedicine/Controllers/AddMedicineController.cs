using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Data;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class AddMedicineController : Controller
    {
        private readonly HealthcareDbContext context;

        public AddMedicineController(HealthcareDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        [Route("/addmedicine")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("/addmedicine")]
        public IActionResult Index(Medicine medicine)
        {
            if(medicine.Name== null || medicine.Category == null || medicine.Category.Length<4||
                medicine.Name.Length<4 || medicine.Quantity<1 || medicine.Quantity>9999) 
            {
                ViewBag.errorMessage = "";
                return View();
            }
            else
            {
                int id = context.Medicines.ToList().Count + 1;
                medicine.Id = id;
                Medicine searchMedicine = context.Medicines.FirstOrDefault(m => m.Name == medicine.Name && m.Category == medicine.Category);
                if (searchMedicine == null)
                {
                    context.Medicines.Add(medicine);
                }
                else
                {
                    searchMedicine.Quantity += medicine.Quantity;
                }
                context.SaveChanges();
                System.Diagnostics.Debug.WriteLine(context.Medicines.ToList().Count);
                return RedirectToAction("Index", "AdminHome");
            }    
        }
    }
}
