using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projektas.Data.Entities;

namespace projektas.Data.Repositories
{
    public interface IOffersRepository
    {
        Task<Offer?> GetAsync(int itemId, int offerId);
        Task<IReadOnlyList<Offer>> GetManyAsync(int itemId);
        Task CreateAsync(Offer offer);
        Task UpdateAsync(Offer offer);
        Task DeleteAsync(Offer offer);

    }
}
