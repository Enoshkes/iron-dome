using IronDome.Dto;

namespace IronDome.Service
{
    public interface IThreatManagementService
    {
        Task Launch(CancellationToken token, int seconds, ThreatManagement threat);
    }
}
