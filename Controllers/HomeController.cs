using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheSnehiNetwork.Models;







namespace TheSnehiNetwork.Controllers
{
    public class HomeController : Controller
    {

        private CodeFirst db = new CodeFirst();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> ClientRegister(UserTable userTable)
        {

            if (ModelState.IsValid)
            {
                db.UserTables.Add(userTable);
                await db.SaveChangesAsync();

                HttpContext.Session["name"] = userTable.UserName;
                HttpContext.Session["email"] = userTable.UserMail;
                HttpContext.Session["password"] = userTable.UserPassword;
         

                return RedirectToAction("Index");
            }
            return View(userTable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserTable userTable)
        {

            try
            {
                var obj = db.UserTables.Where(x => x.UserMail.Equals(userTable.UserMail) && x.UserPassword.Equals(userTable.UserPassword)).FirstOrDefault();
                if (obj != null)
                {

                    HttpContext.Session["name"] = obj.UserName;
                    HttpContext.Session["email"] = obj.UserMail;
                    HttpContext.Session["password"] = obj.UserPassword;
                }
                else
                {
                   Equals("Invalid Request");
                   return Content("InValid Data");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Overview()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }





        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Members()
        {
            return View(await db.UserTables.ToListAsync());
        }


        public ActionResult Community()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Pages()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Store()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        public ActionResult Blog()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }






    }
}