using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using projektas.Data.Entities;

namespace projektas.Data.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly ForumDbContext _forumDbContext;
        public ItemsRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }

        public async Task<Item?> GetAsync(int auctionId, int itemId)
        {
            return await _forumDbContext.Items.FirstOrDefaultAsync(o => o.Auction.Id == auctionId && o.Id == itemId);
        }
        public async Task<IReadOnlyList<Item>> GetManyAsync(int auctionId)
        {
            return await _forumDbContext.Items.Where(o => o.Auction.Id == auctionId).ToListAsync();
        }

        public async Task CreateAsync(Item item)
        {
            _forumDbContext.Items.Add(item);
            await _forumDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Item item)
        {
            _forumDbContext.Items.Update(item);
            await _forumDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Item item)
        {
            _forumDbContext.Items.Remove(item);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
