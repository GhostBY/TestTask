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
        EmployeeService employeeService;
        List<EmployeeViewModel> EmployeesResult = new List<EmployeeViewModel>();
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
            if(employeeService==null)
            {
                employeeService = new EmployeeService();
                List<EmployeeDTO> EmployeesDTO = new List<EmployeeDTO>();
                EmployeesDTO = employeeService.GetAllEmployee();
                foreach (var employee in EmployeesDTO)
                {
                    EmployeeViewModel employeeView = new EmployeeViewModel();
                    employeeView.Id = employee.Id;
                    employeeView.Name= employee.Name;
                    employeeView.Surname = employee.Surname;
                    employeeView.Middlename = employee.Middlename;
                    employeeView.Position = employee.Position;
                    employeeView.EmploymentDate= employee.EmploymentDate;
                    employeeView.Company = employee.Company;
                    EmployeesResult.Add(employeeView);
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
        #region CompanyLogic
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
        [HttpPost]
        public ActionResult CompanyEdit(CompanyViewModel item)
        {
            if (ModelState.IsValid)
            {
                CompanyDTO companyDTO = new CompanyDTO();
                companyDTO.Id = item.Id;
                companyDTO.Name = item.Name;
                companyDTO.Size = item.Size;
                companyDTO.OrganizationalForm = item.OrganizationalForm;
                companyService.UpdateCompany(companyDTO);
                TempData["message"] = string.Format("Изменения  успешно сохранены");
                return RedirectToAction("Companies");
            }
            else
            {
                return View(item);
            }
        }

        public ActionResult CompanyCreate()
        {
            return View(new CompanyViewModel());
        }
        [HttpPost]
        public ActionResult CompanyCreate(CompanyViewModel item)
        {
            if (ModelState.IsValid)
            {
                CompanyDTO companyDTO = new CompanyDTO();
                companyDTO.Id = item.Id;
                companyDTO.Name = item.Name;
                companyDTO.Size = item.Size;
                companyDTO.OrganizationalForm = item.OrganizationalForm;
                companyService.CreateCompany(companyDTO);
                TempData["message"] = string.Format("Компания  успешно добавлена");
                return RedirectToAction("Companies");
            }
            else
            {
                return View(item);
            }
        }

        public ActionResult DeleteCompany(int Id)
        {
            try
            {
                companyService.DeleteCompany(Id);
                TempData["message"] = string.Format("Компания была успешно удалена");
                return RedirectToAction("Companies");
            }
            catch
            {
                TempData["message"] = string.Format("Возникла ошибка при удалении компании");
                return RedirectToAction("Companies");
            }
            
            
        }
        #endregion

        #region EmployeeLogic
        public ActionResult Employees()
        {
            //CompanyService companyService = new CompanyService();
            //List<CompanyDTO> CompaniesDTO = new companyService.GetAllCompany();


            return View(EmployeesResult);
        }
        public ActionResult DeleteEmployee(int Id)
        {
            try
            {
                employeeService.DeleteEmployee(Id);
                TempData["message"] = string.Format("Сотрудник был успешно удален");
                return RedirectToAction("Employees");
            }
            catch
            {
                TempData["message"] = string.Format("Возникла ошибка при удалении сотрудника");
                return RedirectToAction("Employees");
            }
        }

        public ActionResult EmployeeCreate()
        {
         ViewBag.Companies = CompaniesResult;
            return View(new EmployeeViewModel());
        }
        [HttpPost]
        public ActionResult EmployeeCreate(EmployeeViewModel item)
        {
            if (ModelState.IsValid)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO.Id = item.Id;
                employeeDTO.Name = item.Name;
                employeeDTO.Surname = item.Surname;
                employeeDTO.Middlename = item.Middlename;
                employeeDTO.EmploymentDate = item.EmploymentDate;
                employeeDTO.Position = item.Position;
                employeeDTO.Company = item.Company;

                employeeService.CreateEmployee(employeeDTO);

                TempData["message"] = string.Format("Сотрудник успешно добавлен");
                return RedirectToAction("Employees");
            }
            else
            {
                return View(item);
            }
            
        }

        public ActionResult EmployeeEdit(int Id)
        {
            EmployeeViewModel employee = new EmployeeViewModel();

            EmployeeDTO employeeDTO = employeeService.GetEmployeeById(Id);
            if (employeeDTO != null)
            {
                employee.Id = employeeDTO.Id;
                employee.Name = employeeDTO.Name;
                employee.Surname = employeeDTO.Surname;
                employee.Middlename = employeeDTO.Middlename;
                employee.Position = employeeDTO.Position;
                employee.Company = employeeDTO.Company;
                employee.EmploymentDate = employeeDTO.EmploymentDate;
            }

            int CompanyId = new int();
            foreach (var company in CompaniesResult)
            {
                if (employee.Company == company.Name)
                {
                    CompanyId = company.Id;
                }

               
            }
            ViewBag.Companies = CompaniesResult;
            ViewBag.CompanyId = CompanyId;
            return View(employee);
        }
        [HttpPost]
        public ActionResult EmployeeEdit(EmployeeViewModel item)
        {
            if (ModelState.IsValid)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO.Id = item.Id;
                employeeDTO.Name = item.Name;
                employeeDTO.Surname = item.Surname;
                employeeDTO.Middlename = item.Middlename;
                employeeDTO.EmploymentDate = item.EmploymentDate;
                employeeDTO.Position = item.Position;
                employeeDTO.Company = item.Company;

                employeeService.UpdateEmployee(employeeDTO);

                TempData["message"] = string.Format("Сотрудник успешно обнавлен");
                return RedirectToAction("Employees");
            }
            else
            {
                return View(item);
            }
        }
        #endregion
    }
}