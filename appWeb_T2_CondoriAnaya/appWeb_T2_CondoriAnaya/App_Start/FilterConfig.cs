using System.Web;
using System.Web.Mvc;

namespace appWeb_T2_CondoriAnaya
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
