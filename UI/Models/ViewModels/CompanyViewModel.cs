using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string OrganizationalForm { get; set; }
    }
}