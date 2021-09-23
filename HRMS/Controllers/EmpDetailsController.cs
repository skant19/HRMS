using HRMS.Abstract;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Controllers
{
    public class EmpDetailsController : Controller
    {
        public readonly IApplicationRepository applicationrepository;
       
        public EmpDetailsController(IApplicationRepository appRepository)
        {
            applicationrepository = appRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult JoiningForm()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult EmpJoining()
        {
            EmpJoining joining = new EmpJoining();
            ViewBag.EmpJoining = applicationrepository.EmpDetailss().ToList();
            ViewBag.EmpJoin = applicationrepository.EmpBankDetailss().ToList();
            ViewBag.EmpJoinee = applicationrepository.EmpEduDetailss().ToList();
            ViewBag.EmpJoinee = applicationrepository.EmpProfDetailss().ToList();
            joining.GenderList = applicationrepository.GenderList();
            joining.MaritalList = applicationrepository.MaritalList();
            joining.BloodGroupList = applicationrepository.BloodGroupList();
            return View(joining);
        }

        [HttpPost]
        public IActionResult EmpJoining(EmpJoining obj, string[] degree, string[] university, string[] dfrom, string[] dto, string[] percentagegrade, string[] specification, string[] prvorganisiation, string[] prvdesignation, string[] prvlocation, string[] prvworkduration, string[] prvmanagerno)
        {
            List<EmpEduDetails> EmpEduDetails = new List<EmpEduDetails>();
            EmpEduDetails obj1;
            obj1 = new EmpEduDetails();
            if (degree.Length > 0)
            {
                for (int i = 0; i < degree.Length; i++)
                {
                    obj1.Degree = degree[i];
                    obj1.University = university[i];
                    obj1.DFrom = Convert.ToDateTime(dfrom[i]);
                    obj1.DTo = Convert.ToDateTime(dto[i]);
                    obj1.PercentageGrade = percentagegrade[i];
                    obj1.Specification = specification[i];
                    EmpEduDetails.Add(obj1);
                    obj1 = new EmpEduDetails();
                }
            }

            List<EmpProfDetails> EmpProfDetails = new List<EmpProfDetails>();
            EmpProfDetails obj2;
            obj2 = new EmpProfDetails();
            if (prvorganisiation.Length > 0)
            {
                for (int i = 0; i < prvorganisiation.Length; i++)
                {
                    obj2.PrvOrganizationName = prvorganisiation[i];
                    obj2.PrvDesignation = prvdesignation[i];
                    obj2.PrvJobLocation = prvlocation[i];
                    obj2.PrvWorkDuration = prvworkduration[i];
                    obj2.PrvManagerNo = prvmanagerno[i];
                    EmpProfDetails.Add(obj2);
                    obj2 = new EmpProfDetails();
                }
            }

            obj.EmpEduDtls = EmpEduDetails;
            obj.EmpProfDtls = EmpProfDetails;
            int a = applicationrepository.SaveEmployee(obj);
            if (a > 1)
            {
                TempData["msggggg"] = "<script>alert('Details Submited Successfully')</script>";
                return RedirectToAction("Login", "Login");
            }
            else
            {
                TempData["msggggg"] = "AdminUser Updated Successfully";
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
