using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rejestr_PawełPieniak.Models;

namespace Rejestr_PawełPieniak.Controllers
{
    public class PersonsMissingsController : Controller
    {
        private MissingPersonEntities db = new MissingPersonEntities();

        // GET: PersonsMissings
        public PartialViewResult GetPersonDates(string selectedGender = "All")
        {
            IEnumerable<PersonsMissing> data = db.PersonsMissing;
            if (selectedGender != "All")
            {
                //Gender selected = (Gender)Enum.Parse(typeof(Gender), selectedGender);
                data = db.PersonsMissing.Where(p => p.Gender == selectedGender);
                //return PartialView(db.OsobyZaginione.Where(p => p.Name == selectedPersons).ToList());
            }
            return PartialView(data);
        }

        public ActionResult Index(string selectedGender = "All")
        {
            return View((object)selectedGender);
        }
        //public ActionResult Index()
        //{
        //    return View(db.PersonsMissing.ToList());
        //}

        // GET: PersonsMissings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsMissing personsMissing = db.PersonsMissing.Find(id);
            if (personsMissing == null)
            {
                return HttpNotFound();
            }
            return View(personsMissing);
        }

        // GET: PersonsMissings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonsMissings/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPerson,Name,LastName,Gender,DateOfBirth,DateOfDisappearance,PictureName,CityOfDisappearance,LocationOfDisappearance")] PersonsMissing personsMissing)
        {
            if (ModelState.IsValid)
            {
                db.PersonsMissing.Add(personsMissing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personsMissing);
        }

        // GET: PersonsMissings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsMissing personsMissing = db.PersonsMissing.Find(id);
            if (personsMissing == null)
            {
                return HttpNotFound();
            }
            return View(personsMissing);
        }

        // POST: PersonsMissings/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPerson,Name,LastName,Gender,DateOfBirth,DateOfDisappearance,PictureName,CityOfDisappearance,LocationOfDisappearance")] PersonsMissing personsMissing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personsMissing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personsMissing);
        }

        // GET: PersonsMissings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonsMissing personsMissing = db.PersonsMissing.Find(id);
            if (personsMissing == null)
            {
                return HttpNotFound();
            }
            return View(personsMissing);
        }

        // POST: PersonsMissings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonsMissing personsMissing = db.PersonsMissing.Find(id);
            db.PersonsMissing.Remove(personsMissing);
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
