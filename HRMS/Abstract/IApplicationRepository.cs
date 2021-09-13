using HRMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Abstract
{
    public interface IApplicationRepository
    {
        UserCredential CheckLogin(string username, string password);
        Role GetRole(int? RoleId);
        AdminUser GetAdminUser(int? RegId);
        int SaveAdminuser(AdminUser adminUser);
        List<Department> department();
        List<AdminUser> AdminUsers();
        List<Designation> designation();
        List<Role> role();
        int DeleteUser(int ID);
        int SaveDepartment(Department departmentdetails);
        int SaveDesignation(Designation designationdetails);
        int SaveRole(Role roledetails);
        Department GetDepartment(int id);
        int DeleteDepartment(int id);
        Designation GetDesignation(int id);
        int DeleteDesignation(int id);
        Role GetRole(int id);
        int DeleteRole(int id);
        string EncodeBase64(string value);
        string DecodeBase64(string value);
        int SaveRecruitment(Recruitment recruitment);
        List<ExperienceTable> Experence_Table();
        List<Sp_Recruitment> Sp_Recruitment();
        string RecruitmentId();
        Sp_Recruitment Sp_Recruitment_Getbyid(int? PosiId);
        int SaveEmployee(EmpJoining EmpJng);
        List<EmpDetails> EmpDetailss();
        List<EmpBankDetails> EmpBankDetailss();
        List<EmpEdu_ProfDetails> EmpEdu_ProfDetailss();
        List<SelectListItem> GenderList();
        List<SelectListItem> MaritalList();
        List<SelectListItem> BloodGroupList();
    }
}
