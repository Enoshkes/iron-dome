using IronDome.Models;

namespace IronDome.Dto
{
    public class LaunchDto
    {
        public List<ThreatManagement> ActiveThreats { get; set; } = [];

        public Dictionary<int, CancellationTokenSource> Launches = new ();

    }
}
