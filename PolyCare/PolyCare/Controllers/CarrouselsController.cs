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
    [Authorize(Roles = "Funcionario")]
    public class CarrouselsController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// retorna a extensão de um ficheiro
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetExtensao(string fileName) {
            fileName = fileName.Substring(fileName.LastIndexOf("/") + 1);
            return "." + fileName;
        }

        /// <summary>
        /// index das imagens
        /// </summary>
        /// <returns></returns>
        // GET: Carrousels
        public ActionResult Index() {
            return View(db.Carrousels.ToList());
        }

        /// <summary>
        /// adicionar uma nova imagem ao Carrousel
        /// </summary>
        /// <returns></returns>
        // GET: Carrousels/Create
        public ActionResult AddImage() {
            return View();
        }

        // POST: Carrousels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage([Bind(Include = "ID,IdFuncionario,TimeStamp,Title,ImgSource")] Carrousel carrousel, HttpPostedFileBase file) {
            //array com os diferentes tipos possíveis de extensões
            string[] extensions = new string[] { "jpeg", "jpg", "bmp", "png" };


            //atribui o id à nova imagem (calculado através da lista das existentes + 1)
            int ImageId = db.Carrousels.ToList().Count + 1;

            //atribui o carrousel ID com o ImageId anteriormente calculado
            carrousel.ID = ImageId;

            //atribui a data e hora da inserção da imagem
            carrousel.TimeStamp = DateTime.Now;

            //atribui o IdFuncionario da imagem ao id do utilizador autenticado
            carrousel.IdFuncionario = User.Identity.GetUserId();

            if (ModelState.IsValid) {

                //se o ficheiro introduzido não for nulo
                if (file != null) {
                    //verifica se o tipo de ficheiro coincide com os tipos de ficheiros possíveis
                    if (extensions.Contains(file.ContentType.Substring(file.ContentType.LastIndexOf("/") + 1))) {

                        //endereço da imagem
                        string endereco = ImageId + GetExtensao(file.ContentType);

                        //caminho da imagem
                        string path = Server.MapPath("~/Content/Images/Carrousel") + "\\" + endereco;
                        file.SaveAs(path);

                        //atribui o endereço
                        carrousel.ImgSource = endereco;

                        //adiciona
                        try {
                            db.Carrousels.Add(carrousel);
                            db.SaveChanges();
                        } catch (Exception) {

                            //se chegar aqui, significa que não se conseguiu guardar na base de dados
                            TempData["notice"] = "Ocorreu um erro ao guardar na base de dados.";
                            return View(carrousel);
                        }
                        return RedirectToAction("Index");
                    }

                    //se chegar aqui, significa que o tipo de ficheiro introduzido não é válido
                    TempData["notice"] = "Por favor, selecione uma imagem válida [precisa ser do tipo jpeg, jpg, bmp ou png].";

                    return View(carrousel);
                }
                //se chegar aqui, significa que a imagem não foi carregada
                return View(carrousel);
            }


            return View(carrousel);
        }

        /// <summary>
        /// edita uma imagem do carrousel
        /// </summary>
        /// <returns></returns>
        // GET: Carrousels/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrousel carrousel = db.Carrousels.Find(id);
            if (carrousel == null) {
                return HttpNotFound();
            }
            return View(carrousel);
        }

        // POST: Carrousels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdFuncionario,TimeStamp,Title,ImgSource")] Carrousel carrousel) {
            if (ModelState.IsValid) {
                db.Entry(carrousel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrousel);
        }

        /// <summary>
        /// apaga uma imagem do Carrousel
        /// </summary>
        /// <returns></returns>
        // GET: Carrousels/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrousel carrousel = db.Carrousels.Find(id);
            if (carrousel == null) {
                return HttpNotFound();
            }
            return View(carrousel);
        }

        // POST: Carrousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Carrousel carrousel = db.Carrousels.Find(id);
            db.Carrousels.Remove(carrousel);
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
