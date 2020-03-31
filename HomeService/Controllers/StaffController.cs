using HomeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeService.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff

        HomeServiceEntities instance_obj = new HomeServiceEntities();

        public ActionResult StaffDetails()
        {
            return View(instance_obj.Staffs.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Staff addDetails)
        {
            if (!ModelState.IsValid)
                return View();
            instance_obj.Staffs.Add(addDetails);
            instance_obj.SaveChanges();
            
            return RedirectToAction("StaffDetails");
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance_obj.Staffs where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(Staff IdToEdit)
        {
            var orignalRecord = (from m in instance_obj.Staffs where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance_obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance_obj.SaveChanges();
            return RedirectToAction("StaffDetails");


        }

        // GET: Staff/Delete/5
        public ActionResult Delete(Staff IdToDelete)
        {

            var d = instance_obj.Staffs.Where(x => x.id == IdToDelete.id).FirstOrDefault();
            instance_obj.Staffs.Remove(d);
            instance_obj.SaveChanges();
            return RedirectToAction("StaffDetails");

        }

        // POST: Staff/Delete/5
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
