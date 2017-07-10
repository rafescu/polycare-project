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
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace PolyCare.Controllers {
    [Authorize]//força a que só utilizadores AUTENTICADOS consigam aceder aos métodos desta classe (aplica-se a todos os métodos)
    public class MedicosController : Controller {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicos
        public ActionResult Index() {
            if (User.IsInRole("Funcionario") || User.IsInRole("Administrador")) {
                var medicos = db.Medicos.ToList();//.Include(m => m.Especialidade);

                return View(medicos);
            }
            if (User.IsInRole("Medico")) {
                //se chegar aqui, significa que é um médico
                return View(db.Medicos.Where(m => m.Username.Equals(User.Identity.Name)).ToList());
            }
            //se chegar aqui, significa que é um paciente
            return new HttpUnauthorizedResult("Unauthorized");
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null) {
                return HttpNotFound();
            }
            return View(medicos);
        }

        //// GET: Medicos/Create
        //public ActionResult Create()
        //{
        //    ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao");
        //    return View();
        //}

        //// POST: Medicos/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MedicoID,Nome,DataNascimento,Sexo,EspecialidadeFK,NIF,DataEntradaClinica,NumCedulaProf,DataInscOrdem,Faculdade")] Medicos medicos)
        //{
        //    //determinar o ID a atribuir ao novo 'medico'
        //    int novoID = 0;
        //    try {
        //        //perguntar á BD qual o último MedicoID
        //        novoID = db.Medicos.Max(d => d.MedicoID) + 1;
        //    } catch (Exception) {
        //        //não existe dados na BD
        //        //o MAX devolve NULL
        //        novoID = 1;
        //    }
        //    medicos.MedicoID = novoID;
        //    try {
        //        if (ModelState.IsValid) {
        //            //adicionar um novo médico
        //            db.Medicos.Add(medicos);
        //            //guarda as modificacoes
        //            db.SaveChanges();
        //            //redireciona
        //            return RedirectToAction("Index");
        //        }
        //    } catch (Exception ex) {

        //        ModelState.AddModelError("",
        //                            string.Format("Ocorreu um erro na operacão de guardar um novo Medico...")
        //                            );
        //    }


        //    ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao", medicos.EspecialidadeFK);
        //    return View(medicos);
        //}



        //
        // GET: /Account/Register



        //  [AllowAnonymous]


        public ActionResult RegisterMedico() {

            Medicos medico = new Medicos();

            //lista é uma List<Especialidades>
            ViewBag.lista = db.Especialidades.ToList();


            return View(medico);
        }

        
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterMedico(Medicos model, string Password, string ConfirmPassword, string[] Checked) {

            if (Password == "" || ConfirmPassword == "") {
                ModelState.AddModelError("", string.Format("Por favor, preencha os campos de Password e Confirmar Password..."));
                return View(model);
            }
            if (Password != ConfirmPassword || Password.Length < 6) {
                ModelState.AddModelError("", string.Format("Por favor, a Password e a sua confirmação tem que ser iguais, e têm de ter, pelo menos, 6 carateres..."));
                return View(model);
            }

            if (ModelState.IsValid) {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Username };
                var result = await UserManager.CreateAsync(user, Password);

                if (result.Succeeded) {

                    //###################################
                    //tentativa
                    ApplicationDbContext db = new ApplicationDbContext();
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                    Medicos medico = new Medicos();
                    medico.MedicoID = determinaNovoIdMedico();
                    medico.Nome = model.Nome;
                    medico.DataNascimento = model.DataNascimento;
                    medico.Sexo = model.Sexo;
                    foreach (var item in Checked) {
                        var idEsp = Convert.ToInt16(item);
                        medico.EspecialidadesDoMedico.Add(db.Especialidades.Select(x=>x).Where(x=>x.EspecialidadeID==idEsp).FirstOrDefault());
                    }
                    
                    //Explicação do Professor
                    ////  medico.EspecialidadeFK = model.EspecialidadeFK;
                    //// * para resolver este problema, 
                    //// *    - na View apresenta-se uma lista de especialidades possiveis (check box list)
                    ////      - na assinatura deste metodo, acrescenta-se o objeto 'check box list'
                    ////          - nao esquecer, validar se houve pelo menos uma especialidade escolhida
                    ////      - criar uma 'lista' de especialidades, com os dados da 'check box list': 
                    ////               var listaDeEspecialidades = new List<Especialidades>();
                    ////      - percorrer a 'check box list' e atribuir valores 'a variavel acima definida
                    ////                foreach +  var especialidade = db.Especialidades.AsNoTracking ().Find(id);
                    ////      - atribuir essa lista ao objeto 'medico'
                    ////              medico.EspecialidadesDoMedico = listaDeEspecialidades;
                    ////   */


                    medico.NIF = model.NIF;
                    medico.DataEntradaClinica = model.DataEntradaClinica;
                    medico.NumCedulaProf = model.NumCedulaProf;
                    medico.DataInscOrdem = model.DataInscOrdem;
                    medico.Faculdade = model.Faculdade;
                    medico.Username = model.Username;
                    medico.ExternalId = user.Id;
                    db.Medicos.Add(medico);
                    var role = userManager.AddToRole(user.Id, "Medico");
                    db.SaveChanges();


                    // await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        //determina o id do novo médico
        private int determinaNovoIdMedico() {

            ApplicationDbContext db = new ApplicationDbContext();
            //determinar o ID a atribuir ao novo 'médico'
            int novoID = 0;
            try {
                //perguntar á BD qual o último DonoID
                novoID = db.Medicos.Max(p => p.MedicoID) + 1;
            } catch (Exception) {
                //não existe dados na BD
                //o MAX devolve NULL
                novoID = 1;
            }
            return novoID;
        }


        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null) {
                return HttpNotFound();
            }
            ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao"); //, medicos.EspecialidadeFK);
            return View(medicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicoID,Nome,DataNascimento,Sexo,NIF,DataEntradaClinica,NumCedulaProf,DataInscOrdem,Faculdade")] Medicos medicos) {
            if (ModelState.IsValid) {
                db.Entry(medicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadeFK = new SelectList(db.Especialidades, "EspecialidadeID", "Designacao"); // , medicos.EspecialidadeFK);
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null) {
                return HttpNotFound();
            }
            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            //procura o 'médico' na base de dados
            Medicos medicos = db.Medicos.Find(id);
            try {
                db.Medicos.Remove(medicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            } catch (Exception) {
                //ModelState.AddModelError("", string.Format("Ocorreu um erro na eliminação do Médico com ID={0}-{1}, por favor verifique se esse Médico não possui nenhum consulta marcada (se tiver, elimine-a primeiro...)", id, medicos.Nome));
                //var ex = "Ocorreu um erro na eliminação do Médico com ID={0}-{1}, por favor verifique se esse Médico não possui nenhum consulta marcada (se tiver, elimine-a primeiro...)";
                //Response.Write("<script language='javascript'>alert('" +ex+ "')</script>");
                TempData["notice"] = "Ocorreu um erro na eliminação do Médico, por favor verifique se esse Médico não possui nenhuma consulta marcada (se tiver, elimine-a primeiro...)";
                return View(medicos);
            }

        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }
    }
}
