using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Data;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{
    public class UserViewDonateMedicineController : Controller
    {
        private readonly HealthcareDbContext context;

        public UserViewDonateMedicineController(HealthcareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/userViewDonateMedicine")]
        public IActionResult Index()
        {
            List<Donation> AllDonations = context.Donations.ToList<Donation>();
            List<Donation> UserDonation = new List<Donation>();
            string tempUserName;
            if (TempData.Peek("loggedInUsername") == null)
            {
                tempUserName = "Karthik";
            }
            else
            {
                tempUserName = TempData.Peek("loggedInUsername").ToString();
            }
            foreach(Donation don in AllDonations)
            {
                if (don.DonorName == tempUserName)
                {
                    UserDonation.Add(don);
                }
            }
            ViewBag.userDonations = UserDonation;
            return View();
        }
    }
}
