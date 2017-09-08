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
            var computer = new List<ComputerModels>
            {
                new ComputerModels{IPAddress="111.111.111.111", UPTime=DateTime.Now, ComputerName="My PC",
                OSName="Microsoft Windows", OSVersion="8.1", TotalMemory=500}
            };

            
            ViewBag.Computers = computer;

            return View("Computer");
        }
    }
}