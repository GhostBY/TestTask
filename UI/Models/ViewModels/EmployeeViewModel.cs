using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
    }
}