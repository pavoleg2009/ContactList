using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerList.Controllers
{
    public class AngularCustomersController : Controller
    {
        // GET: AngularCustomers
        public ActionResult Index()
        {
            return View();
        }
    }
}