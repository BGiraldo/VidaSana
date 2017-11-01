using System.Web;
using System.Web.Mvc;

namespace Eam.Ingenieria.Matagym
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
