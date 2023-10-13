using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Data;
namespace DonateMedicine.Controllers
{
    public class AdminViewRequestsController : Controller
    {
        private readonly HealthcareDbContext context;

        public AdminViewRequestsController(HealthcareDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/adminViewRequests")]
        public IActionResult Index()
        {
            var AllRequests = context.Requests.ToList();
            return View(AllRequests);
        }
    }
}
