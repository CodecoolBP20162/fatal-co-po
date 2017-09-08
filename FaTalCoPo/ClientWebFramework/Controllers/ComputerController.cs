using ClientWebFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientWebFramework.ViewModels;

namespace ClientWebFramework.Controllers
{
    public class ComputerController : Controller
    {
        // GET: Computer
        public ActionResult Index()
        {
            var computer = new Dictionary<string, ComputerModels>();
            computer.Add("1", new ComputerModels
            {
                uptime = DateTime.Now,
                computerName = "My PC",
                osInfo = "Microsoft Windows"
            });

            computer.Add("2", new ComputerModels
            {
                uptime = DateTime.Now,
                computerName = "My PC SECOND",
                osInfo = "Microsoft Windows 2"
            });

            ViewBag.Computers = computer;

            return View("Computer");
        }
    }
}