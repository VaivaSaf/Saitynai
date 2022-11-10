using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using projektas.Data.Entities;

namespace projektas.Data.Repositories
{
    public class AuctionsRepository : IAuctionsRepository
    {
        private readonly ForumDbContext  _forumDbContext;
        public AuctionsRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }

        public async Task<Auction?> GetAsync(int auctionId)
        {
            return await _forumDbContext.Auctions.FirstOrDefaultAsync(o => o.Id == auctionId);
        }
        public async Task<IReadOnlyList<Auction>> GetManyAsync()
        {
            return await _forumDbContext.Auctions.ToListAsync();
        }
        //SUKURUMO
        public async Task CreateAsync(Auction auction)
        {
            _forumDbContext.Auctions.Add(auction);
            await _forumDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Auction auction)
        {
            _forumDbContext.Auctions.Update(auction);
            await _forumDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Auction auction)
        {
            _forumDbContext.Auctions.Remove(auction);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
