using InvestmentSimulator.Context;
using InvestmentSimulator.DTOs;
using InvestmentSimulator.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

namespace InvestmentSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly InvestmentSimulatorContext _context;

        public RegisterController(InvestmentSimulatorContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            // Verifica se o usuário já existe
            if (_context.Users.Any(u => u.Email == registerDto.Email))
            {
                return Conflict(new { message = "Username already exists." });
            }

            // Cria um novo usuário
            var user = new User
            {
                Email = registerDto.Email,
                Username = registerDto.Username,
                PasswordHash = HashPassword(registerDto.Password)
            };

            // Adiciona o usuário ao contexto
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}