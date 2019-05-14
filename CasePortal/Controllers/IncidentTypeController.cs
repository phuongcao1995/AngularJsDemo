using AutoMapper;
using CasePortal.Repositories;
using CasePortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasePortal.Controllers
{
    public class IncidentTypeController : Controller
    {
        IncidentTypeRepository incidentTypeRepository = new IncidentTypeRepository();

        [HttpGet]
        public JsonResult GetAllIncidentType()
        {
            var list = Mapper.Map<IEnumerable<IncidentTyleViewModel>>(incidentTypeRepository.GetAllIncidentTyle()).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}