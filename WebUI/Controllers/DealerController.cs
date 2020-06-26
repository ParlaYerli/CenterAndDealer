using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

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

    }
}