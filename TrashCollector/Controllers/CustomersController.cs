﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db;
        Customer activeCustomer;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        private void MakeNextWorkOrder(int? id)
        {
            activeCustomer = db.Customers.Find(id);
            WorkOrder newOrder = new WorkOrder()
            {
                CustomerId = activeCustomer.Id,
                ScheduledPickup = AccountController.GetNextWeekday(DateTime.Today, activeCustomer.PickupDay),
                PickupCompleted = false,
                ServicePaidFor = false
            };
            db.WorkOrders.Add(newOrder);
            db.SaveChanges();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            if (Convert.ToDateTime(activeCustomer.NextPickup) < DateTime.Today)
            {
                MakeNextWorkOrder(id);
            }
                
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,Login,Password,ZipCode,PickupDay,AccountBalance,NextPickup,UserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public void SkipNextPickUp(int? id)
        {
            activeCustomer = db.Customers.Find(id);
            var orderToSkip = db.WorkOrders.Where(a => a.CustomerId == id && a.ScheduledPickup == activeCustomer.NextPickup).First();
            db.WorkOrders.Remove(orderToSkip);
        }
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,Login,Password,ZipCode,PickupDay,AccountBalance,NextPickup,UserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.NextPickup = AccountController.GetNextWeekday(DateTime.Today.AddDays(1), customer.PickupDay);
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", customer);
            }
            return View(customer);
        }
        

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Details");
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
