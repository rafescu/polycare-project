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

namespace PolyCare.Controllers
{
    public class CarrouselsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public string GetExtensao(string fileName) {
            fileName = fileName.Substring(fileName.LastIndexOf("/") + 1);
            return "." + fileName;
        }

        // GET: Carrousels
        public ActionResult Index()
        {
            return View(db.Carrousels.ToList());
        }


        // GET: Carrousels/Create
        public ActionResult AddImage()
        {
            return View();
        }

        // POST: Carrousels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage([Bind(Include = "ID,IdFuncionario,TimeStamp,Title,ImgSource")] Carrousel carrousel, HttpPostedFileBase file)
        {
            string[] extensions = new string[] { "jpeg", "jpg", "bmp", "png"};
            try {
                int ImageId = db.Carrousels.ToList().Count + 1;
                carrousel.ID = ImageId;
                carrousel.TimeStamp = DateTime.Now;
                carrousel.IdFuncionario = User.Identity.GetUserId();
               
                if (ModelState.IsValid) {

                    if(file != null) {
                        if (extensions.Contains(file.ContentType.Substring(file.ContentType.LastIndexOf("/") + 1))) {
                            string nome = ImageId + GetExtensao(file.ContentType);
                            string path = Server.MapPath("~/Content/Images/Carrousel") + "\\" + nome;
                            file.SaveAs(path);
                            carrousel.ImgSource = nome;

                            db.Carrousels.Add(carrousel);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        // file.ContentType nao e suportado
                        return View(carrousel);
                    }
                    //imagem nao foi carregada
                    return View(carrousel);
                }
            } catch (Exception) {

                throw;
            }
            
            return View(carrousel);
        }

        // GET: Carrousels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrousel carrousel = db.Carrousels.Find(id);
            if (carrousel == null)
            {
                return HttpNotFound();
            }
            return View(carrousel);
        }

        // POST: Carrousels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdFuncionario,TimeStamp,Title,ImgSource")] Carrousel carrousel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrousel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrousel);
        }

        // GET: Carrousels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrousel carrousel = db.Carrousels.Find(id);
            if (carrousel == null)
            {
                return HttpNotFound();
            }
            return View(carrousel);
        }

        // POST: Carrousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrousel carrousel = db.Carrousels.Find(id);
            db.Carrousels.Remove(carrousel);
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
