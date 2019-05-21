using CasePortal.Common;
using CasePortal.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasePortal.Authorize
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public string Permission { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                                   || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (skipAuthorization)
            {
                return;
            }
            if (HttpContext.Current.Session["user"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Account/Login");
            }
            else
            {
                var user = (User)HttpContext.Current.Session["user"];
                if (!UserRoles.Check(Permission, user))
                {
                    HttpContext.Current.Session["user"] = null;
                    filterContext.Result = new HttpUnauthorizedResult();

                }

            }
        }
    }
}