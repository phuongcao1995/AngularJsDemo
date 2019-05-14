using AutoMapper;
using CasePortal.Repositories;
using CasePortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CasePortal.Controllers
{
    public class HomeController : Controller
    {
        HomeRepository homeRepository = new HomeRepository();

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

        [HttpGet]
        public JsonResult GetLog(string keyword, DateTime? notificationDateStart, DateTime? notificationDateEnd,
            DateTime? incidentDateStart, DateTime? incidentDateEnd, int[] incidentTypeIds, int? districtId)
        {
            var list = homeRepository.GetLog(keyword, notificationDateStart, notificationDateEnd,
             incidentDateStart, incidentDateEnd, incidentTypeIds, districtId);
            return Json(Mapper.Map<IEnumerable<LogViewModel>>(list).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}