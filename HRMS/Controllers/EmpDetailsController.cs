﻿using HRMS.Abstract;
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
            ViewBag.EmpJoinee = applicationrepository.EmpEdu_ProfDetailss().ToList();
            joining.GenderList = applicationrepository.GenderList();
            joining.MaritalList = applicationrepository.MaritalList();
            joining.BloodGroupList = applicationrepository.BloodGroupList();
            return View(joining);
        }
        [HttpPost]
        public IActionResult EmpJoining(EmpJoining obj, string Gender, string[] degree, string[] university, string[] dfrom, string[] dto, string[] percentagegrade, string[] specification, string[] prvorganisiation, string[] prvdesignation, string[] prvlocation, string[] prvworkduration, string[] prvmanagerno)
        {
            List<EmpEdu_ProfDetails> EmpEdu_ProfDetails = new
                List<EmpEdu_ProfDetails>();
            if(degree.Length>0)
            {
                for (int i= 0;i<degree.Length; i++)
                {
                    EmpEdu_ProfDetails obj1;
                    obj1 = new EmpEdu_ProfDetails();
                    obj1.Degree = degree[i];
                    obj1.University = university[i];
                    obj1.DFrom = Convert.ToDateTime(dfrom[i]);
                    obj1.DTo = Convert.ToDateTime(dto[i]);
                    obj1.PercentageGrade = percentagegrade[i];
                    obj1.Specification = specification[i];
                    obj1.PrvOrganizationName = prvorganisiation[i];
                    obj1.PrvDesignation = prvdesignation[i];
                    obj1.PrvJobLocation = prvlocation[i];
                    obj1.PrvWorkDuration = prvworkduration[i];
                    obj1.PrvManagerNo = prvmanagerno[i];
                    EmpEdu_ProfDetails.Add(obj1);
                }
            }
            obj.EmpEduProfDtl = EmpEdu_ProfDetails;
            int a = applicationrepository.SaveEmployee(obj);
            if (a > 1)
            {
                TempData["msg"] = "<script>alert('Details Submited')</script>";
                return RedirectToAction("EmpJoining", "EmpDetails");

            }
            else
            {
                TempData["Message"] = "AdminUser Updated Successfully";
                return RedirectToAction("EmpJoining", "EmpDetails");
            }
        }
    }
}