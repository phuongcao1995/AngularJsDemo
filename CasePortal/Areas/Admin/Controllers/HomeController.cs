using AutoMapper;
using CasePortal.Authorize;
using CasePortal.Common;
using CasePortal.Models;
using CasePortal.Repositories;
using CasePortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CasePortal.Areas.Admin.Controllers
{
    [Auth(Permission = Permission.SuperAdmin_Admin_Editor)]
    public class HomeController : BaseController
    {
        private readonly HomeRepository homeRepository = new HomeRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllLog()
        {
            var list = Mapper.Map<IEnumerable<LogViewModel>>(homeRepository.GetAllLog()).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [Auth(Permission = Permission.SuperAdmin_Admin)]
        [HttpPost]
        public JsonResult AddLog(Log log)
        {
            var result = homeRepository.AddLog(log);
            if (result)
            {
                return Json(new
                {
                    status = StatusCodes.Success,
                    message = String.Format(Constants.MessageSuccess, ObjectSystem.Log, ActionUser.Add)
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = StatusCodes.Error,
                    message = Constants.MessageError
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [Auth(Permission = Permission.SuperAdmin_Admin)]
        [HttpPost]
        public JsonResult UpdateLog(Log log)
        {
            var result = homeRepository.UpdateLog(log);
            if (result)
            {
                return Json(new
                {
                    status = StatusCodes.Success,
                    message = String.Format(Constants.MessageSuccess, ObjectSystem.Log, ActionUser.Update)
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = StatusCodes.Error,
                    message = Constants.MessageError
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [Auth(Permission = Permission.SuperAdmin_Admin)]
        [HttpPost]
        public JsonResult DeleteLog(Log log)
        {
            var result = homeRepository.DeleteLog(log);
            if (result)
            {
                return Json(new
                {
                    status = StatusCodes.Success,
                    message = String.Format(Constants.MessageSuccess, ObjectSystem.Log, ActionUser.Delete)
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    status = StatusCodes.Error,
                    message = Constants.MessageError
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}