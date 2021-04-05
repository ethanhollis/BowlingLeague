using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Components
{
    //View component for filtering data by teams -- inherits from viewcomp
    public class TeamFilterViewComponent : ViewComponent
    {
        //constructor to create context
        private BowlingLeagueContext context;
        public TeamFilterViewComponent(BowlingLeagueContext ctx)
        {

            context = ctx;
        }

        //what will happen when called
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData?.Values["teamname"];


            //Returns the view selecting all different team names
            return View(context.Teams.Distinct().OrderBy(x=>x));
        }
    }
}
