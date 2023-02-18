using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeDal _employeeDal;
        readonly ITitleDal _titleDal;
        public EmployeeController(IEmployeeDal employeeDal, ITitleDal titleDal)
        {
            _employeeDal = employeeDal;
            _titleDal = titleDal;
        }
        public IActionResult Index()
        {

            var getAllList = _employeeDal.GetAll().ToList();
            foreach (var item in getAllList)
            {
                item.TitleName = _titleDal.GetAll().Where(x => x.Id == item.TitleId).FirstOrDefault().Name ?? "";
            }
            return View(getAllList);
        }

        public IActionResult GetEmployeeById(int id)
        {
            var getListById = _employeeDal.GetById(id);
            return View(getListById);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {

            ViewBag.getTitle = _titleDal.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                await _employeeDal.Create(employee);
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
            ViewBag.getTitle = _titleDal.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(await _employeeDal.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee, int id)
        {
            await _employeeDal.Update(id, employee);
            return RedirectToAction("Index", "Employee");
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeDal.Delete(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
