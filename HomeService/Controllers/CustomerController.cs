using HomeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeService.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        HomeServiceEntities instance_obj = new HomeServiceEntities();

        public ActionResult CustomerDetails()
        {
            return View(instance_obj.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Customer addDetails)
        {
            if (!ModelState.IsValid)
                return View();
            instance_obj.Customers.Add(addDetails);
            instance_obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("CustomerDetails");

        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance_obj.Customers where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer IdToEdit)
        {
            var orignalRecord = (from m in instance_obj.Customers where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance_obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance_obj.SaveChanges();
            return RedirectToAction("CustomerDetails");



        }

        // GET: Customer/Delete/5
        public ActionResult Delete(Customer IdToDelete)
        {
            var d = instance_obj.Customers.Where(x => x.id == IdToDelete.id).FirstOrDefault();
            instance_obj.Customers.Remove(d);
            instance_obj.SaveChanges();
            return RedirectToAction("CustomerDetails");
            
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
