using AutoMapper;
using CasePortal.Repositories;
using CasePortal.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CasePortal.Controllers
{
    public class IncidentTypeController : Controller
    {
        private readonly IncidentTypeRepository _incidentTypeRepository = new IncidentTypeRepository();

        [HttpGet]
        public JsonResult GetAllIncidentType()
        {
            var list = Mapper.Map<IEnumerable<IncidentTyleViewModel>>(_incidentTypeRepository.GetAllIncidentTyle()).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}