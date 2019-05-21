using CasePortal.Common;
using CasePortal.Models;
using CasePortal.Repositories;
using System.Web.Mvc;

namespace CasePortal.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly AccountRepository accountRepository = new AccountRepository();

        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
              return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userLogin = accountRepository.Login(user);
            if (userLogin != null)
            {
                Session["user"] = userLogin;
                return Json(new
                {
                    status = StatusCodes.Success
                });
            }
            return Json(new
            {
                status = StatusCodes.Error
            });
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}