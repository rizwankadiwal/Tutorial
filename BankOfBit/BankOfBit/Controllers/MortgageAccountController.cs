using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BankOfBit.Models;

namespace BankOfBit.Controllers
{
    public class MortgageAccountController : ApiController
    {
        private BankOfBitContext db = new BankOfBitContext();

        // GET api/MortgageAccount
        public IEnumerable<MortgageAccount> GetMortgageAccounts()
        {
            var bankaccounts = db.BankAccounts.Include(m => m.AccountState).Include(m => m.Client);
            return (IEnumerable<MortgageAccount>)bankaccounts.AsEnumerable();
        }

        // GET api/MortgageAccount/5
        public MortgageAccount GetMortgageAccount(int id)
        {
            MortgageAccount mortgageaccount = (MortgageAccount)db.BankAccounts.Find(id);
            if (mortgageaccount == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return mortgageaccount;
        }

        // PUT api/MortgageAccount/5
        public HttpResponseMessage PutMortgageAccount(int id, MortgageAccount mortgageaccount)
        {
            if (ModelState.IsValid && id == mortgageaccount.BankAccountId)
            {
                db.Entry(mortgageaccount).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/MortgageAccount
        public HttpResponseMessage PostMortgageAccount(MortgageAccount mortgageaccount)
        {
            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(mortgageaccount);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mortgageaccount);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mortgageaccount.BankAccountId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/MortgageAccount/5
        public HttpResponseMessage DeleteMortgageAccount(int id)
        {
            MortgageAccount mortgageaccount = (MortgageAccount)db.BankAccounts.Find(id);
            if (mortgageaccount == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.BankAccounts.Remove(mortgageaccount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, mortgageaccount);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}