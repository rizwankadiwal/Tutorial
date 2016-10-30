using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankOfBit.Models;

namespace BankOfBit.Controllers
{
    public class ChequingAccountController : Controller
    {
        private BankOfBitContext db = new BankOfBitContext();

        //
        // GET: /ChequingAccount/

        public ActionResult Index()
        {
            return View(db.SavingsAccounts.ToList());
        }

        //
        // GET: /ChequingAccount/Details/5

        public ActionResult Details(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            return View(chequingaccount);
        }

        //
        // GET: /ChequingAccount/Create

        public ActionResult Create()
        {
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateID", "AccountStateID");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName");
            return View();
        }

        //
        // POST: /ChequingAccount/Create

        [HttpPost]
        public ActionResult Create(ChequingAccount chequingaccount)
        {
            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(chequingaccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateID", "AccountStateID", chequingaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", chequingaccount.ClientId);
            return View(chequingaccount);
        }

        //
        // GET: /ChequingAccount/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateID", "AccountStateID", chequingaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", chequingaccount.ClientId);
            return View(chequingaccount);
        }

        //
        // POST: /ChequingAccount/Edit/5

        [HttpPost]
        public ActionResult Edit(ChequingAccount chequingaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chequingaccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateID", "AccountStateID", chequingaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", chequingaccount.ClientId);
            return View(chequingaccount);
        }

        //
        // GET: /ChequingAccount/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            return View(chequingaccount);
        }

        //
        // POST: /ChequingAccount/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            db.BankAccounts.Remove(chequingaccount);
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