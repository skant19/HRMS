using HRMS.Abstract;
using HRMS.Concrete;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Controllers
{
    public class UserController : Controller
    {

        public readonly IApplicationRepository applicationrepository;
        public UserController(IApplicationRepository appRepository)
        {
            applicationrepository = appRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HR()
        {
            //ViewBag.Store = applicationrepository.Sp_Recruitment().Where(X=>X.PositionId==1).ToList();
            ViewBag.Store = applicationrepository.Sp_Recruitment().ToList();
            return View();
        }
        public IActionResult Manager()
        {
            return View();
        }
        public IActionResult TL()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Recruitment()
        {
            ViewBag.Experience = applicationrepository.Experence_Table().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Recruitment(Recruitment recruitment)
        {
            int a = applicationrepository.SaveRecruitment(recruitment);
            if (a > 0)
            {
                TempData["msg"] = "<script>alert('Recruitment Urge')</script>";
                //return RedirectToAction("AdminUser", "Admin");
                // TempData["Message"] = "AdminUser Created Successfully";
                return RedirectToAction("Recruitment", "User");

            }
            else
            {
                //return RedirectToAction("AdminUser", "Admin");
                TempData["Message"] = "AdminUser Updated Successfully";
                return RedirectToAction("Recruitment", "User");
            }
        }
        public IActionResult CreateJobProfile(int id)
        {
            ViewBag.data2=applicationrepository.Sp_Recruitment_Getbyid(id);
            JobRequest job = new JobRequest();
            job.RecruitmentId = applicationrepository.RecruitmentId();

            
            return View(job);
        }
      
    }
}
