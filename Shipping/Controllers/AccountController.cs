using BL.Contracts;
using BL.Dtos;
using DAL.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ui.Models;
using Ui.Services;

namespace Ui.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        private readonly GenericApiClient _apiClient;
        public AccountController(IUserService userService, GenericApiClient apiClient)
        {
            _userService = userService;
            _apiClient = apiClient;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto userloginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userloginDto);
            }
            var result = await _userService.LoginAsync(userloginDto);
            if (result.Success)
            {
                // Call the login API using the generic client
                LoginApiModel apiResult = await _apiClient.PostAsync<LoginApiModel>("api/auth/login", userloginDto);

                if (apiResult == null)
                {
                    ModelState.AddModelError(string.Empty, "API error: Unable to process login.");
                    return View(userloginDto);
                }

                var accessToken = apiResult?.AccessToken.ToString();

                if (string.IsNullOrEmpty(accessToken))
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(userloginDto);
                }
                // Store the access token in the cookie (for subsequent requests)
                Response.Cookies.Append("AccessToken", accessToken, new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddMinutes(15)  // Adjust token expiry based on your needs
                });

                var dbUser = await _userService.GetUserByEmailAsync(userloginDto.Email);

                if (dbUser.Role.ToLower() == "admin")
                    return RedirectToRoute(new { area = "admin", controller = "Home", action = "Index" });
                else
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
                return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserDto user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }

            var result = await _userService.RegisterAsync(user);
            if (result.Success)
            {

                return RedirectToAction("Login");
            }
            else
                return View();
        }
        public IActionResult Logout()
        {
            return _userService.LogoutAsync().ContinueWith(t => RedirectToAction("Login")).Result;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}