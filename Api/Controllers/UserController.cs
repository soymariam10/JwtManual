using Microsoft.AspNetCore.Mvc;

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