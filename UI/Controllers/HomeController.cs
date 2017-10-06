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
        private ICompanyService companyService;
        public HomeController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        public HomeController()
        {

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
            CompanyService companyService = new CompanyService();
            //List<CompanyDTO> CompaniesDTO = new companyService.GetAllCompany();
            List<CompanyDTO> CompaniesDTO = companyService.GetAllCompany();
            List<CompanyViewModel> Companies = new List<CompanyViewModel>();
            foreach(var company in CompaniesDTO)
            {
                CompanyViewModel companyView = new CompanyViewModel();
                companyView.Id = company.Id;
                companyView.Name = company.Name;
                companyView.OrganizationalForm = company.OrganizationalForm;
                companyView.Size = company.Size;
                Companies.Add(companyView);
            }

            return View(Companies);
        }
    }
}