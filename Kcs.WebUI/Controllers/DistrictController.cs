using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kcs.WebUI.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Kcs.WebUI.Controllers
{
    public class DistrictController : Controller
    {
        [HttpPost]
        public JsonResult GetDistrictList(int provienceId)
        {
            var districtList = ProvienceDistrictHelper.GetDistrictList(provienceId);
            return Json(districtList);
        }
    }
}