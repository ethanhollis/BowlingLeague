using BowlingLeague.Models;
using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(long? team, string teamname, int pageNum = 0)
        {
            int bowlersPerPage = 5;

            return View(new IndexVM
            {
                Bowlers = (
                    context.Bowlers
                    .Where(b => b.TeamId == team || team == null)
                    .OrderBy(b => b.BowlerLastName)
                    .Skip((pageNum - 1) * bowlersPerPage)
                    .Take(bowlersPerPage)
                    .ToList()),

                PageNum = new PageNumberingVM
                {
                    ItemsPerPage = bowlersPerPage,
                    CurrentPage = pageNum,
                    TotalItems = (team == null ? context.Bowlers.Count() : context.Bowlers.Where(b => b.TeamId == team).Count())
                },

                Team = teamname

            }) ;
                
                    
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
