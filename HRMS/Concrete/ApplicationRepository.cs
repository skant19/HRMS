using HRMS.Abstract;
using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMS.Concrete
{
    public class ApplicationRepository : IApplicationRepository
    {
        HRMSContext con = new HRMSContext();

        public UserCredential CheckLogin(string username, string password)
        {
            var data = con.UserCredentials.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            return data;
        }
        
        public Role GetRole(int? RoleId)
        {
            var data = con.Roles.Where(x => x.RoleId == RoleId).FirstOrDefault();

            return data;
        }
        
        public AdminUser GetAdminUser(int? RegId)
        {
            var data = con.AdminUsers.Where(x => x.RegistrationId == RegId).FirstOrDefault();

            return data;
        }
        
        public int SaveAdminuser(AdminUser adminUser)
        {
            if (adminUser.RegistrationId != 0)
            {
                var data = con.AdminUsers.Where(x => x.RegistrationId == adminUser.RegistrationId).FirstOrDefault();
                data.RegistrationId = adminUser.RegistrationId;
                data.FirstName = adminUser.FirstName;
                data.LastName = adminUser.LastName;
                data.DepartmentId = adminUser.DepartmentId;
                data.DesignationId = adminUser.DesignationId;
                data.Dob = adminUser.Dob;
                data.MobileNo = adminUser.MobileNo;
                data.RoleId = adminUser.RoleId;
                

                con.SaveChanges();
                return 1;
            }
            else
            {
                AdminUser obj = new AdminUser();
                obj.RegistrationId = adminUser.RegistrationId;
                obj.FirstName = adminUser.FirstName;
                obj.LastName = adminUser.LastName;
                obj.DepartmentId = adminUser.DepartmentId;
                obj.DesignationId = adminUser.DesignationId;
                obj.Email = adminUser.Email;
                obj.Dob = adminUser.Dob;
                obj.MobileNo = adminUser.MobileNo;
                obj.RoleId = adminUser.RoleId;
                
                con.AdminUsers.Add(obj);
                con.SaveChanges();


                UserCredential UC = new UserCredential();

                string password = CreatePassword(6);
                string encpassword = EncodeBase64(password);

                UC.UserName = adminUser.Email;
                UC.Password = encpassword;
                UC.RegistrationId = obj.RegistrationId;

                UC.IsActive = true;
                UC.IsDeleted = false;

                con.UserCredentials.Add(UC);
                con.SaveChanges();


                string sub = "Timesheet credential detail";
                var body = new StringBuilder();
                body.AppendFormat("Hello, {0}\n", obj.FirstName + " " + obj.LastName);
                body.AppendLine("<br/>");
                body.AppendLine(@"Please find the below creadential detail for login");
                body.AppendLine("<br/>");
                body.AppendLine("<br/>");
                body.AppendLine(@"Username: " + UC.UserName);
                body.AppendLine("<br/>");
                body.AppendLine(@"Password: " + password);

                string mailbody = body.ToString();
                SendMail(obj.Email, sub, body.ToString());

                return 2;

            }

        }
        
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        
        public bool SendMail(string to, string subject, string body)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("cimsdev2020@gmail.com");
            mail.Subject = subject;
            string Body = body;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("cimsdev2020@gmail.com", "India@12345"); // Enter seders User name and password       
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return true;
        }
        
        public string EncodeBase64(string value)
        {
            var valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(valueBytes);
        }

        public string DecodeBase64(string value)
        {
            var valueBytes = System.Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }
        
        public List<AdminUser> AdminUsers()
        {
            var data = con.AdminUsers.ToList();
            return data;
        }
        
        public int DeleteUser(int ID)
        {
            var data = con.AdminUsers.Where(x => x.RegistrationId == ID).FirstOrDefault();
            con.AdminUsers.Remove(data);
            con.SaveChanges();
            return 1;
        }

        public List<Department> department()
        {
            var data = con.Departments.ToList();
            return data;
        }
        
        public int SaveDepartment(Department obj)
        {
            if (obj.DepartmentId != 0)
            {
                var data = con.Departments.Where(x => x.DepartmentId == obj.DepartmentId).FirstOrDefault();
                data.DepartmentName = obj.DepartmentName;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Department obj1 = new Department();
                obj1.DepartmentName = obj.DepartmentName;
                obj1.IsActive = true;
                obj1.IsDeleted = false;
                obj1.CreatedBy = obj.CreatedBy;
                con.Departments.Add(obj1);
                con.SaveChanges();
                return 2;
            }
        }
        
        public Department GetDepartment(int id)
        {
            var data = con.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            return data;
        }

        public int DeleteDepartment(int id)
        {
            var data = con.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            con.Departments.Remove(data);
            con.SaveChanges();
            return 1;
        }

        public int SaveDesignation(Designation obj)
        {
            if (obj.DesignationId != 0)
            {
                var data = con.Designations.Where(x => x.DesignationId == obj.DesignationId).FirstOrDefault();
                data.DesignationName = obj.DesignationName;


                con.SaveChanges();

                return 1;
            }
            else
            {
                Designation obj1 = new Designation();
                obj1.DesignationName = obj.DesignationName;
                obj1.IsActive = true;
                obj1.IsDeleted = false;
                obj1.CreatedBy = obj.CreatedBy;
                con.Designations.Add(obj1);
                con.SaveChanges();
                return 2;
            }
        }

        public List<Designation> designation()
        {
            var data2 = con.Designations.ToList();
            return data2;
        }
        
        public Designation GetDesignation(int id)
        {
            var data1 = con.Designations.Where(x => x.DesignationId == id).FirstOrDefault();
            return data1;
        }

        public int DeleteDesignation(int id)
        {
            var data1 = con.Designations.Where(x => x.DesignationId == id).FirstOrDefault();
            con.Designations.Remove(data1);
            con.SaveChanges();
            return 1;
        }

        public int SaveRole(Role obj)
        {
            if (obj.RoleId != 0)
            {
                var data = con.Roles.Where(x => x.RoleId == obj.RoleId).FirstOrDefault();
                data.RoleName = obj.RoleName;
                con.SaveChanges();
                return 1;
            }
            else
            {
                Role obj1 = new Role();
                obj1.RoleName = obj.RoleName;
                obj1.IsActive = true;
                obj1.IsDeleted = false;
                obj1.CreatedBy = obj.CreatedBy;
                con.Roles.Add(obj1);
                con.SaveChanges();
                return 2;
            }
        }

        public List<Role> role()
        {
            var data = con.Roles.ToList();
            return data;
        }
       
        public Role GetRole(int id)
        {
            var data2 = con.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            return data2;
        }

        public int DeleteRole(int id)
        {
            var data2 = con.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            con.Roles.Remove(data2);
            con.SaveChanges();
            return 1;
        }

        public int SaveRecruitment(Recruitment recruitment)
        {
            Recruitment Obj = new Recruitment();
            Obj.Position = recruitment.Position;
            Obj.Experience = recruitment.Experience;
            Obj.Technology = recruitment.Technology;
            Obj.Remark = recruitment.Remark;
            Obj.NoofResources = recruitment.NoofResources;
            con.Recruitments.Add(Obj);
            con.SaveChanges();
            return 1;
        }

        public List<ExperienceTable> Experence_Table()
        {
            var data = con.ExperienceTables.ToList();
            return data;
        }

        public List<EmpDetails> EmpDetailss()
        {
            var data = con.EmpDetailss.ToList();
            return data;
        }

        public List<EmpBankDetails> EmpBankDetailss()
        {
            var data = con.EmpBankDetailss.ToList();
            return data;
        }

        public List<EmpEdu_ProfDetails> EmpEdu_ProfDetailss()
        {
            var data = con.EmpEdu_ProfDetailss.ToList();
            return data;
        }
       
        public List<Sp_Recruitment> Sp_Recruitment()
        {

            var students = con.Sp_Recruitments.FromSqlRaw("Sp_Recruitment").ToList();

                return students;
            
        }
        
        public List<SelectListItem> GenderList()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem
            {
                Text = "Select One",
                Value = "Select One"
            }); 
            items.Add(new SelectListItem
            {
                Text = "Male",
                Value = "Male"
            });
            items.Add(new SelectListItem
            {
                Text = "Female",
                Value = "Female"
            });
            items.Add(new SelectListItem
            {
                Text = "Other",
                Value = "Other"
            });
            return items;
        }

        public List<SelectListItem> MaritalList()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem
            {
                Text = "Select One",
                Value = "Select One"
            }); 
            items.Add(new SelectListItem
            {
                Text = "Single",
                Value = "Single"
            });
            items.Add(new SelectListItem
            {
                Text = "Married",
                Value = "Married"
            });
            items.Add(new SelectListItem
            {
                Text = "Divorced",
                Value = "Divorced"
            });
            items.Add(new SelectListItem
            {
                Text = "Separated",
                Value = "Separat"
            });
            items.Add(new SelectListItem
            {
                Text = "Widow",
                Value = "Widow"
            });
            return items;
        }
        
        public List<SelectListItem> BloodGroupList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Select One",
                Value = "Select One"
            });
            items.Add(new SelectListItem
            {
                Text = "A +ve",
                Value = "A +ve"
            });
            items.Add(new SelectListItem
            {
                Text = "A -ve",
                Value = "A -ve"
            });
            items.Add(new SelectListItem
            {
                Text = "B +ve",
                Value = "B +ve"
            });
            items.Add(new SelectListItem
            {
                Text = "B -ve",
                Value = "B -ve"
            });
            items.Add(new SelectListItem
            {
                Text = "AB +ve",
                Value = "AB +ve"
            });
            items.Add(new SelectListItem
            {
                Text = "AB -ve",
                Value = "AB -ve"
            });
            items.Add(new SelectListItem
            {
                Text = "O +ve",
                Value = "O +ve"
            });
            items.Add(new SelectListItem
            {
                Text = "O -ve",
                Value = "O -ve"
            });
            return items;
        }

        public string RecruitmentId()
        {
            var data = con.JobRequests.ToList().Count;
            string RecruitmentId = "";
            if (data == 0)
            {
                int id = 1;
                RecruitmentId = "OASYS" + "-" + id;
            }
            else
            {
                int id = data + 1;
                RecruitmentId = "OASYS" + "-" + id;
            }
            return RecruitmentId;
        }

        public Sp_Recruitment Sp_Recruitment_Getbyid(int? PosiId)
        {
            var data = con.Sp_Recruitments.Where(x => x.PositionId == PosiId).FirstOrDefault();
            return data;
        }

        public int SaveEmployee(EmpJoining EmpJng)
        {
            EmpDetails Obj = new EmpDetails();
            Obj.FirstName = EmpJng.EmpDtl.FirstName;
            Obj.LastName = EmpJng.EmpDtl.LastName;
            Obj.Doj = EmpJng.EmpDtl.Doj;
            Obj.Father_SpouseName = EmpJng.EmpDtl.Father_SpouseName;
            Obj.DesignationName = EmpJng.EmpDtl.DesignationName;
            Obj.Dob = EmpJng.EmpDtl.Dob;
            Obj.Gender = EmpJng.EmpDtl.Gender;
            Obj.MaritialStatus = EmpJng.EmpDtl.MaritialStatus;
            Obj.BloodGroup = EmpJng.EmpDtl.BloodGroup;
            Obj.TelephoneNo = EmpJng.EmpDtl.TelephoneNo;
            Obj.MobileNo = EmpJng.EmpDtl.MobileNo;
            Obj.Email = EmpJng.EmpDtl.Email;
            Obj.AltEmail = EmpJng.EmpDtl.AltEmail;
            Obj.AadhaarNo = EmpJng.EmpDtl.AadhaarNo;
            Obj.PanCardNo = EmpJng.EmpDtl.PanCardNo;
            Obj.EmgContactName = EmpJng.EmpDtl.EmgContactName;
            Obj.RelationWithEmp = EmpJng.EmpDtl.RelationWithEmp;
            Obj.EmgContactNo = EmpJng.EmpDtl.EmgContactNo;
            Obj.C_AddL1 = EmpJng.EmpDtl.C_AddL1;
            Obj.C_AddL2 = EmpJng.EmpDtl.C_AddL2;
            Obj.C_City = EmpJng.EmpDtl.C_City;
            Obj.C_State = EmpJng.EmpDtl.C_State;
            Obj.C_Zip = EmpJng.EmpDtl.C_Zip;
            Obj.C_Country = EmpJng.EmpDtl.C_Country;
            Obj.P_AddL1 = EmpJng.EmpDtl.P_AddL1;
            Obj.P_AddL2 = EmpJng.EmpDtl.P_AddL2;
            Obj.P_City = EmpJng.EmpDtl.P_City;
            Obj.P_State = EmpJng.EmpDtl.P_State;
            Obj.P_Zip = EmpJng.EmpDtl.P_Zip;
            Obj.P_Country = EmpJng.EmpDtl.P_Country;
            con.EmpDetailss.Add(Obj);
            con.SaveChanges();
            EmpBankDetails Obj1 = new EmpBankDetails();
            Obj1.BankName = EmpJng.EmpBankDtl.BankName;
            Obj1.AccountNo = EmpJng.EmpBankDtl.AccountNo;
            Obj1.ConfAccountNo = EmpJng.EmpBankDtl.ConfAccountNo;
            Obj1.IfscCode = EmpJng.EmpBankDtl.IfscCode;
            Obj1.UanNo = EmpJng.EmpBankDtl.UanNo;
            con.EmpBankDetailss.Add(Obj1);
            con.SaveChanges();

            if(EmpJng.EmpEduProfDtl.ToList().Count>0)
            {
                foreach (var item in EmpJng.EmpEduProfDtl)
                {
                    EmpEdu_ProfDetails Obj2 = new EmpEdu_ProfDetails();
                    Obj2.Degree = item.Degree;
                    Obj2.University = item.University;
                    Obj2.DFrom = item.DFrom;
                    Obj2.DTo = item.DTo;
                    Obj2.PercentageGrade = item.PercentageGrade;
                    Obj2.Specification = item.Specification;
                    Obj2.PrvOrganizationName = item.PrvOrganizationName;
                    Obj2.PrvDesignation = item.PrvDesignation;
                    Obj2.PrvJobLocation = item.PrvJobLocation;
                    Obj2.PrvWorkDuration = item.PrvWorkDuration;
                    Obj2.PrvManagerNo = item.PrvManagerNo;
                    con.EmpEdu_ProfDetailss.Add(Obj2);
                    con.SaveChanges();
                }
            }
            return 1;
        }
    }
}
