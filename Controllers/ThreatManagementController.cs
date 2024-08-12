using IronDome.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IronDome.Controllers
{
    public class ThreatManagementController : Controller
    {
        private static readonly List<ThreatManagement> 
            threatManagements = [];

        public IActionResult Index()
        {
            return View(threatManagements);
        }

        public IActionResult Create()
        {
            return View(new ThreatManagement());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ThreatManagement threat)
        {
            threatManagements.Add(threat);
            return RedirectToAction("Index");
        }
    }
}
