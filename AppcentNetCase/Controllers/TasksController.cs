using AppcentNetCase.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppcentNetCase.Controllers
{
    public class TasksController : Controller
    {

        private readonly IdbContext _context;

        public TasksController(IdbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Tasks.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
