using AutoMapper;
using CasePortal.Authorize;
using CasePortal.Common;
using CasePortal.Repositories;
using CasePortal.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CasePortal.Areas.Admin.Controllers
{
    [Auth(Permission = Permission.SuperAdmin_Admin_Editor)]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllUser()
        {
            var list = Mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAllUser()).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}