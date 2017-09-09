using ClientWebFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientWebFramework.ViewModels;
using Newtonsoft.Json;
using Client;
using GettingStartedLib;

namespace ClientWebFramework.Controllers
{
    public class ComputerController : Controller
    {
        // GET: Computer
        public ActionResult Index()
        {
            return View("Computer");
        }

        //public PartialViewResult LoadComputers()
        //{
        //    ClientConnection client = ClientConnection.GetInstance();
        //    client.SetupChannels();
        //    List<Dictionary<string, string>> computers = new List<Dictionary<string, string>>();
        //    for (int i = 0; i < client.channels.Count; i++)
        //    {
        //        IWcfPingTest channel = client.channels[i];
        //        string content = client.SaveComputerInfo(i);
        //        Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
        //        computers.Add(dict);
        //    }

        //    ViewBag.Computers = computers;
        //    return PartialView("LoadComputers");
        //}
    }
}