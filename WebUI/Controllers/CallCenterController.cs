using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CallCenterController : Controller
    {
        private IAuthService _authService;

        public CallCenterController(IAuthService _authService)
        {
            this._authService = _authService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCallCenterUser(CallCenterUserViewModel model)
        {
            if (model.FullName == null || model.Password == null)
            {
                return View();
            }

            User user = new User()
            {
                IsActive = true,
                FullName = model.FullName,
                Password = _authService.PasswordHasher(model.Password),
                CreatedDate = DateTime.Now,
                RoleId = 1,
                CreatedBy = 2
            };

            _authService.CreateCallCenter(user);

            return RedirectToAction("ListCallCenterUser", "CallCenter");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "CallCenter");
        }
        public IActionResult ListCallCenterUser()
        {
            var list = _authService.GetAllCallCenterUser();

            List<CallCenterUserViewModel> modelList = new List<CallCenterUserViewModel>();
            foreach (var item in list)
            {
                CallCenterUserViewModel model = new CallCenterUserViewModel()
                {
                    Id = item.Id,
                    CreatedDate = item.CreatedDate,
                    FullName = item.FullName,
                    IsActive = item.IsActive
                };
                modelList.Add(model);
            }

            return View(modelList);
        }
        public IActionResult Search()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ListCallCenterUser");
            }
            if (await LoginUserAsync(model))
            {
                return RedirectToAction("Search");
            }
            if (model.Password != null)
            {
                ViewBag.LoginResult = "Lütfen Kullanıcı ID'nizi ve şifrenizi kontrol ediniz.";
            }

            return View();
        }

        private async Task<bool> LoginUserAsync(LoginViewModel model)
        {
            var user = _authService.LoginCallCenter(model.DealerId, model.Password);
            if (user != null)
            {
                var claims = new List<Claim>();
                if (user.RoleId == 1)
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "CallCenter"));
                    claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
                }
                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return true;
            }
            return false;


        }
    }

}