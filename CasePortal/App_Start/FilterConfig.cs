using CasePortal.Repositories;
using System.Web;
using System.Web.Mvc;

namespace CasePortal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            AutoMapperConfig.Initialize();
        }
    }
}
