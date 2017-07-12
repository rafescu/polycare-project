﻿using System;
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
    [Authorize(Roles ="Paciente, Funcionario, Administrador")]//força a que só utilizadores Pacientes, Funcionarios ou Administradores consigam aceder aos métodos desta classe (aplica-se a todos os métodos)
    public class PacientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// index dos pacientes
        /// </summary>
        /// <returns></returns>
        // GET: Pacientes
        [Authorize(Roles = "Funcionario,Administrador,Paciente")]
        public ActionResult Index()
        {
            if (User.IsInRole("Funcionario") || User.IsInRole("Administrador")) {
                return View(db.Pacientes.ToList());
            }
            if (User.IsInRole("Paciente")) {
                //se chegar aqui, significa que é um paciente
                return View(db.Pacientes.Where(p => p.Username.Equals(User.Identity.Name)).ToList());
            }
            
            return View();
        }

        /// <summary>
        /// detalhes de um paciente
        /// </summary>
        /// <returns></returns>
        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        /// <summary>
        /// cria um paciente
        /// </summary>
        /// <returns></returns>
        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacienteID,Nome,DataNascimento,Sexo,NIF,Username,ExternalId")] Pacientes pacientes)
        {
            //determinar o ID a atribuir ao novo 'paciente'
            int novoID = 0;
            try {
                //perguntar á BD qual o último PacienteID
                novoID = db.Pacientes.Max(d => d.PacienteID) + 1;
            } catch (Exception) {
                //não existe dados na BD
                //o MAX devolve NULL
                novoID = 1;
            }
            pacientes.PacienteID = novoID;
            try {
                if (ModelState.IsValid) //confronta se os dados a ser introduzidos estão consistentes com o model
            {
                    //adicionar um novo paciente
                    db.Pacientes.Add(pacientes);
                    //guarda as modificacoes
                    db.SaveChanges();
                    //redireciona
                    return RedirectToAction("Index");
                }
            } catch (Exception ex) {

                ModelState.AddModelError("",
                    string.Format("Ocorreu um erro na operacão de guardar um novo Paciente...")
                    );
            }
            
            //volta para a View da criação dos pacientes
            return View(pacientes);
        }

        /// <summary>
        /// edita um paciente
        /// </summary>
        /// <returns></returns>
        // GET: Pacientes/Edit/5
        [Authorize(Roles = "Funcionario,Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacienteID,Nome,DataNascimento,Sexo,NIF,Username,ExternalId")] Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacientes);
        }

        /// <summary>
        /// apaga um paciente
        /// </summary>
        /// <returns></returns>
        // GET: Pacientes/Delete/5
        [Authorize(Roles = "Funcionario,Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacientes pacientes = db.Pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacientes pacientes = db.Pacientes.Find(id);
            try {
                //marcar o paciente para eliminação
                db.Pacientes.Remove(pacientes);
                //efetuar commit ao comando anterior
                db.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception) {

                //criar uma mensagem de erro a ser apresentada ao utilizador
                ModelState.AddModelError("", string.Format("Ocorreu um erro na eliminação do Paciente com ID={0}-{1}", id, pacientes.Nome));
                //invocar a view, com os dados do paciente atual
                return View(pacientes);
            }

            
            
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
