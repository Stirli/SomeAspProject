using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SomeAspProject.Services.Database;

namespace SomeAspProject.Controllers
{
    public class SqlController : Controller
    {
        private readonly IDatabaseService _database;

        public SqlController(IDatabaseService database)
        {
            _database = database;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendRequest(string req)
        {
            var result = await _database.SendRequestAsync(req);
            ViewBag.SqlRequest = req;
            return View(nameof(Index), result);
        }
    }
}
