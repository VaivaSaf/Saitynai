using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projektas.Data.Entities;

namespace projektas.Data.Repositories
{
    public interface IItemsRepository
    {
        Task<Item?> GetAsync(int auctionId, int itemId);
        Task<IReadOnlyList<Item>> GetManyAsync(int auctionId);
        Task CreateAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Item item);

    }
}