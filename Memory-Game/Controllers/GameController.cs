using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Memory_Game.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult GameRound()
        {
            return View();
        }
    }
}