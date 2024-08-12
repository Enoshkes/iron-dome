using IronDome.Dto;
using IronDome.Service;
using Microsoft.AspNetCore.Mvc;

namespace IronDome.Controllers
{
    public class ThreatManagementController(IThreatManagementService threatManagementService, LaunchDto launchDto) : Controller
    {

        public IActionResult Index()
        {
            return View(launchDto.ActiveThreats);
        }

        public IActionResult Create()
        {
            return View(new ThreatManagement());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ThreatManagement threat)
        {
            // generate id
            int id = launchDto.ActiveThreats.Any() 
                ? (launchDto.ActiveThreats.Max(x => x.Id) +  1) 
                : 1;

            // set the id
            threat.Id  = id;

            // save in memory
            launchDto.ActiveThreats.Add(threat);
            return RedirectToAction("Index");
        }

        public async Task Abort(int id)
        {
            CancellationTokenSource cts = launchDto.Launches[id];
            await cts.CancelAsync();
        }

        public async Task<IActionResult> Launch(int id)
        {
            CancellationTokenSource cts = new();

            ThreatManagement? threat = 
                Launch().sa .FirstOrDefault(x => x.Id == id);

            if (threat == null) { return RedirectToAction("Index");  }

            threat.IsActive = true;

            Task launch = threatManagementService.Launch(cts.Token, 60, threat);
            return RedirectToAction("Index");
        }
    }
}
