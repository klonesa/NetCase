using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppcentNetCase.Models.Entities;
using AppcentNetCase.Models.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AppcentNetCase.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IdbContext _context;

        public ProjectController(IdbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Projects.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddProject(string ProjectTitle,DateTime StartingDate,DateTime FinishDate,string Text)
        {
            var tvm = 0;
            try
            {
                var model = new Project();
                model.ProjectTitle = ProjectTitle;
                model.StartingDate = StartingDate;
                model.FinishDate = FinishDate;
                model.Text = Text;
                var c = _context.Projects.Add(model);
                tvm = 0;
            }
            catch (Exception exc)
            {
                tvm = 0;
            }


            return Json(tvm);
        }
    }
}
