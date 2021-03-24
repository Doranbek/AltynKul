using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Camp()
        {
            return View();
        }
    }
}
