using Assign4ErrorHandling.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assign4ErrorHandling.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
			throw new CustomApplicationException();
            return View();
        }
    }
}