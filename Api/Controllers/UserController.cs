using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Services;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController( UserService UserService)
        {
           this.userService = UserService;
        }
        
    [HttpPost("authenticate")]

    public async Task<IActionResult> User(AddUserDto addUserDto)
    {
        var User = await loginService.GetUser(AddUserDto);

        if (User is null)
        return BadRequest(new{message = "Credenciales Invalidas"});

        return Ok(new { token = "some value"});
    }
    private string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email)
        }
    }
    }