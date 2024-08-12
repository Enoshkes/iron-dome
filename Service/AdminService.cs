
using IronDome.Data;
using IronDome.Models;
using Microsoft.EntityFrameworkCore;

namespace IronDome.Service
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<AdminModel?> GetAdmin() => 
            await _context.Admin.FirstOrDefaultAsync();

        public async Task UpdateMissileAmount(int amount)
        {
            var adminModel = await _context.Admin.FirstOrDefaultAsync()
                ?? throw new Exception("Admin is null");

            adminModel.MissileAmount = amount;
            await _context.SaveChangesAsync();
        }
    }
}
