using HRMS.Abstract;
using HRMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HRMS.Controllers
{
    public class ApplicantController : Controller
    {
        public readonly IApplicationRepository applicationrepository;
        
        private IHostingEnvironment _hostingEnvironment;
        
        private static Random random = new Random();
        
        public ApplicantController(IApplicationRepository appRepository, IHostingEnvironment environment)
        {
            applicationrepository = appRepository;
            _hostingEnvironment = environment;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Jobdetails()
        {
            ViewBag.Jobdetails = applicationrepository.jobrequest();
            return View();
        }
        
        [HttpPost]
        public IActionResult Jobdetails(string fname, string lname, string recruitmentId, string mobileno, string email, IFormFile AddImage)
        {

            Application app = new Application();
            app.FirstName = fname;
            app.LastName = lname;
            app.Recruitmentid = recruitmentId;
            app.MobileNo = mobileno;
            app.Email = email;
            app.Resume = SaveToPhysicalLocation(AddImage);
            int count = applicationrepository.Saveapplication(app);
            if (count > 0)
            {
                TempData["Message"] = "Outward created successfully";
                return RedirectToAction("Jobdetails", "Applicant");
            }

            else
            {
                TempData["WarningMessage"] = "Please select importer name";
                return RedirectToAction("Jobdetails", "Applicant");
            }

            return View();
        }
        [HttpPost]
        
        public IActionResult EditUser(int Id)
        {
            var data = applicationrepository.GetJobRequest(Id);
            TempData["Delete"] = "<script>alert('Data Edited')</script>";
            return Json(data);
        }
        
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        private string SaveToPhysicalLocation(IFormFile AddImage)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Imagefolder");
            string filePath = string.Empty;
            if (AddImage.Length > 0)
            {
                string randomFileName = RandomString(10);
                string file_Extension = AddImage.ContentType;
                string fileExtenstion = AddImage.FileName.Split('.')[1];
                filePath = Path.Combine(uploads, randomFileName + "." + fileExtenstion);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    AddImage.CopyTo(fileStream);
                }

                return randomFileName + "." + fileExtenstion;
            }
            return string.Empty;
        }
        
        [HttpGet]
        public IActionResult Applicationlist()
        {
            ViewBag.Applicationlist = applicationrepository.applicationlist();
            return View();
        }

    }


}
    

