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
    public class ShiftOfTeamController : Controller
    {
        private readonly IShiftOfTeamService _shiftOfTeamService;
        private readonly IShiftService _shiftService;
        private readonly ITeamService _teamService;

        public ShiftOfTeamController(IShiftOfTeamService shiftOfTeamService, IShiftService shiftService, ITeamService teamService)
        {
            _shiftOfTeamService = shiftOfTeamService;
            _shiftService = shiftService;
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var s = _shiftOfTeamService.GetAll().ToList();
            return View(s);
        }
        [HttpGet]
        public IActionResult Create(string? message)
        {
            ViewBag.getShiftName = _shiftService.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.getTeamName = _teamService.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.TeamErrorMessage = message;
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ShiftOfTeam shiftOfTeam)
        {
            var shift = _shiftOfTeamService.GetAll().Where(x => x.TeamId == shiftOfTeam.TeamId).FirstOrDefault();
            if (shift == null)
            {
                await _shiftOfTeamService.Create(shiftOfTeam);
                return RedirectToAction("Index", "ShiftOfTeam");
            }
            else
            {
                return RedirectToAction("Create", "ShiftOfTeam", "Bir takım birden fazla shifte atanamaz!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _shiftOfTeamService.Delete(id);
            return RedirectToAction("Index", "ShiftOfTeam");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var getShiftOfTeam = await _shiftOfTeamService.GetById(id);
            ViewBag.getShiftName = _shiftService.GetAll().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.getTeamName = _teamService.GetAll().ToList().Where(x => x.Id == getShiftOfTeam.TeamId).Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ShiftOfTeam shiftOfTeam, int id)
        {
            await _shiftOfTeamService.Update(id, shiftOfTeam);
            return RedirectToAction("Index", "ShiftOfTeam");
        }
    }
}
