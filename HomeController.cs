using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF6_Example.Models;

namespace MVC_EF6_Example.Controllers
{
    public class HomeController : Controller
    {
        MyDBContext db = new MyDBContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                /*var count = (from c in db.Customers where c.CustomerID == model.LoginID && c.CustomerPassword == model.Password select c).Count();*/
                var count = db.Customers.Count(c => c.CustomerID == model.LoginID && c.CustomerPassword == model.Password);
                if(count>0)
                {
                    Session["loginid"] = model.LoginID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.msg = "Invalid ID or Password";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            int loginid = Convert.ToInt32(Session["loginid"]);
            ViewBag.loginid = loginid;
            return View();
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerModel model)
        {
            db.Customers.Add(model);
            db.SaveChanges();//will update Database
            ViewBag.msg = "Customer Added : " + model.CustomerID;
            return View();
        }
        public ActionResult Search()
        {
            List<CustomerModel> list = new List<CustomerModel>();
            return View(list);
        }    
        [HttpPost]
        public ActionResult Search(string key)
        {
            /*var data = (from c in db.Customers where c.CustomerID.ToString().Contains(key) || c.CustomerName.Contains(key) || c.CustomerEmailID.Contains(key) select c).ToList();*/
            var data = db.Customers.Where(c => c.CustomerID.ToString().Contains(key) || c.CustomerName.Contains(key) || c.CustomerEmailID.Contains(key)).ToList();
            return View(data);
        }
        public ActionResult Find(int id)
        {
            /*var model = (from c in db.Customers where c.CustomerID == id select c).FirstOrDefault();*/
            var model = db.Customers.FirstOrDefault(c => c.CustomerID == id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            /*var model = (from c in db.Customers where c.CustomerID == id select c).FirstOrDefault();*/
            var model = db.Customers.FirstOrDefault(c => c.CustomerID == id);
            db.Customers.Remove(model);
            db.SaveChanges();
            return View("v_customerdeleted");
        }
        public ActionResult Edit(int id)
        {
            /*var model = (from c in db.Customers where c.CustomerID == id select c).FirstOrDefault();*/
            var model = db.Customers.FirstOrDefault(c => c.CustomerID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            /*var dbmodel = (from c in db.Customers where c.CustomerID == model.CustomerID select c).FirstOrDefault();*/
            var dbmodel = db.Customers.FirstOrDefault(c => c.CustomerID == model.CustomerID);
            dbmodel.CustomerCity = model.CustomerCity;
            dbmodel.CustomerEmailID = model.CustomerEmailID;
            db.SaveChanges();
            return View("v_updated");
        }
    }
}