﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PolyCare.Models;
using Microsoft.AspNet.Identity;

namespace PolyCare.Controllers {
    public class MarcacoesController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Marcacoes
        public ActionResult Index() {
            var userid = User.Identity.GetUserId();

            if (User.IsInRole("Paciente")) {
                var user = (from r in db.Pacientes where r.ExternalId == userid select r.PacienteID).Single();
                //  var marcacoes = db.Marcacoes.Where(x => x.PacienteFK == user).Include(m => m.Medico.Especialidade).Include(m => m.Medico).Include(m => m.Paciente);

                var marca = db.Pacientes.Where(p => p.ExternalId.Equals(User.Identity.GetUserId())).FirstOrDefault().Marcacoes;

                //return View(marcacoes.ToList());
                return View(marca);
            }
            if (User.IsInRole("Medico")) {
                var user = (from r in db.Medicos where r.ExternalId == userid select r.MedicoID).Single();
                //  var marcacoes = db.Marcacoes.Where(x => x.MedicoFK == user).Include(m => m.Medico.Especialidade).Include(m => m.Medico).Include(m => m.Paciente);
                //  return View(marcacoes.ToList());
                return View();
            }
            return View();
        }

        // GET: Marcacoes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacoes marcacoes = db.Marcacoes.Find(id);
            if (marcacoes == null) {
                return HttpNotFound();
            }
            return View(marcacoes);
        }

        /// <summary>
        /// lista os medicos associados a uma especialidade
        /// </summary>
        /// <param name="id">PK associada a uma especialidade</param>
        /// <returns>lista de medicos</returns>
        public JsonResult ListaMedicos(int id) {

            // var medicos = db.Medicos.Where(x => x.EspecialidadeFK == id).Select(m => new { m.Nome, m.MedicoID }).ToList();
            var medicos = db.Especialidades.Where(e => e.EspecialidadeID == id).Select(e => e.ListaDeMedicos);

            return Json(medicos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// criar uma marcacao de uma nova consulta
        /// </summary>
        /// <returns></returns>
        // GET: Marcacoes/Create
        public ActionResult Create() {
            ViewBag.Especialidades = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao");


            //  ViewBag.MedicoFK = new SelectList(db.Medicos.Where(x => x.EspecialidadeFK == 1).Select(m => m).ToList(), "MedicoID", "Nome");

            //ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome");
            return View();
        }

        // POST: Marcacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarcacaoID,DataMarcacoes,MedicoFK,PacienteFK")] Marcacoes marcacoes) {
            if (ModelState.IsValid) {
                var userid = User.Identity.GetUserId();

                var user = (from r in db.Pacientes where r.ExternalId == userid select r.PacienteID).Single();

                marcacoes.PacienteFK = user;
                db.Marcacoes.Add(marcacoes);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.MedicoFK = new SelectList(db.Medicos, "MedicoID", "Nome", marcacoes.MedicoFK);
            ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome", marcacoes.PacienteFK);
            return View(marcacoes);
        }

        // GET: Marcacoes/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacoes marcacoes = db.Marcacoes.Find(id);
            if (marcacoes == null) {
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
        public ActionResult Edit([Bind(Include = "MarcacaoID,DataMarcacoes,MedicoFK,PacienteFK")] Marcacoes marcacoes) {
            if (ModelState.IsValid) {
                db.Entry(marcacoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicoFK = new SelectList(db.Medicos, "MedicoID", "Nome", marcacoes.MedicoFK);
            ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome", marcacoes.PacienteFK);
            return View(marcacoes);
        }

        // GET: Marcacoes/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcacoes marcacoes = db.Marcacoes.Find(id);
            if (marcacoes == null) {
                return HttpNotFound();
            }
            return View(marcacoes);
        }

        // POST: Marcacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Marcacoes marcacoes = db.Marcacoes.Find(id);
            db.Marcacoes.Remove(marcacoes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
