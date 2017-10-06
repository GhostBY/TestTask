using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Employee
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
    }
}
