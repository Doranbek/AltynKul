using Company.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext db;

        public BaseController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
    }
}
