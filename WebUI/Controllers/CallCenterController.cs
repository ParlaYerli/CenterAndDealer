using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
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

    }
    
}