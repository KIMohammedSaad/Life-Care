using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Data;
using DonateMedicine.Models;

namespace DonateMedicine.Controllers
{

    public class LoginController : Controller

    {
        private HealthcareDbContext context;

        public LoginController(HealthcareDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {

            ViewBag.errorMessage = "";
            return View();
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(Register register)
        {
            if(register.Username == null || register.Password == null)
            {
                ViewBag.errorMessage = "Invalid Input!";
                return View();
            }
            else if (register.Username.Length < 3 || register.Password.Length < 6)
            {
                ViewBag.errorMessage = "Invalid Input!";
                return View();
            }
            else
            {
                Register user = context.Registers.FirstOrDefault(u => u.Username == register.Username && u.Password == register.Password);
                if(user == null)
                {
                    ViewBag.errorMessage = "Invalid Input";
                    return View();
                }
                else
                {
                    TempData["loggedInUsername"] = user.Username;
                    TempData["loggedinAddress"] = user.Address;
                    if ( user.Username == "Admin")
                    {
                        return RedirectToAction("Index","AdminHome");
                    }else
                    {
                        return RedirectToAction("Index","UserHome");
                    }
                }
            }
        }
    }
}
