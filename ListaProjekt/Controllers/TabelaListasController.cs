using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ListaProjekt.Models;

namespace ListaProjekt.Controllers
{
    public class TabelaListasController : Controller
    {
        private ListaEntities db = new ListaEntities();

        // GET: TabelaListas
        public ActionResult Index()
        {
            return View(db.TabelaListas.ToList());
        }

        // GET: TabelaListas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaLista tabelaLista = db.TabelaListas.Find(id);
            if (tabelaLista == null)
            {
                return HttpNotFound();
            }
            return View(tabelaLista);
        }

        // GET: TabelaListas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabelaListas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imiePierwsze,imieDrugie,nazwisko,nazwiskoRodowe,ulica,numerDomu,numerMieszkania,kod,miasto,dataUrodzenia,miejsceUrodzenia,pesel,nip,imieOjca,imieMatki,nazwiskoMatki,plec,dokumentTyp,dokumentWydany,dokumentNumer,email,telefon,wyksztalcenie,obywatelstwo,narodowosc")] TabelaLista tabelaLista)
        {
            if (ModelState.IsValid)
            {
                db.TabelaListas.Add(tabelaLista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabelaLista);
        }

        // GET: TabelaListas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaLista tabelaLista = db.TabelaListas.Find(id);
            if (tabelaLista == null)
            {
                return HttpNotFound();
            }
            return View(tabelaLista);
        }

        // POST: TabelaListas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imiePierwsze,imieDrugie,nazwisko,nazwiskoRodowe,ulica,numerDomu,numerMieszkania,kod,miasto,dataUrodzenia,miejsceUrodzenia,pesel,nip,imieOjca,imieMatki,nazwiskoMatki,plec,dokumentTyp,dokumentWydany,dokumentNumer,email,telefon,wyksztalcenie,obywatelstwo,narodowosc")] TabelaLista tabelaLista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabelaLista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabelaLista);
        }

        // GET: TabelaListas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaLista tabelaLista = db.TabelaListas.Find(id);
            if (tabelaLista == null)
            {
                return HttpNotFound();
            }
            return View(tabelaLista);
        }

        // POST: TabelaListas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabelaLista tabelaLista = db.TabelaListas.Find(id);
            db.TabelaListas.Remove(tabelaLista);
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
