﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using joolochu.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace joolochu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ApplicationDbContext _context;
        public LoginController(IConfiguration configuration, ApplicationDbContext context)
        {
            _config = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(string phoneNumber, string pass)
        {
            User login = new User();
            login.PhoneNumber = phoneNumber;
            login.Password = pass;
            IActionResult result = Unauthorized();

            var user = await _context.Users.FirstOrDefaultAsync(e => e.PhoneNumber == login.PhoneNumber && e.Password == login.Password) ?? null;
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
