using DonateMedicine.Data;
using DonateMedicine.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Controllers
{
    public class RegisterController : Controller
    {
        private HealthcareDbContext context;
        public RegisterController(HealthcareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("register/")]
        public IActionResult Index()
        {
            ViewBag.errorMessage = "";
            return View();
        }

        [HttpPost]
        [Route("register/")]
        public IActionResult Index(Register register)
        {
            if (register == null || register.Username == null || register.Password == null || register.Gender == null || register.Address == null 
                || register.Username.Length < 3 || register.Password.Length < 5 || register.Address.Length < 6 || register.Age < 18 || register.Age > 100 )
            {
                ViewBag.errorMessage="Invalid Input!";
                return View();
            }
            else
            {
                context.Registers.Add(register);
                context.SaveChanges();
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
