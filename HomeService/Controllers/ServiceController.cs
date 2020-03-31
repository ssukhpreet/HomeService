using HomeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeService.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        HomeServiceEntities instance_obj = new HomeServiceEntities();

        public ActionResult ViewStaff()
        {
            return View(instance_obj.Services.ToList());
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Service addDetails)
        {
            if (!ModelState.IsValid)
                return View();
            instance_obj.Services.Add(addDetails);
            instance_obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("ViewStaff");

        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance_obj.Services where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(Service IdToEdit)
        {
            var orignalRecord = (from m in instance_obj.Services where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance_obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance_obj.SaveChanges();
            return RedirectToAction("ViewStaff");


        }

        // GET: Service/Delete/5
        public ActionResult Delete(Service IdToDelete)
        {
            var d = instance_obj.Services.Where(x => x.id == IdToDelete.id).FirstOrDefault();
            instance_obj.Services.Remove(d);
            instance_obj.SaveChanges();
            return RedirectToAction("ViewStaff");

        }

        // POST: Service/Delete/5
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
