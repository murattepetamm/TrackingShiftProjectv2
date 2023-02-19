using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class TeamController : Controller
    {
        ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            return View(_teamService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            await _teamService.Create(team);
            return RedirectToAction("Index", "Team");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _teamService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Team title, int id)
        {
            await _teamService.Update(id, title);
            return RedirectToAction("Index", "Team");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _teamService.Delete(id);
            return RedirectToAction("Index", "Team");
        }
    }
}
