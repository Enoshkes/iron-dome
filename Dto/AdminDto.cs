using IronDome.Models;

namespace IronDome.Dto
{
    public class AdminDto
    {
        public Queue<ThreatModel> ActiveThreats { get; set; } = [];

    }
}
