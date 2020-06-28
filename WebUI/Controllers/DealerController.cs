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
    public class DealerController : Controller
    {
        private IAuthService _authService;

        public DealerController(IAuthService _authService)
        {
            this._authService = _authService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListDealerUser()
        {
            var list = _authService.GetAllDealerUser();
            List<DealerUserViewModel> modelList = new List<DealerUserViewModel>();
            foreach (var item in list)
            {
                DealerUserViewModel model = new DealerUserViewModel()
                {
                    Id = item.Id,
                    CreatedDate = item.CreatedDate,
                    FullName = item.FullName,
                    IsActive = item.IsActive,
                    DealerId = item.DealerId
                };
                modelList.Add(model);
            }
            return View(modelList);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ListDealerUser");
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
        public IActionResult Search()
        {
            return View();
        }

        private async Task<bool> LoginUserAsync(LoginViewModel model)
        {
            var user = _authService.LoginDealer(model.DealerId, model.Password);
            if (user != null)
            {
                var claims = new List<Claim>();
                if (user.RoleId == 2)
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "Dealer"));
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