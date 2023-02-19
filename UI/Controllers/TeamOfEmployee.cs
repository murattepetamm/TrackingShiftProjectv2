using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class TeamOfEmployee : Controller
    {
        ITeamOfEmployeeService _teamOfEmployeeService;
        ITitleService _titleService;
        IEmployeeService _employeeService;
        ITeamService _teamService;

        public TeamOfEmployee(ITeamOfEmployeeService teamOfEmployeeService, ITitleService titleService, IEmployeeService employeeService, ITeamService teamService)
        {
            _teamOfEmployeeService = teamOfEmployeeService;
            _titleService = titleService;
            _employeeService = employeeService;
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            return View(_teamOfEmployeeService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.getTeamName = _teamService.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.employee = _employeeService.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name + " - " + GetTitle(x.TitleId), Value = x.Id.ToString() });
            _titleService.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamsOfEmployee teamsOfEmployee)
        {
            var getShiftOfTeam = await _employeeService.GetById(teamsOfEmployee.EmployeeId);
            int getTeam = _teamService.GetById(teamsOfEmployee.TeamId).Result.Id;
            var teamOfEmployee = _teamOfEmployeeService.GetAll().Any(x => x.EmployeeId == getShiftOfTeam.Id && x.TeamId == getTeam);
            var teamOfEmployeeLst = _teamOfEmployeeService.GetAll().FirstOrDefault(x => x.EmployeeId == getShiftOfTeam.Id);

            var getAllTeams = _teamOfEmployeeService.GetAll();
            var getAllEmployee = _employeeService.GetAll();

            var isAdmin = from i in getAllTeams
                          join b in getAllEmployee on i.EmployeeId equals b.Id
                          where b.Id == teamsOfEmployee.EmployeeId && b.TitleId == 1
                          select b;

            if (!teamOfEmployee && isAdmin.Count() < 1)
            {
                if (!_teamOfEmployeeService.GetAll().Any(x => x.EmployeeId == getShiftOfTeam.Id))
                {
                    await _teamOfEmployeeService.Create(teamsOfEmployee);
                }
                else
                {
                    await _teamOfEmployeeService.Delete(teamOfEmployeeLst.Id);

                    await _teamOfEmployeeService.Create(teamsOfEmployee);
                }
            }


            return RedirectToAction("Index", "TeamOfEmployee");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamOfEmployeeService.Delete(id);
            return RedirectToAction("Index", "TeamOfEmployee");
        }
        public string GetTitle(int id)
        {
            return _titleService.GetById(id).Result.Name;
        }
    }
}
