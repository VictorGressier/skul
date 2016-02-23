using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentApplication.Models;

namespace StudentWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			StudentRepository repository = new StudentRepository();
			var model = repository.GetAllStudents();
			return View(model);
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

		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id.HasValue)
			{
				int theID = id.Value;
				StudentRepository repository = new StudentRepository();
				Student model = repository.GetStudentById(theID);

				if (model == null)					return View("NotFound");				return View(model);			}			else
			{
				return View("NotFound");
			}
		}

		[HttpPost]
		public ActionResult Edit(int id, FormCollection formData)
		{
			StudentRepository repository = new StudentRepository();
			Student s = repository.GetStudentById(id);
			if (s != null)
			{
				UpdateModel(s);
				repository.UpdateStudent(s);
				return RedirectToAction("Index");
			}
			else
			{
				return View("NotFound");
			}
		}
		[HttpGet]
		public ActionResult Create()
		{
			return View(new Student());
		}

		[HttpPost]
		public ActionResult Create(FormCollection formData)
		{
			Student s = new Student();
			UpdateModel(s);
			StudentRepository repository = new StudentRepository();
			repository.AddStudent(s);
			return RedirectToAction("Index");
		}
	}
}