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
    public class FuncionariosController : Controller
    {
        private DataBasseColetoresEntities db = new DataBasseColetoresEntities();

        //
        // GET: /Funcionarios/
        [Authorize]
        public ActionResult Index()
        {
            var tb_cadastro_coletores = db.Tb_Cadastro_Coletores.Include(t => t.Tb_Banco).Include(t => t.Tb_Tipo_Civil).Include(t => t.Tb_Tipo_Sexo).Include(t => t.Tb_Tipo_Associado);
            return View(tb_cadastro_coletores.ToList());
        }

        //
        // GET: /Funcionarios/Details/5

        public ActionResult Details(int id = 0)
        {
            Tb_Cadastro_Coletores tb_cadastro_coletores = db.Tb_Cadastro_Coletores.Find(id);
            if (tb_cadastro_coletores == null)
            {
                return HttpNotFound();
            }
            return View(tb_cadastro_coletores);
        }

        //
        // GET: /Funcionarios/Create

        public ActionResult Create()
        {
            ViewBag.Codigo_Banco_Coletor = new SelectList(db.Tb_Banco, "Codigo_Banco", "Descricao_Banco");
            ViewBag.Codigo_Estado_Civil = new SelectList(db.Tb_Tipo_Civil, "Codigo_Civil", "Descricao_Civil");
            ViewBag.Codigo_Sexo_Coletor = new SelectList(db.Tb_Tipo_Sexo, "Codigo_Sexo", "Descricao_Sexo");
            ViewBag.Codigo_Tipo_Associado = new SelectList(db.Tb_Tipo_Associado, "Codigo_Tipo_Associado", "Descricao_Tipo");
            return View();
        }

        //
        // POST: /Funcionarios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tb_Cadastro_Coletores tb_cadastro_coletores)
        {
            if (ModelState.IsValid)
            {
                db.Tb_Cadastro_Coletores.Add(tb_cadastro_coletores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Banco_Coletor = new SelectList(db.Tb_Banco, "Codigo_Banco", "Descricao_Banco", tb_cadastro_coletores.Codigo_Banco_Coletor);
            ViewBag.Codigo_Estado_Civil = new SelectList(db.Tb_Tipo_Civil, "Codigo_Civil", "Descricao_Civil", tb_cadastro_coletores.Codigo_Estado_Civil);
            ViewBag.Codigo_Sexo_Coletor = new SelectList(db.Tb_Tipo_Sexo, "Codigo_Sexo", "Descricao_Sexo", tb_cadastro_coletores.Codigo_Sexo_Coletor);
            ViewBag.Codigo_Tipo_Associado = new SelectList(db.Tb_Tipo_Associado, "Codigo_Tipo_Associado", "Descricao_Tipo", tb_cadastro_coletores.Codigo_Tipo_Associado);
            return View(tb_cadastro_coletores);
        }

        //
        // GET: /Funcionarios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tb_Cadastro_Coletores tb_cadastro_coletores = db.Tb_Cadastro_Coletores.Find(id);
            if (tb_cadastro_coletores == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Banco_Coletor = new SelectList(db.Tb_Banco, "Codigo_Banco", "Descricao_Banco", tb_cadastro_coletores.Codigo_Banco_Coletor);
            ViewBag.Codigo_Estado_Civil = new SelectList(db.Tb_Tipo_Civil, "Codigo_Civil", "Descricao_Civil", tb_cadastro_coletores.Codigo_Estado_Civil);
            ViewBag.Codigo_Sexo_Coletor = new SelectList(db.Tb_Tipo_Sexo, "Codigo_Sexo", "Descricao_Sexo", tb_cadastro_coletores.Codigo_Sexo_Coletor);
            ViewBag.Codigo_Tipo_Associado = new SelectList(db.Tb_Tipo_Associado, "Codigo_Tipo_Associado", "Descricao_Tipo", tb_cadastro_coletores.Codigo_Tipo_Associado);
            return View(tb_cadastro_coletores);
        }

        //
        // POST: /Funcionarios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tb_Cadastro_Coletores tb_cadastro_coletores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_cadastro_coletores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Banco_Coletor = new SelectList(db.Tb_Banco, "Codigo_Banco", "Descricao_Banco", tb_cadastro_coletores.Codigo_Banco_Coletor);
            ViewBag.Codigo_Estado_Civil = new SelectList(db.Tb_Tipo_Civil, "Codigo_Civil", "Descricao_Civil", tb_cadastro_coletores.Codigo_Estado_Civil);
            ViewBag.Codigo_Sexo_Coletor = new SelectList(db.Tb_Tipo_Sexo, "Codigo_Sexo", "Descricao_Sexo", tb_cadastro_coletores.Codigo_Sexo_Coletor);
            ViewBag.Codigo_Tipo_Associado = new SelectList(db.Tb_Tipo_Associado, "Codigo_Tipo_Associado", "Descricao_Tipo", tb_cadastro_coletores.Codigo_Tipo_Associado);
            return View(tb_cadastro_coletores);
        }

        //
        // GET: /Funcionarios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tb_Cadastro_Coletores tb_cadastro_coletores = db.Tb_Cadastro_Coletores.Find(id);
            if (tb_cadastro_coletores == null)
            {
                return HttpNotFound();
            }
            return View(tb_cadastro_coletores);
        }

        //
        // POST: /Funcionarios/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tb_Cadastro_Coletores tb_cadastro_coletores = db.Tb_Cadastro_Coletores.Find(id);
            db.Tb_Cadastro_Coletores.Remove(tb_cadastro_coletores);
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