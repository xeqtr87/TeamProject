using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class PassengersController : Controller
    {
        private SvestapolEntities db = new SvestapolEntities();

        // GET: Passengers
        public ActionResult Index()
        {
            
            return View(db.ShowAll());
        }

        // GET: Passengers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passengers passengers = db.Passengers.Find(id);
            if (passengers == null)
            {
                return HttpNotFound();
            }
            return View(passengers);
        }

        // GET: Passengers/Create
        public ActionResult Create()
        {
            ViewBag.Death_ID = new SelectList(db.Pass_DeathCause, "Death_ID", "DeathCause");
            ViewBag.Origin_ID = new SelectList(db.Pass_Origin, "Origin_ID", "Planet");
            ViewBag.Rank_ID = new SelectList(db.Pass_Ranking, "Rank_ID", "Ranking");
            ViewBag.Section_ID = new SelectList(db.Pass_Section, "Section_ID", "Mission");
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,FirstName,LastName,Age,Gender,Section_ID,Origin_ID,Death_ID,Rank_ID,TimeOfDeath,condition")] Passengers passengers)
        {
            if (ModelState.IsValid)
            {
                db.Passengers.Add(passengers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Death_ID = new SelectList(db.Pass_DeathCause, "Death_ID", "DeathCause", passengers.Death_ID);
            ViewBag.Origin_ID = new SelectList(db.Pass_Origin, "Origin_ID", "Planet", passengers.Origin_ID);
            ViewBag.Rank_ID = new SelectList(db.Pass_Ranking, "Rank_ID", "Ranking", passengers.Rank_ID);
            ViewBag.Section_ID = new SelectList(db.Pass_Section, "Section_ID", "Mission", passengers.Section_ID);
            return View(passengers);
        }

        // GET: Passengers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passengers passengers = db.Passengers.Find(id);
            if (passengers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Death_ID = new SelectList(db.Pass_DeathCause, "Death_ID", "DeathCause", passengers.Death_ID);
            ViewBag.Origin_ID = new SelectList(db.Pass_Origin, "Origin_ID", "Planet", passengers.Origin_ID);
            ViewBag.Rank_ID = new SelectList(db.Pass_Ranking, "Rank_ID", "Ranking", passengers.Rank_ID);
            ViewBag.Section_ID = new SelectList(db.Pass_Section, "Section_ID", "Mission", passengers.Section_ID);
            return View(passengers);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,FirstName,LastName,Age,Gender,Section_ID,Origin_ID,Death_ID,Rank_ID,TimeOfDeath,condition")] Passengers passengers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passengers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Death_ID = new SelectList(db.Pass_DeathCause, "Death_ID", "DeathCause", passengers.Death_ID);
            ViewBag.Origin_ID = new SelectList(db.Pass_Origin, "Origin_ID", "Planet", passengers.Origin_ID);
            ViewBag.Rank_ID = new SelectList(db.Pass_Ranking, "Rank_ID", "Ranking", passengers.Rank_ID);
            ViewBag.Section_ID = new SelectList(db.Pass_Section, "Section_ID", "Mission", passengers.Section_ID);
            return View(passengers);
        }

        // GET: Passengers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passengers passengers = db.Passengers.Find(id);
            if (passengers == null)
            {
                return HttpNotFound();
            }
            return View(passengers);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passengers passengers = db.Passengers.Find(id);
            db.Passengers.Remove(passengers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
