using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Memory_Game.Models;

namespace Memory_Game.Controllers
{
    public class MenuController : Controller
    {
        private MemoryGameDBEntities db = new MemoryGameDBEntities();

        /// <summary>
        /// The connection string for connecting to the database
        /// </summary>
        public string ConString { get; set; }

        public MenuController()
        {
            // set the connection string
            string entityConnectionString = ConfigurationManager.ConnectionStrings["MemoryGameDBEntities"].ConnectionString;
            ConString = new EntityConnectionStringBuilder(entityConnectionString).ProviderConnectionString;
        }

        // GET: Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Menu/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Id,username,password")] User user, string submit)
        {
            if (submit.Equals("Create Account") && !string.IsNullOrEmpty(user.username) && !string.IsNullOrEmpty(user.password))
            {

                // store the manager in the database
                string connectionString = ConString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into Users (username, password) Values " +
                        $"('{user.username}', '{user.password}')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                
                return View("MainMenu", user);
            }
            else if(submit.Equals("Login") && !string.IsNullOrEmpty(user.username) && !string.IsNullOrEmpty(user.password))
            {
                return View("MainMenu", user);
            }
            else
            {
                // display error messages
                return View();
            }
        }

        // GET: Menu/Edit/5
        public ActionResult Account(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Account([Bind(Include = "Id,username,password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
