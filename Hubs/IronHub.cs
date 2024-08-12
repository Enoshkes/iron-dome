using IronDome.Data;
using IronDome.Models;
using Microsoft.AspNetCore.SignalR;

namespace IronDome.Hubs
{
    public class IronHub(ApplicationDbContext context) : Hub
    {


        public async Task AddThreat(ThreatModel threat)
        {
           await Clients.All.SendAsync("AddedThreat");
        }
        public async Task<string> Attack()  
        {
            await Clients.All.SendAsync("ReceiveThreat");
            return "Completed";
        }

        public async Task Defend()
        {
            await Clients.All.SendAsync("ReceiveDefense");
        }
    }
}
