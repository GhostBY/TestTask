using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using UI.Models.ViewModels;
using BLL.Services;
namespace UI.Controllers
{
    public class HomeController : Controller
    {
        CompanyService companyService ;
        List<CompanyViewModel> CompaniesResult = new List<CompanyViewModel>();
        public HomeController(CompanyService companyService)
        {
           
            this.companyService = companyService;
        }
        public HomeController()
        {
            if (companyService == null)
            {
                companyService = new CompanyService();
                List<CompanyDTO> CompaniesDTO = new List<CompanyDTO>();
                CompaniesDTO = companyService.GetAllCompany();
                foreach (var company in CompaniesDTO)
                {
                    CompanyViewModel companyView = new CompanyViewModel();
                    companyView.Id = company.Id;
                    companyView.Name = company.Name;
                    companyView.OrganizationalForm = company.OrganizationalForm;
                    companyView.Size = company.Size;
                    CompaniesResult.Add(companyView);
                }
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Companies()
        {
            //CompanyService companyService = new CompanyService();
            //List<CompanyDTO> CompaniesDTO = new companyService.GetAllCompany();
            

            return View(CompaniesResult);
        }
        public ActionResult CompanyEdit(int Id)
        {
            CompanyViewModel company = new CompanyViewModel();
          
                CompanyDTO companyDTO = companyService.GetCompanyById(Id);
                if(companyDTO!=null)
                {
                    company.Id = companyDTO.Id;
                    company.Name = companyDTO.Name;
                    company.Size= companyDTO.Size;
                    company.OrganizationalForm = companyDTO.OrganizationalForm;
                }
            
            return View(company);
        }
    }
}