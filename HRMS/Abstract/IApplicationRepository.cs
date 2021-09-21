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
        Department GetDepartment(int id);
        Designation GetDesignation(int id);
        Role GetRole(int id);
        AdminUser GetAdminUser(int? RegId);
        Role GetRole(int? RoleId);
        Sp_Recruitment Sp_Recruitment_Getbyid(int? PosiId);

        string EncodeBase64(string value);
        string DecodeBase64(string value);
        string RecruitmentId();
        
        int SaveAdminuser(AdminUser adminUser);
        int SaveDepartment(Department departmentdetails);
        int SaveDesignation(Designation designationdetails);
        int SaveRole(Role roledetails);
        int DeleteUser(int ID);
        int DeleteDepartment(int id);
        int DeleteDesignation(int id);
        int DeleteRole(int id);
        int SaveRecruitment(Recruitment recruitment);
        int SaveEmployee(EmpJoining EmpJng);

        List<Department> department();
        List<AdminUser> AdminUsers();
        List<Designation> designation();
        List<Role> role();
        List<EmpDetails> EmpDetailss();
        List<EmpBankDetails> EmpBankDetailss();
        List<EmpEduDetails> EmpEduDetailss();
        List<EmpProfDetails> EmpProfDetailss();
        List<SelectListItem> GenderList();
        List<SelectListItem> MaritalList();
        List<SelectListItem> BloodGroupList();
        List<ExperienceTable> Experence_Table();
        List<Sp_Recruitment> Sp_Recruitment();
    }
}
