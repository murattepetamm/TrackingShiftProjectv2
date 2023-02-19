using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        public IActionResult Index()
        {
            return View(_shiftService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Shift shift)
        {
            await _shiftService.Create(shift);
            return RedirectToAction("Index", "Shift");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _shiftService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Shift title, int id)
        {
            await _shiftService.Update(id, title);
            return RedirectToAction("Index", "Shift");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _shiftService.Delete(id);
            return RedirectToAction("Index", "Shift");
        }
    }
}
