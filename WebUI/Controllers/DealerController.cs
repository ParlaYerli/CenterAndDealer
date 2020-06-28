using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
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
    }
}