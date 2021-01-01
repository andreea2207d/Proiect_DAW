using System;
using System.Linq;
using DAWProject.Models;
using DAWProject.Repositories.DepartmentRepository;
using DAWProject.Repositories.RoleRepository;
using DAWProject.Repositories.UserRepository;

namespace DAWProject.Services.OrganizationService
{
    public class OrganizationService: IOrganizationService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;

        public OrganizationService(IRoleRepository roleRepository, IDepartmentRepository departmentRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
        }

        public IQueryable<Role> FindAllRoles()
        {
            return _roleRepository.GetAllAsQuerable();
        }

        public void CreateRole(Role role)
        {
            _roleRepository.Create(role);
            _roleRepository.Save();
        }

        public void EditRole(Role role)
        {
            _roleRepository.Update(role);
            _roleRepository.Save();
        }

        public void DeleteRole(Guid roleId)
        {
            var role = _roleRepository.FindById(roleId);
            _roleRepository.Delete(role);
            _roleRepository.Save();
        }
        
        public void AssignRoleToUser(Guid userId, Guid roleId)
        {
            var user = _userRepository.FindById(userId);
            user.RoleId = roleId;
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public IQueryable<Department> FindAlLDepartments()
        {
            return _departmentRepository.GetAllAsQuerable();
        }

        public void CreateDepartment(Department department)
        {
            _departmentRepository.Create(department);
            _departmentRepository.Save();
        }

        public void EditDepartment(Department department)
        {
            _departmentRepository.Update(department);
            _departmentRepository.Save();
        }

        public void DeleteDepartment(Guid departmentId)
        {
            var department = _departmentRepository.FindById(departmentId);
            _departmentRepository.Delete(department);
            _departmentRepository.Save();
        }

        public void AssignUserToDepartment(Guid userId, Guid departmentId)
        {
            var user = _userRepository.FindById(userId);
            user.DepartmentId = departmentId;
            _userRepository.Update(user);
            _userRepository.Save();
        }
    }
}