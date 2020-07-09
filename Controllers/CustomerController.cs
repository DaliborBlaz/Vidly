using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Runtime.Caching;

namespace Vidly2.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);

            }
         
            if (customer.CustomerId == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerinDb = _context.Customers.Single(x => x.CustomerId == customer.CustomerId);

                customerinDb.Name = customer.Name;
                customerinDb.DateOfBirth = customer.DateOfBirth;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.IsSubscribedtoNewsletter = customer.IsSubscribedtoNewsletter;



            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");



        }



        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.canManageMovies))
                return View("Index");
            else
                return View("ReadOnlyList");
        }



        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.CustomerId == id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.CustomerId == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("New", viewModel);
        }


    }
}