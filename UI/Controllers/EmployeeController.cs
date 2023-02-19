using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeService _employeeService;
        readonly ITitleService _titleService;
        public EmployeeController(IEmployeeService employeeService, ITitleService titleService)
        {
            _employeeService = employeeService;
            _titleService = titleService;
        }
        public IActionResult Index()
        {
            var getAllList = _employeeService.GetAll();
            return View(getAllList);
        }

        public IActionResult GetEmployeeById(int id)
        {
            var getListById = _employeeService.GetById(id);
            return View(getListById);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            ViewBag.getTitle = _titleService.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                await _employeeService.Create(employee);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            ViewBag.getTitle = _titleService.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(await _employeeService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee, int id)
        {
            await _employeeService.Update(id, employee);
            return RedirectToAction("Index", "Employee");
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.Delete(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
