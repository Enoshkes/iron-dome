using IronDome.Models;
using IronDome.Service;
using IronDome.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace IronDome.Controllers
{
    public class AdminController(IAdminService adminService): Controller
    {
        public async Task<IActionResult> Index()
        {
            AdminModel? adminModel = await adminService.GetAdmin();

            if (adminModel == null)
            {
                return RedirectToAction("Index", "Home");
            }

            AdminVM adminVM = new() { MissileAmount = adminModel.MissileAmount };

            return View(adminVM);
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdminVM adminVM)
        {
            await adminService.UpdateMissileAmount(adminVM.MissileAmount);
            return RedirectToAction("Index");
        }
    }
}
