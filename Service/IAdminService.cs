using IronDome.Models;

namespace IronDome.Service
{
    public interface IAdminService
    {

        Task<AdminModel?> GetAdmin();

        Task UpdateMissileAmount(int amount);
    }
}
