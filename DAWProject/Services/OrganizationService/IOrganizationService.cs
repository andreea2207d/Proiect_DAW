using System;
using System.Linq;
using DAWProject.Models;

namespace DAWProject.Services.OrganizationService
{
    public interface IOrganizationService
    {
        IQueryable<Role> FindAllRoles();
        void CreateRole(Role role);
        void EditRole(Role role);
        void DeleteRole(Guid roleId);
        void AssignRoleToUser(Guid userId, Guid roleId);
        
        IQueryable<Department> FindAlLDepartments();
        void CreateDepartment(Department department);
        void EditDepartment(Department department);
        void DeleteDepartment(Guid departmentId);
        void AssignUserToDepartment(Guid userId, Guid departmentId);
    }
}