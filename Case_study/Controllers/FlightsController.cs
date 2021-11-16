using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Case_study.DAL;
using Case_study.Models;

namespace Case_study.Controllers
{
    
    public class FlightsController : Controller
    {
        private Case_studyContext db = new Case_studyContext();

        [AllowAnonymous]
        public ActionResult Search(string source,string des,DateTime dep)
        {
            DateTime date_t = dep.Date;
            string date = date_t.ToString("d");
            var res = db.Flights.Where(s => s.source == source && s.destination == des && s.date == date).ToList();
            return View("Index",res);
        }
        [Authorize]
        public ActionResult Status()
        {
            Random r = new Random();
            int rInt = r.Next(5000, 100000); //for ints
            int range = 100;
            double rDouble = r.NextDouble() * range;
            //var identity = (ClaimsIdentity)User.Identity;
            //var role = identity.FindFirst(ClaimTypes.Email).Value;
            return View(rInt);
        }
        [AllowAnonymous]
        // GET: Flights
        public ActionResult Index()
        {
            return View(db.Flights.ToList());
        }
        [Authorize]
        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,source,destination,Airplane,departure,type,price")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                DateTime date_t = flight.departure.Date;
                string date = date_t.ToString("d");
                flight.date = date;
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flight);
        }
        [Authorize(Roles ="Admin")]
        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,source,destination,Airplane,departure,type,price")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                DateTime date_t = flight.departure.Date;
                string date = date_t.ToString("d");
                flight.date = date;
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }
        [Authorize(Roles = "Admin")]
        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }
        [Authorize(Roles = "Admin")]
        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
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
