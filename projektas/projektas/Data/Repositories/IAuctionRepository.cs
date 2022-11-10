using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projektas.Data.Entities;

namespace projektas.Data.Repositories
{
    public interface IAuctionsRepository
    {
        Task<Auction?> GetAsync(int auctionId);
        Task<IReadOnlyList<Auction>> GetManyAsync();
        Task CreateAsync(Auction auction);
        Task UpdateAsync(Auction auction);
        Task DeleteAsync(Auction auction);

    }
}
