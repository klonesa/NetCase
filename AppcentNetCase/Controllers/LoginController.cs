using AppcentNetCase.Application.UserOperations;
using AppcentNetCase.Models.Entities;
using AppcentNetCase.Models.Repository;
using AppcentNetCase.TokenOperation.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static AppcentNetCase.Application.UserOperations.CreateTokenCommand;

namespace AppcentNetCase.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        private readonly IdbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginController(IdbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {

            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);

            CreateTokenModel login = new CreateTokenModel();
            login.Email = email;
            login.Password = password;
            command.Model = login;
            var token = command.Handle();

            if (token is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,email)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
           
            }
            else
            {

            }
            return View();
        }

    }
}
