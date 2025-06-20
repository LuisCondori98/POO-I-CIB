using System.Web;
using System.Web.Mvc;

namespace AppWebT1CondoriAnayaLuis
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
