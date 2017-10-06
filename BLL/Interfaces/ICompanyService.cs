using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyDTO> GetAllCompany();
        CompanyDTO GetCompanyById(int Id);
        void UpdateCompany(CompanyDTO Company);
    }
}
