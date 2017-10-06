using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployee();
        EmployeeDTO GetEmployeeById(int Id);
        void UpdateEmployee(EmployeeDTO Employee);
        void CreateEmployee(EmployeeDTO Employee);

        void DeleteEmployee(int Id);
    }
}
