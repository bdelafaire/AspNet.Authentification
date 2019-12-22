using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Authentification.Cookie.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        public IActionResult Subscription()
        {
            return View(); 
        }
    }
}
