using Assign4ErrorHandling.Handlers;
using System.Web;
using System.Web.Mvc;

namespace Assign4ErrorHandling
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			//filters.Add(new HandleErrorAttribute());

			filters.Add(new CustomHandleErrorAttribute());
		}
	}
}
