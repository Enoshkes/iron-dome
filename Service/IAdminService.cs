namespace IronDome.Service
{
    public interface IAdminService
    {

        Task<int> GetMissleAmount();

        Task UpdateMissileAmount(int amount);
    }
}
