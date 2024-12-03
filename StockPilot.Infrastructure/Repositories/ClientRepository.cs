using Microsoft.EntityFrameworkCore;
using StockPilot.Domain.Entities;
using StockPilot.Domain.IRepositories;
using StockPilot.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPilot.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client> , IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<User?> GetUserByName(string userName)
        {
            try
            {
                var res = await _context.Users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefaultAsync(u => u.UserName == userName);

                return res;
            }catch(Exception ex)
            {
                return null;
            }

        }
    }
}
