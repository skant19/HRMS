using HRMS.Abstract;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Controllers
{
    public class AdminController : Controller
    {
        public readonly IApplicationRepository applicationrepository;
        
        public AdminController(IApplicationRepository appRepository)
        {
            applicationrepository = appRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Department()
        {
            ViewBag.data = applicationrepository.department();
            return View();
        }
        
        [HttpPost]
        public IActionResult Department(Department departmentdetails)
        {
            int count = applicationrepository.SaveDepartment(departmentdetails);
            if (count > 1)
            {
                TempData["DeptMessage"] = "Department Created Successfully";
                return RedirectToAction("Department", "Admin");
            }
            else
            {
                TempData["DeptMessage"] = "Department Updated Successfully";
                return RedirectToAction("Department", "Admin");
            }
        }

        [HttpPost]
        public IActionResult EditDepartment(int id)
        {
            var data = applicationrepository.GetDepartment(id);
            return Json(data);
        }

        public IActionResult DeleteDepartment(int id)
        {
            var data = applicationrepository.DeleteDepartment(id);
            TempData["DeptDeleteMessage"] = "Data Deleted Successfully";
            return RedirectToAction("Department", "Admin");
        }
        
        [HttpGet]
        public IActionResult Designation()
        {
            ViewBag.data = applicationrepository.designation();
            return View();
        }
        
        [HttpPost]
        public IActionResult Designation(Designation designationdetails)
        {
            int count = applicationrepository.SaveDesignation(designationdetails);
            if (count > 1)
            {
                TempData["DesgMessage"] = "Designation Created Successfully";
                return RedirectToAction("Designation", "Admin");
            }
            else
            {
                TempData["DesgMessage"] = "Designation Updated Successfully";
                return RedirectToAction("Designation", "Admin");
            }
        }

        [HttpPost]
        public IActionResult EditDesignation(int id)
        {
            var data1 = applicationrepository.GetDesignation(id);
            return Json(data1);
        }

        public IActionResult DeleteDesignation(int id)
        {
            var data = applicationrepository.DeleteDesignation(id);
            TempData["DesgDeleteMessage"] = "Data Deleted Successfully";
            return RedirectToAction("Designation", "Admin");
        }
        
        [HttpGet]
        public IActionResult Role()
        {
            ViewBag.data = applicationrepository.role();
            return View();
        }
        
        [HttpPost]
        public IActionResult Role(Role roledetails)
        {
            int count = applicationrepository.SaveRole(roledetails);
            if (count > 1)
            {
                TempData["RoleMessage"] = "Role Created Successfully";
                return RedirectToAction("Role", "Admin");
            }
            else
            {
                TempData["RoleMessage"] = "Role Updated Successfully";
                return RedirectToAction("Role", "Admin");
            }
        }

        [HttpPost]
        public IActionResult EditRole(int id)
        {
            var data2 = applicationrepository.GetRole(id);
            return Json(data2);
        }

        public IActionResult DeleteRole(int id)
        {
            var data = applicationrepository.DeleteRole(id);
            TempData["RoleDeleteMessage"] = "Data Deleted Successfully";
            return RedirectToAction("Role", "Admin");
        }
        
        [HttpGet]
        public IActionResult AdminUser()
        {
            ViewBag.Department = applicationrepository.department().ToList();
            ViewBag.Designation1 = applicationrepository.designation().ToList();
            ViewBag.Adminuser = applicationrepository.AdminUsers().ToList();
            ViewBag.Role = applicationrepository.role().ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult AdminUser(AdminUser obj)
        {
            int a = applicationrepository.SaveAdminuser(obj);
            if (a > 1)
            {
                TempData["msg"] = "<script>alert('Admin User Created')</script>";
                return RedirectToAction("AdminUser", "Admin");

            }
            else
            {
                TempData["Message"] = "AdminUser Updated Successfully";
                return RedirectToAction("AdminUser", "Admin");
            }
        }

        public IActionResult Delete(int ID)
        {
            var data = applicationrepository.DeleteUser(ID);
            return RedirectToAction("AdminUser", "Admin");
        }
       
        [HttpPost]
        public IActionResult EditUser(int ID)
        {
            var data = applicationrepository.GetAdminUser(ID);
            TempData["Delete"] = "<script>alert('Data Edited')</script>";
            return Json(data);
        }
    }
}
