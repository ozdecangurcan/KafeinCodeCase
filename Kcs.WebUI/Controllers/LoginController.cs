using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kcs.Business.Abstract;
using Kcs.Entity.Concrete;
using Kcs.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Kcs.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IPersonService _personService;

        public LoginController(IPersonService personService)
        {
            _personService = personService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            if (LoginUser(loginModel.Email, loginModel.Password))
            {
                var user = _personService.LoginPerson(loginModel.Email, loginModel.Password);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid,user.PersonId.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                var props = new AuthenticationProperties();
                props.IsPersistent = loginModel.RememberMe;
                if (!loginModel.RememberMe)
                {
                    props.ExpiresUtc = DateTime.Now.AddMinutes(15);
                }

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

                return Json(new AlertViewModel { Message = "", ProcessStatus = true });
            }
            return Json(new AlertViewModel { Message = "Kullanıcı Bilgileri Hatalı", ProcessStatus = false });
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        private bool LoginUser(string mail, string password)
        {
            var user = _personService.LoginPerson(mail, password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                var person = _personService.GetPersonWithEmail(resetPasswordModel.EMail);
                if (person != null && ModelState.IsValid)
                {
                    person.Password = resetPasswordModel.Password;
                    _personService.Update(person);
                    return Json(new AlertViewModel { Message = "Başarılı", ProcessStatus = true });
                }
                return Json(new AlertViewModel { Message = "Bilgiler Hatalı", ProcessStatus = false });
            }
            catch (Exception ex)
            {
                return Json(new AlertViewModel { Message = ex.Message, ProcessStatus = false });
            }
        }
    }
}