using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ColetaJaragua.Models;

namespace ColetaJaragua.Controllers
{
    public class BoxController : Controller
    {
        private DataBasseColetoresEntities db = new DataBasseColetoresEntities();

        //
        // GET: /Box/

        public ActionResult Index()
        {
            var tb_box = db.Tb_Box.Include(t => t.Tb_Cadastro_Coletores);
            return View(tb_box.ToList());
        }

        //
        // GET: /Box/Details/5

        public ActionResult Details(int id = 0)
        {
            Tb_Box tb_box = db.Tb_Box.Find(id);
            if (tb_box == null)
            {
                return HttpNotFound();
            }
            return View(tb_box);
        }

        //
        // GET: /Box/Create

        public ActionResult Create()
        {
            ViewBag.Codigo_Func = new SelectList(db.Tb_Cadastro_Coletores, "Codigo_Coletor", "Nome_Coletor");
            return View();
        }

        //
        // POST: /Box/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tb_Box tb_box)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Box.Add(tb_box);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Func = new SelectList(db.Tb_Cadastro_Coletores, "Codigo_Coletor", "Nome_Coletor", tb_box.Codigo_Func);
            return View(tb_box);
        }

        //
        // GET: /Box/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tb_Box tb_box = db.Tb_Box.Find(id);
            if (tb_box == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Func = new SelectList(db.Tb_Cadastro_Coletores, "Codigo_Coletor", "Nome_Coletor", tb_box.Codigo_Func);
            return View(tb_box);
        }

        //
        // POST: /Box/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_Box tb_box)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_box).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Func = new SelectList(db.Tb_Cadastro_Coletores, "Codigo_Coletor", "Nome_Coletor", tb_box.Codigo_Func);
            return View(tb_box);
        }

        //
        // GET: /Box/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tb_Box tb_box = db.Tb_Box.Find(id);
            if (tb_box == null)
            {
                return HttpNotFound();
            }
            return View(tb_box);
        }

        //
        // POST: /Box/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_Box tb_box = db.Tb_Box.Find(id);
            db.Tb_Box.Remove(tb_box);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}