﻿using Project3.DAL;
using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project3.Controllers
{
	public class HomeController : Controller
	{
		private DataContext db = new DataContext();

		public ActionResult Index()
		{
			IEnumerable<Stuff> theStuff = (from item in db.Items
										orderby item.Name ascending
										select item).ToList();
			return View(theStuff);
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

		public ActionResult SortStuff(int? i)
		{
			if (i == null)
			{
				return View("Index");
			}

			IEnumerable<Stuff> theStuff = (from item in db.Items
										 orderby item.Name ascending
										 where item.Category == i.Value
										 select item).ToList();
			return View("Index", theStuff);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return View("Error");
			}

			Stuff theStuff = (from item in db.Items
						   where item.ID == id.Value
						   select item).SingleOrDefault();

			if (theStuff == null)
			{
				return HttpNotFound();
			}
			ViewBag.StuffID = new SelectList(db.Items, "ID", "Name", theStuff.ID);
			return View(theStuff);
		}

		[HttpPost]
		public ActionResult Edit(Stuff product)
		{
			if (ModelState.IsValid)
			{

				Stuff prod = (from item in db.Items
							  where item.ID == product.ID
							  select item).SingleOrDefault();


				prod.Name = product.Name;
				prod.Description = product.Description;
				prod.Category = product.Category;
				prod.Available = product.Available;
				prod.Price = product.Price;


				db.SaveChanges();

				return RedirectToAction("Index");

			}

			return View("Index");
		}

		public ActionResult Create()
		{
			ViewBag.StuffID = new SelectList(db.Items, "ID", "Name");
			return View();
		}

		[HttpPost]
		public ActionResult Create(Stuff product)
		{
			if (ModelState.IsValid)
			{
				db.Items.Add(product);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.StuffID = new SelectList(db.Items, "ID", "Name", product.ID);
			return View(product);
		}
	}
}