﻿using BookStore.BLL.ViewModels.Authentication;
using BookStore.DAL.Infrastructure;
using BookStore.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public interface IAuthenticationService
    {
        Task<IActionResult> RegisterUserAsync(RegisterVm register);
        Task<IActionResult> LoginUserAsync(LoginVm loginVm);
        Task<AuthResultVm> GenerateJwtToken(User user);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<IActionResult> RegisterUserAsync(RegisterVm register)
        {
            try
            {
                var userExists = await _userManager.FindByEmailAsync(register.Email);

                if (userExists != null)
                {
                    return new BadRequestObjectResult($"User {register.Email} đã tồn tại!");
                }

                var newUser = new User()
                {
                    Email = register.Email,
                    UserName = register.Email,
                };

                var result = await _userManager.CreateAsync(newUser, register.Password);

                if (result.Succeeded)
                {
                    return new OkObjectResult(register);
                }

                return new BadRequestObjectResult("User không thể tạo ra!");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<IActionResult> LoginUserAsync(LoginVm loginVm)
        {
            var user = await _userManager.FindByEmailAsync(loginVm.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginVm.Password))
            {
                var token = await GenerateJwtToken(user);
                return new OkObjectResult(token);
            }

            return new UnauthorizedResult();
        }

        public async Task<AuthResultVm> GenerateJwtToken(User user)
        {
            var authClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddMinutes(5),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResultVm()
            {
                Token = jwtToken,
                ExpiresAt = token.ValidTo
            };
        }
    }
}
