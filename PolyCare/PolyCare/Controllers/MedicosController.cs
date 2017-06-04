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
    public class MedicosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(m => m.Especialidade);
            return View(medicos.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicoID,Nome,DataNascimento,Foto,EspecialidadeFK,NIF,DataEntradaClinica,NumCedulaProf,DataInscOrdem,Faculdade")] Medicos medicos)
        {
            //determinar o ID a atribuir ao novo 'medico'
            int novoID = 0;
            try {
                //perguntar á BD qual o último MedicoID
                novoID = db.Medicos.Max(d => d.MedicoID) + 1;
            } catch (Exception) {
                //não existe dados na BD
                //o MAX devolve NULL
                novoID = 1;
            }
            medicos.MedicoID = novoID;
            try {
                if (ModelState.IsValid) {
                    //adicionar um novo médico
                    db.Medicos.Add(medicos);
                    //guarda as modificacoes
                    db.SaveChanges();
                    //redireciona
                    return RedirectToAction("Index");
                }
            } catch (Exception ex) {

                ModelState.AddModelError("",
                                    string.Format("Ocorreu um erro na operacão de guardar um novo Medico...")
                                    );
            }
            

            ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao", medicos.EspecialidadeFK);
            return View(medicos);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao", medicos.EspecialidadeFK);
            return View(medicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicoID,Nome,DataNascimento,Foto,EspecialidadeFK,NIF,DataEntradaClinica,NumCedulaProf,DataInscOrdem,Faculdade")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao", medicos.EspecialidadeFK);
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicos medicos = db.Medicos.Find(id);
            db.Medicos.Remove(medicos);
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
