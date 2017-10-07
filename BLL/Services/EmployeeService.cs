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
            Employee employee = new Employee();
            employee.Id = Employee.Id;
            employee.Name = Employee.Name;
            employee.Surname = Employee.Surname;
            employee.Middlename = Employee.Middlename;
            employee.EmploymentDate = Employee.EmploymentDate;
            employee.Position = Employee.Position;
            employee.Company = Employee.Company;
            employeeDAL.Create(employee);
        }

        public void DeleteEmployee(int Id)
        {
            employeeDAL.Delete(Id);
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
            Employee employee = new Employee();
            employee = employeeDAL.Get(Id);
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.Id = employee.Id;
            employeeDTO.Name = employee.Name;
            employeeDTO.Surname = employee.Surname;
            employeeDTO.Middlename = employee.Middlename;
            employeeDTO.EmploymentDate = employee.EmploymentDate;
            employeeDTO.Position= employee.Position;
            employeeDTO.Company = employee.Company;
            return employeeDTO;
        }

        public void UpdateEmployee(EmployeeDTO Employee)
        {
            Employee employee = new Employee();
            employee.Id = Employee.Id;
            employee.Name = Employee.Name;
            employee.Surname = Employee.Surname;
            employee.Middlename = Employee.Middlename;
            employee.EmploymentDate = Employee.EmploymentDate;
            employee.Position = Employee.Position;
            employee.Company = Employee.Company;
            employeeDAL.Update(employee);
        }
    }
}
