using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Data;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class UserRequestMedicineController : Controller
    {
        private readonly HealthcareDbContext context;

        public UserRequestMedicineController(HealthcareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/userRequestMedicine")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            ViewBag.MedicineList = context.Medicines.ToList();
            return View();
        }
        [HttpPost]
        [Route("/userRequestMedicine")]
        public IActionResult Index(Request r)
        {
            if (r==null || r.MedicineName == null || r.MedicineCategory == null || r.RequestedQuatity < 1)
            {
                ViewBag.errorMessage = "Invalid Input!";
                ViewBag.MedicineList = context.Medicines.ToList();
                return View();
            }
            else
            {
                Medicine searchMed = context.Medicines.FirstOrDefault(m => m.Name == r.MedicineName);
                if (searchMed.Quantity < r.RequestedQuatity)
                {
                    ViewBag.errorMessage = "Invalid Input!";
                    ViewBag.MedicineList = context.Medicines.ToList();
                    return View();
                }
                else
                {
                    searchMed.Quantity -= r.RequestedQuatity;
                    int id = context.Requests.ToList().Count + 1;
                    r.Id = id;
                    if (TempData.Peek("loggedInUsername") == null)
                    {
                        r.RequestorName = "Karthik";
                        r.DeliveredAddress = "Coimbarore - 7639111007";
                    }
                    else
                    {
                        r.RequestorName = TempData.Peek("loggedInUsername").ToString();
                        r.DeliveredAddress = TempData.Peek("loggedInAddress").ToString();
                    }

                    r.RequestedDate = DateTime.Today;
                    context.Requests.Add(r);
                    context.SaveChanges();
                    //ViewBag.Quantity = searchMed.Quantity;
                    return RedirectToAction("Index", "UserHome");
                }
            }
        }
    }
}
