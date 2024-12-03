using StockPilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPilot.Domain.IRepositories
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        public Task<User?> GetUserByName(string userName);
    }
}
