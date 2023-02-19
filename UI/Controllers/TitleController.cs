using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class TitleController : Controller
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        public IActionResult Index()
        {
            return View(_titleService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Title title)
        {
            await _titleService.Create(title);
            return RedirectToAction("Index", "Title");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _titleService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Title title, int id)
        {
            await _titleService.Update(id, title);
            return RedirectToAction("Index", "Title");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _titleService.Delete(id);
            return RedirectToAction("Index", "Title");
        }

    }
}
