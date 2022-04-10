using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheSnehiNetwork.Models;

namespace TheSnehiNetwork.Controllers
{
    public class UserCodeFirstController : Controller
    {
        private CodeFirst db = new CodeFirst();

        // GET: UserCodeFirst
        public async Task<ActionResult> Index()
        {
            return View(await db.UserTables.ToListAsync());
        }

        // GET: UserCodeFirst/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = await db.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // GET: UserCodeFirst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCodeFirst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdUser,UserName,UserMail,UserPassword")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.UserTables.Add(userTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userTable);
        }

        // GET: UserCodeFirst/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = await db.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: UserCodeFirst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdUser,UserName,UserMail,UserPassword")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userTable);
        }

        // GET: UserCodeFirst/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = await db.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: UserCodeFirst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserTable userTable = await db.UserTables.FindAsync(id);
            db.UserTables.Remove(userTable);
            await db.SaveChangesAsync();
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
