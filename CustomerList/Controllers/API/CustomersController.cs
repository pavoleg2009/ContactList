using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using CustomerList.Models;

namespace CustomerList.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        //public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _context.Customers.ToList();

            return Ok(customers);
        }

        public IHttpActionResult GetCostomer(int id)
        {
            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        // PUT /api/customers/id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Data object is Invalid");

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            foreach (PropertyInfo property in typeof(Customer).GetProperties())
            {
                property.SetValue(customerInDb, property.GetValue(customer, null), null);
            }

            // change to try-catch for _context.SaveChanges();
            _context.SaveChanges();

            var updatedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (updatedCustomer == null)
                return BadRequest();

            return Ok(updatedCustomer);

        }

        // Delete /api/customers/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            var deletedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (deletedCustomer != null)
                return NotFound();

            return Ok("Record Deleted");

        }
    }


}
