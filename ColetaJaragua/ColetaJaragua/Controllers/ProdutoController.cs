using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ColetaJaragua.Models;
using System.ComponentModel.DataAnnotations;

namespace ColetaJaragua.Controllers
{
    public class ProdutoController : Controller
    {
        private DataBasseColetoresEntities db = new DataBasseColetoresEntities();

        //
        // GET: /Produto/
        [Authorize]
        public ActionResult Index()
        {
            var tb_produto = db.Tb_Produto.Include(t => t.Tb_Codigo_UM);
            return View(tb_produto.ToList());
        }

        //
        // GET: /Produto/Details/5

        public ActionResult Details(int id = 0)
        {
            Tb_Produto tb_produto = db.Tb_Produto.Find(id);
            if (tb_produto == null)
            {
                return HttpNotFound();
            }
            return View(tb_produto);
        }

        //
        // GET: /Produto/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Codigo_Medidas = new SelectList(db.Tb_Codigo_UM, "Codigo_UnidadeM", "Descricao");
            return View();
        }

        //
        // POST: /Produto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tb_Produto tb_produto)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Produto.Add(tb_produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Medidas = new SelectList(db.Tb_Codigo_UM, "Codigo_UnidadeM", "Descricao", tb_produto.Codigo_Medidas);
            return View(tb_produto);
        }

        //
        // GET: /Produto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tb_Produto tb_produto = db.Tb_Produto.Find(id);
            if (tb_produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Medidas = new SelectList(db.Tb_Codigo_UM, "Codigo_UnidadeM", "Descricao", tb_produto.Codigo_Medidas);
            return View(tb_produto);
        }

        //
        // POST: /Produto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_Produto tb_produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Medidas = new SelectList(db.Tb_Codigo_UM, "Codigo_UnidadeM", "Descricao", tb_produto.Codigo_Medidas);
            return View(tb_produto);
        }

        //
        // GET: /Produto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tb_Produto tb_produto = db.Tb_Produto.Find(id);
            if (tb_produto == null)
            {
                return HttpNotFound();
            }
            return View(tb_produto);
        }

        //
        // POST: /Produto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_Produto tb_produto = db.Tb_Produto.Find(id);
            db.Tb_Produto.Remove(tb_produto);
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