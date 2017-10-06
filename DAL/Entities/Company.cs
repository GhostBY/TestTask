using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Company
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string OrganizationalForm { get; set; }
    }
}
