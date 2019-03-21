using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kcs.Business.Abstract;
using Kcs.Entity.Concrete;
using Kcs.WebUI.Helper;
using Kcs.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kcs.WebUI.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult UpdatePerson()
        {
            try
            {
                var id = User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
               .Select(c => c.Value).SingleOrDefault();
                var person = _personService.GetPerson(Convert.ToInt32(id));
                if (person != null)
                {
                    var provienceList = ProvienceDistrictHelper.GetProvienceList();
                    var disrictList = ProvienceDistrictHelper.GetDistrictList(person.ProvinceId);
                    ViewBag.ProvienceList = new SelectList(provienceList, "ProvienceId", "ProvienceName", person.ProvinceId);
                    ViewBag.DistrictList = new SelectList(disrictList, "DistrictId", "DistrictName", person.DistrictId);
                    return View(person);
                }
                return RedirectToAction("Index", "Person");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdatePerson(PersonViewModel personViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var person = _personService.GetPerson(personViewModel.PersonId);

                    person.PersonName = personViewModel.PersonName;
                    person.PersonSurname = personViewModel.PersonSurname;
                    person.PersonPhone = personViewModel.PersonPhone;
                    person.PersonBirthday = personViewModel.PersonBirthday;
                    person.ProvinceId = personViewModel.ProvinceId;
                    person.DistrictId = personViewModel.DistrictId;
                    person.PersonEmail = personViewModel.PersonEmail;

                    _personService.Update(person);
                    return Json(new AlertViewModel { Message = "Başarılı", ProcessStatus = true });
                }
                else
                {
                    var errorMessageList = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).Select(x => x.FirstOrDefault().ErrorMessage).ToList();
                    string message = "";
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in errorMessageList)
                    {
                        sb.AppendLine(item);
                    }

                    message = sb.ToString();

                    return Json(new AlertViewModel { Message = message, ProcessStatus = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new AlertViewModel { Message = ex.Message, ProcessStatus = false });
            }
        }


        public IActionResult CreateUser()
        {
            var provienceList = ProvienceDistrictHelper.GetProvienceList();
            var disrictList = ProvienceDistrictHelper.GetDistrictList();
            ViewBag.ProvienceList = new SelectList(provienceList, "ProvienceId", "ProvienceName");
            ViewBag.DistrictList = new SelectList(disrictList, "DistrictId", "DistrictName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(PersonCreateViewModel personCreateViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Person person = new Person
                    {
                        PersonName = personCreateViewModel.PersonName,
                        PersonSurname = personCreateViewModel.PersonSurname,
                        PersonPhone = personCreateViewModel.PersonPhone,
                        PersonEmail = personCreateViewModel.PersonEmail,
                        PersonBirthday = personCreateViewModel.PersonBirthday,
                        ProvinceId = personCreateViewModel.ProvinceId,
                        DistrictId = personCreateViewModel.DistrictId,
                        Password = personCreateViewModel.Password
                    };
                    _personService.Add(person);
                    return Json(new AlertViewModel { Message = "Başarılı", ProcessStatus = true });
                }
                else
                {
                    var errorMessageList = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).Select(x => x.FirstOrDefault().ErrorMessage).ToList();
                    string message = "";
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in errorMessageList)
                    {
                        sb.AppendLine(item);
                    }

                    message = sb.ToString();

                    return Json(new AlertViewModel { Message = message, ProcessStatus = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new AlertViewModel { Message = ex.Message, ProcessStatus = false });
            }
        }
    }
}