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
        private readonly HomeRepository _homeRepository = new HomeRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllLog()
        {
            var list = Mapper.Map<IEnumerable<LogViewModel>>(_homeRepository.GetAllLog()).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLog(string keyword, DateTime? notificationDateStart, DateTime? notificationDateEnd,
            DateTime? incidentDateStart, DateTime? incidentDateEnd, int[] incidentTypeIds, int? districtId)
        {
            var list = _homeRepository.GetLog(keyword, notificationDateStart, notificationDateEnd,
             incidentDateStart, incidentDateEnd, incidentTypeIds, districtId);
            return Json(Mapper.Map<IEnumerable<LogViewModel>>(list).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null || id == 0 || _homeRepository.GetLogById(id.Value) == null)
            {
                return HttpNotFound();
            }
            ViewBag.LogId = id;
            return View();
        }

        [HttpGet]
        public JsonResult GetLogById(int id)
        {
            var log = Mapper.Map<LogViewModel>(_homeRepository.GetLogById(id));
            return Json(log, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMediasByLogId(int id)
        {
            var medias = Mapper.Map<IEnumerable<MediaViewModel>>(_homeRepository.GetMediasByLogId(id)).ToList();
            return Json(medias, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDocumentsByLogId(int id)
        {
            var documents = Mapper.Map<IEnumerable<DocumentViewModel>>(_homeRepository.GetDocumentsByLogId(id)).ToList();
            return Json(documents, JsonRequestBehavior.AllowGet);
        }
    }
}