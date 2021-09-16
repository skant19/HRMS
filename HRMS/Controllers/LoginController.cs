using HRMS.Abstract;
using HRMS.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Controllers
{
    public class LoginController : Controller
    {
        public readonly IApplicationRepository applicationrepository;
        public LoginController(IApplicationRepository appRepository)
        {
            applicationrepository = appRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.captcha = RandomString(6);
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                string pwd = applicationrepository.EncodeBase64(password);
                var data = applicationrepository.CheckLogin(username, pwd);

                if (data != null)
                {
                    int? regid = data.RegistrationId;
                    int? roleid = applicationrepository.GetAdminUser(regid).RoleId;
                    
                   

                    if (roleid == 1)
                    {
                       HttpContext.Session.SetString("roleid", roleid.ToString());
                        HttpContext.Session.SetString("regid", regid.ToString());
                        HttpContext.Session.SetString("regid", applicationrepository.GetAdminUser(regid).FirstName);
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (roleid == 2)
                    {
                        HttpContext.Session.SetString("roleid", roleid.ToString());
                        HttpContext.Session.SetString("regid", regid.ToString());
                        HttpContext.Session.SetString("regid", applicationrepository.GetAdminUser(regid).FirstName);
                        return RedirectToAction("Manager", "User");
                    }
                    else if (roleid == 3)
                    {
                        HttpContext.Session.SetString("roleid", roleid.ToString());
                        HttpContext.Session.SetString("regid", regid.ToString());
                        HttpContext.Session.SetString("regid", applicationrepository.GetAdminUser(regid).FirstName);
                        return RedirectToAction("TL", "User");
                    }
                    else if (roleid == 4)
                    {
                        HttpContext.Session.SetString("roleid", roleid.ToString());
                        HttpContext.Session.SetString("regid", regid.ToString());
                        HttpContext.Session.SetString("regid", applicationrepository.GetAdminUser(regid).FirstName);
                        return RedirectToAction("HR", "User");
                    }
                    else
                    {
                        HttpContext.Session.SetString("roleid", roleid.ToString());
                        HttpContext.Session.SetString("regid", regid.ToString());
                        HttpContext.Session.SetString("regid", applicationrepository.GetAdminUser(regid).FirstName);
                        return RedirectToAction("HRm", "User");
                    }
                }
                else
                {
                    TempData["Message"] = "Username or password is incorrect";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Something went wrong";
                return RedirectToAction("Login", "Home");
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [HttpGet]
        public IActionResult RefreshCaptcha()
        {
            return Json(RandomString(6));
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
