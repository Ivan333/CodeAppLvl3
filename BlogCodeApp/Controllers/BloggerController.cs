using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogCodeApp.DAL;
using BlogCodeApp.Models;

namespace BlogCodeApp.Controllers
{
    public class BloggerController : Controller
    {
        private BlogCodeAppContext db = new BlogCodeAppContext();

        // GET: Blogger
        public ActionResult Index()
        {
            return View(db.Bloggers.ToList());
        }

        //Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Blogger account)
        {
            if (ModelState.IsValid)
            {
                using (BlogCodeAppContext db = new BlogCodeAppContext())
                {
                    db.Bloggers.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Username + " succesfully registered.";

            }

            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Blogger user)
        {
            using (BlogCodeAppContext db = new BlogCodeAppContext())
            {
                var usr = db.Bloggers.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.BloggerID.ToString();
                    Session["UserName"] = usr.Username.ToString();
                    
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }

                return View();


            }
        }


        // GET: Blogger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogger blogger = db.Bloggers.Find(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }
            return View(blogger);
        }

        // GET: Blogger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogger/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BloggerID,Email,Username,Password,ConfirmPassword")] Blogger blogger)
        {
            if (ModelState.IsValid)
            {
                db.Bloggers.Add(blogger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogger);
        }

        // GET: Blogger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogger blogger = db.Bloggers.Find(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }
            return View(blogger);
        }

        // POST: Blogger/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BloggerID,Email,Username,Password,ConfirmPassword")] Blogger blogger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogger);
        }

        // GET: Blogger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogger blogger = db.Bloggers.Find(id);
            if (blogger == null)
            {
                return HttpNotFound();
            }
            return View(blogger);
        }

        // POST: Blogger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blogger blogger = db.Bloggers.Find(id);
            db.Bloggers.Remove(blogger);
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
