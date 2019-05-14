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
    public class DistrictController : Controller
    {
        DistrictRepository districtRepository = new DistrictRepository();

        [HttpGet]
        public JsonResult GetAllDistrict()
        {
            var list = Mapper.Map<IEnumerable<DistrictViewModel>>(districtRepository.GetAllDistrict()).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}