using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assign4ErrorHandling.Utilities;

namespace Assign4ErrorHandling.Handlers
{
	public class CustomHandleErrorAttribute : HandleErrorAttribute
	{
		public override void OnException(ExceptionContext filterContext)
		{
			//Get the exception
			Exception ex = filterContext.Exception;

			string viewName = "Error";

			//Get current controller and action
			string currentController = (string)filterContext.RouteData.Values["controller"];
			string currentActionName = (string)filterContext.RouteData.Values["action"];

			if (ex is ArgumentException || currentController == "Movie")
			{
				if (ex is ArgumentException)
				{
					viewName = "ErrorArgument";
				}
				else
					viewName = "Error";
			}
			else if (ex is CustomApplicationException || currentController == "Book")
			{
				if (ex is CustomApplicationException)
					viewName = "ErrorCustom";
				else
					viewName = "Error";
			}

			
			Logger.Instance.LogException(ex);

			


			//Create the error model information
			HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, currentController, currentActionName);
			ViewResult result = new ViewResult
			{
				ViewName = viewName,
				ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
				TempData = filterContext.Controller.TempData
			};

			filterContext.Result = result;
			filterContext.ExceptionHandled = true;

			// Call the base class implementation:
			base.OnException(filterContext);
		}
	}
}