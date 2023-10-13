using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Data;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class UserDonateMedicineController : Controller
    {
        private readonly HealthcareDbContext context;

        public UserDonateMedicineController(HealthcareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/userDonateMedicine")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }

        [HttpPost]
        [Route("/userDonateMedicine")]
        public IActionResult Index(Donation d)
        {
            if (d == null || d.MedicineCategory == null || d.MedicineName == null 
                || d.MedicineName.Length<4 || d.MedicineCategory.Length<4 || d.DonationQuantity < 1)
            {
                ViewBag.errorMessage = "Invalid Input!";
                return View();
            }
            else
            {
                Medicine searchMedicine = context.Medicines.FirstOrDefault(m => m.Name == d.MedicineName && m.Category==d.MedicineCategory);
                if(searchMedicine == null)
                {
                    int id = context.Medicines.ToList().Count + 1;
                    context.Medicines.Add(new Medicine{Id=id,Category=d.MedicineCategory,Name=d.MedicineName,Quantity = d.DonationQuantity });
                }
                else
                {
                    searchMedicine.Quantity += d.DonationQuantity;
                }
                if (TempData.Peek("loggedInUsername") != null)
                {
                    d.DonorName = TempData.Peek("loggedInUsername").ToString();
                    d.PickupAddress = TempData.Peek("loggedInAddress").ToString();
                }
                else
                {
                    d.DonorName = "Karthik";
                    d.PickupAddress = "Coimbarore - 7639111007";
                }
            }
            d.DonatedDate = DateTime.Now;
            context.Donations.Add(d);
            context.SaveChanges();

            return RedirectToAction("Index", "UserHome");
        }
    }
}
