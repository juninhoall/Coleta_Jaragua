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
    public class EmpresaController : Controller
    {
        private DataBasseColetoresEntities db = new DataBasseColetoresEntities();

        //
        // GET: /Empresa/

        public ActionResult Index()
        {
            return View(db.Tb_Empresa.ToList());
        }

        //
        // GET: /Empresa/Details/5

        public ActionResult Details(int id = 0)
        {
            Tb_Empresa tb_empresa = db.Tb_Empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        //
        // GET: /Empresa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Empresa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tb_Empresa tb_empresa)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Empresa.Add(tb_empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_empresa);
        }

        //
        // GET: /Empresa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tb_Empresa tb_empresa = db.Tb_Empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        //
        // POST: /Empresa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_Empresa tb_empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_empresa);
        }

        //
        // GET: /Empresa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tb_Empresa tb_empresa = db.Tb_Empresa.Find(id);
            if (tb_empresa == null)
            {
                return HttpNotFound();
            }
            return View(tb_empresa);
        }

        //
        // POST: /Empresa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_Empresa tb_empresa = db.Tb_Empresa.Find(id);
            db.Tb_Empresa.Remove(tb_empresa);
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