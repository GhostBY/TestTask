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
    public class CompanyService : ICompanyService
    {
        private CompanyDAL companyDAL;
        private List<CompanyDTO> Companies;
        public CompanyService()
        {
            Companies = new List<CompanyDTO>();
            companyDAL = new CompanyDAL();
        }
        public List<CompanyDTO> GetAllCompany()
        {
            List<Company> CompaniesDAL = new List<Company>();
            CompaniesDAL = companyDAL.GetAll();
            foreach(var company in CompaniesDAL )
            {
                CompanyDTO companyDTO = new CompanyDTO();
                companyDTO.Id = company.Id;
                companyDTO.Name = company.Name;
                companyDTO.OrganizationalForm = company.OrganizationalForm;
                companyDTO.Size = company.Size;
                Companies.Add(companyDTO);
            }
            return Companies;
        }

        public CompanyDTO GetCompanyById(int Id)
        {
            Company company = new Company();
            company =companyDAL.Get(Id);
            CompanyDTO companyDTO = new CompanyDTO();
            companyDTO.Id = company.Id;
            companyDTO.Name = company.Name;
            companyDTO.OrganizationalForm = company.OrganizationalForm;
            companyDTO.Size = company.Size;
            return companyDTO;
        }
    }
}
