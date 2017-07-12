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
    [Authorize(Roles = "Funcionario")]
    public class AtendimentosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Atendimentos
        public ActionResult Index()
        {
            return View(db.Atendimentos.ToList());
        }

        // GET: Atendimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimentos atendimentos = db.Atendimentos.Find(id);
            if (atendimentos == null)
            {
                return HttpNotFound();
            }
            return View(atendimentos);
        }

        // GET: Atendimentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atendimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtendimentoID,DataAtivacao,DiaSemana,Inicio,Fim")] Atendimentos atendimentos)
        {
            if (ModelState.IsValid)
            {
                db.Atendimentos.Add(atendimentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atendimentos);
        }

        // GET: Atendimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimentos atendimentos = db.Atendimentos.Find(id);
            if (atendimentos == null)
            {
                return HttpNotFound();
            }
            return View(atendimentos);
        }

        // POST: Atendimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtendimentoID,DataAtivacao,DiaSemana,Inicio,Fim")] Atendimentos atendimentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atendimentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atendimentos);
        }

        // GET: Atendimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendimentos atendimentos = db.Atendimentos.Find(id);
            if (atendimentos == null)
            {
                return HttpNotFound();
            }
            return View(atendimentos);
        }

        // POST: Atendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atendimentos atendimentos = db.Atendimentos.Find(id);
            db.Atendimentos.Remove(atendimentos);
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
