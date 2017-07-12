using System;
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

        /// <summary>
        /// index de uma consulta
        /// </summary>
        /// <returns></returns>
        // GET: Marcacoes
        public ActionResult Index() {
            //variável que vai ficar com o valor do Id do utilizador autenticado
            var userid = User.Identity.GetUserId();

            //se o utilizador estiver inserido no Role Paciente
            if (User.IsInRole("Paciente")) {
                
                //retorna as marcações do paciente
                var marca = db.Pacientes.Where(p => p.ExternalId.Equals(userid)).FirstOrDefault().Marcacoes;
     
                return View(marca);
            }
            //se o utilizador estiver inserido no Role Medico
            if (User.IsInRole("Medico")) {
                //seleciona o médico cujo ExternalId é igual ao userid
                var medico = (from r in db.Medicos where r.ExternalId == userid select r.MedicoID).Single();

                //retorna as marcoções desse médico
                var marcacoes = db.Marcacoes.Where(x => x.MedicoFK == medico).Include(m => m.Especialidade).Include(m => m.Medico).Include(m => m.Paciente);
                return View(marcacoes.ToList());
            }

            //se for Funcionário, retorna todas as Marcações
            return View(db.Marcacoes.ToList());
        }
        /// <summary>
        /// detalhes de uma consulta
        /// </summary>
        /// <returns></returns>
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
            
            var lista_medicos = db.Especialidades.Where(x => x.EspecialidadeID == id).Single().ListaDeMedicos.Select(m=> new { m.Nome, m.MedicoID }).ToList();


            return Json(lista_medicos, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// criar uma marcacao de uma nova consulta
        /// </summary>
        /// <returns></returns>
        // GET: Marcacoes/Create
        public ActionResult Create() {
            ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao");

            ViewBag.MedicoFK = new SelectList(db.Especialidades.Where(x => x.EspecialidadeID == 1).Single().ListaDeMedicos.Select(m => m).ToList(), "MedicoID", "Nome");

 
            return View();
        }

        // POST: Marcacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarcacaoID,DataMarcacoes,MedicoFK,PacienteFK,EspecialidadeFK")] Marcacoes marcacoes) {
            if (ModelState.IsValid) {

                //busca o id do utilizador autenticado
                var userid = User.Identity.GetUserId();

                //iguala o id do paciente ao id do utilizador autenticado
                var user = (from r in db.Pacientes where r.ExternalId == userid select r.PacienteID).Single();

                //valor do novo id da marcação, calculado a partir da contagem das marcações + 1
                var marcId = db.Marcacoes.Count() + 1;

                //associa a MarcacaoID das marcacoes ao novo id
                marcacoes.MarcacaoID = marcId;

                //associa o PacienteFK ao user
                marcacoes.PacienteFK = user;


                db.Marcacoes.Add(marcacoes);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.MedicoFK = new SelectList(db.Medicos, "MedicoID", "Nome", marcacoes.MedicoFK);
            ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome", marcacoes.PacienteFK);
            return View(marcacoes);
        }

        /// <summary>
        /// edita uma consulta
        /// </summary>
        /// <returns></returns>
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
        public ActionResult Edit([Bind(Include = "MarcacaoID,DataMarcacoes,MedicoFK,PacienteFK,EspecialidadeFK")] Marcacoes marcacoes) {
            if (ModelState.IsValid) {
                db.Entry(marcacoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicoFK = new SelectList(db.Medicos, "MedicoID", "Nome", marcacoes.MedicoFK);
            ViewBag.PacienteFK = new SelectList(db.Pacientes, "PacienteID", "Nome", marcacoes.PacienteFK);
            return View(marcacoes);
        }

        /// <summary>
        /// apaga uma consulta
        /// </summary>
        /// <returns></returns>
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
