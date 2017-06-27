using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PolyCare.Models;

namespace PolyCare.Controllers
{
    public class MarcacoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Marcacoes
        public ActionResult Index()
        {
            var marcacoes = db.Marcacoes.Include(m => m.Medico).Include(m => m.Paciente);
            return View(marcacoes.ToList());
        }

        // GET: Marcacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacoes marcacoes = db.Marcacoes.Find(id);
            if (marcacoes == null)
            {
                return HttpNotFound();
            }
            return View(marcacoes);
        }

        // GET: Marcacoes/Create
        public ActionResult Create()
        {
            ViewBag.MedicoFK = new SelectList(db.Medicos, "MedicoID", "Nome");
            ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome");
            return View();
        }

        // POST: Marcacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarcacaoID,DataMarcacoes,MedicoFK,PacienteFK")] Marcacoes marcacoes)
        {
            if (ModelState.IsValid)
            {
                db.Marcacoes.Add(marcacoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicoFK = new SelectList(db.Medicos, "MedicoID", "Nome", marcacoes.MedicoFK);
            ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome", marcacoes.PacienteFK);
            return View(marcacoes);
        }

        // GET: Marcacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacoes marcacoes = db.Marcacoes.Find(id);
            if (marcacoes == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicoFK = new SelectList(db.Medicos, "MedicoID", "Nome", marcacoes.MedicoFK);
            ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome", marcacoes.PacienteFK);
            return View(marcacoes);
        }

        // POST: Marcacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarcacaoID,DataMarcacoes,MedicoFK,PacienteFK")] Marcacoes marcacoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcacoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicoFK = new SelectList(db.Medicos, "MedicoID", "Nome", marcacoes.MedicoFK);
            ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome", marcacoes.PacienteFK);
            return View(marcacoes);
        }

        // GET: Marcacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacoes marcacoes = db.Marcacoes.Find(id);
            if (marcacoes == null)
            {
                return HttpNotFound();
            }
            return View(marcacoes);
        }

        // POST: Marcacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marcacoes marcacoes = db.Marcacoes.Find(id);
            db.Marcacoes.Remove(marcacoes);
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
