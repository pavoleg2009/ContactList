using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerList.Models;

namespace CustomerList.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {   
            var customers = new List<Customer>
            {
                new Customer { FristName = "John", LastName = "Smith"},
                new Customer { FristName = "Barak", LastName = "Obama"},
                new Customer { FristName = "Lucy", LastName = "Lyu"},
                new Customer { FristName = "Poll", LastName = "Pott"},
                new Customer { FristName = "Michel", LastName = "Jackson"}
            };
            return View(customers);
        }

        public ActionResult New(string s)
        {
            throw new NotImplementedException();
        }
    }
}