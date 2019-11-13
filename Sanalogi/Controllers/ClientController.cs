using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sanalogi.Models;

namespace Sanalogi.Controllers
{

    public class ClientController : Controller
    {
        public IActionResult AddInvoice()
        {
            return View();
        }

    }
}
