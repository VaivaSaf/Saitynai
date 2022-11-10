using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using projektas.Data.Entities;

namespace projektas.Data.Repositories
{
    public class OffersRepository : IOffersRepository
    {
        private readonly ForumDbContext _forumDbContext;
        public OffersRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }

        public async Task<Offer?> GetAsync( int itemId, int offerId)
        {
            return await _forumDbContext.Offers.FirstOrDefaultAsync(o => o.Item.Id == itemId && o.Id == offerId);
        }
        public async Task<IReadOnlyList<Offer>> GetManyAsync(int itemId)
        {
            return await _forumDbContext.Offers.Where(o => o.Item.Id == itemId).ToListAsync();
        }

        public async Task CreateAsync(Offer offer)
        {
            _forumDbContext.Offers.Add(offer);
            await _forumDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Offer offer)
        {
            _forumDbContext.Offers.Update(offer);
            await _forumDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Offer offer)
        {
            _forumDbContext.Offers.Remove(offer);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
