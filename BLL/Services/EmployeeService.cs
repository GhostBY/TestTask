using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Services;
using DAL.Entities;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeDAL employeeDAL;
        private List<EmployeeDTO> Employees;
        public EmployeeService()
        {
            Employees = new List<EmployeeDTO>();
            employeeDAL = new EmployeeDAL();
        }

        public void CreateEmployee(EmployeeDTO Employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeDTO> GetAllEmployee()
        {
            List<Employee> EmployeesDAL = new List<Employee>();
            EmployeesDAL = employeeDAL.GetAll();
            foreach (var employee in EmployeesDAL)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO.Id = employee.Id;
                employeeDTO.Name = employee.Name;
                employeeDTO.Surname = employee.Surname;
                employeeDTO.Middlename = employee.Middlename;
                employeeDTO.Position = employee.Position;
                employeeDTO.EmploymentDate = employee.EmploymentDate;
                employeeDTO.Company = employee.Company;

                Employees.Add(employeeDTO);
            }
            return Employees;
        }

        public EmployeeDTO GetEmployeeById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeDTO Employee)
        {
            throw new NotImplementedException();
        }
    }
}
