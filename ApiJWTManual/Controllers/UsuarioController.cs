using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiJWTManual.Dtos;
using ApiJWTManual.Services;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiJWTManual.Controllers
{
    public class UsuarioController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        // Constructor que inicializa los servicios necesarios
        public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _userService = userService;
            this.mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // Método para registrar un nuevo usuario
        [HttpPost("agregar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> Post(RegisterDTO usuarioDTO)
        {
            // Mapear el DTO a la entidad de Usuario
            var usuario = mapper.Map<Usuario>(usuarioDTO);

            // Llamar al servicio para registrar el usuario
            var result = await _userService.ResgisterAsync(usuario);

            // Verificar si el DTO es nulo y devolver el resultado
            if (usuarioDTO == null)
                return BadRequest();

            return result;
        }

        // Método para obtener un token de inicio de sesión
        [HttpPost("getTokenLogin/{email}")]
        public ActionResult getTokenLogin([FromForm] string email, [FromForm] string password)
        {
            // Llamar al servicio para obtener un token de inicio de sesión
            return Ok(_userService.getTokenLogin(email, password));
        }

        // Método para realizar el inicio de sesión con un token
        [HttpPost("loginByToken")]
        public async Task<ActionResult> LoginByToken([FromForm] string loginToken)
        {
            // Obtener el token y manejar diferentes casos
            string token = await _userService.LoginByToken(loginToken);

            switch (token)
            {
                case "-1": return BadRequest("Expiró tiempo");
                case "-2": return BadRequest("Datos incorrectos");
                case "-3": return BadRequest("No se pudo hacer el login");
                default: return Ok(token);
            }
        }

        // Método para obtener el email asociado a un token
        [HttpPost("token")]
        public ActionResult email([FromForm] string token)
        {
            // Obtener el email del usuario a partir del token
            string email = _userService.GetEmailUsuarioFromToken(token);
            return Ok(email);
        }

        // Método para cambiar la contraseña
        [HttpPost("CambiarContraseña")]
        public ActionResult SetPassword([FromForm] string token, [FromForm] string newPassword, [FromForm] string oldPassword)
        {
            // Intentar cambiar la contraseña y devolver el resultado
            bool resultado = _userService.SetPassword(token, newPassword, oldPassword);
            if (resultado)
                return Ok("Se cambio la contraseña");
            else
                return BadRequest("Ocurrio un error al cambiar la contraseña");
        }

        // Método para cerrar sesión
        [HttpPost("Salir")]
        public ActionResult logout([FromForm] string token)
        {
            // Llamar al servicio para cerrar sesión y devolver el resultado
            var result = _userService.Logout(token);
            if (result)
                return Ok("Sesion Finalizada");
            else
                return BadRequest("Ocurrio un error");
        }
    }
}
