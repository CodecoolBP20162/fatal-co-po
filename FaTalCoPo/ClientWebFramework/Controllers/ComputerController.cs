using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WcfClient;
using WcfLib;
using System.Diagnostics;

namespace ClientWebFramework.Controllers
{
    public class ComputerController : Controller
    {
        // GET: Computer
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult LoadComputers()
        {
            try
            {
                ClientConnection client = ClientConnection.GetInstance();
                List<Dictionary<string, string>> computers = new List<Dictionary<string, string>>();
                List<List<string>> processes = new List<List<string>>();
                for (int i = 0; i < client.channels.Count; i++)
                {
                    IWcfPing channel = client.channels[i];
                    string content = client.SaveComputerInfo(i);
                    Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                    computers.Add(dict);
                    string processContent = client.SaveProccesses(i);
                    List<string> names = JsonConvert.DeserializeObject<List<string>>(processContent);
                    processes.Add(names);
                    client.SaveScreenShot(i);
                }
                ViewBag.Computers = computers;
                ViewBag.Processes = processes;
            }
            catch { }
            return PartialView("Loadcomputers");
        }
    }
}