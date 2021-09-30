using EmplooyeesAPI.Dtos;
using EmplooyeesAPI.Entities;
using EmplooyeesAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmplooyeesAPI.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee does not exist");
            }
            return employee;
        }

        public async Task CreateAsync(EmployeeCreationDto employee)
        {
            var entity = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                CompanyId = employee.CompanyId,
                Gender = employee.Gender
            };
            await _employeeRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Id = employee.Id;
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.CompanyId = employee.CompanyId;
            }
            await _employeeRepository.UpdateAsync(existingEmployee);
        }
    }
}
