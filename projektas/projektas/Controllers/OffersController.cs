using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projektas.Data.Dtos.Items;
using projektas.Data.Repositories;
using projektas.Data.Entities;

namespace projektas.Controllers
{
    [ApiController]
    [Route("api/auctions/{auctionId}/items/{itemId}/offers")]
    public class OffersController : ControllerBase
    {
        private readonly IOffersRepository _offersRepository;
        private readonly IItemsRepository _itemsRepository;
        private readonly IAuctionsRepository _auctionsRepository;
        public OffersController(IOffersRepository offersRepository,IItemsRepository itemsRepository, IAuctionsRepository auctionsRepository)
        {
            _itemsRepository = itemsRepository;
            _auctionsRepository = auctionsRepository;
            _offersRepository = offersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferDto>>> GetMany(int auctionId, int itemId)
        {
            var auction = await _auctionsRepository.GetAsync(auctionId);
            if (auction == null)
            {
                return NotFound("auction not found");
            }
            var item = await _itemsRepository.GetAsync(auctionId, itemId);
            if (item == null)
            {
                return NotFound("item not found");
            }
            var offers = await _offersRepository.GetManyAsync(itemId);
            return Ok(offers.Select(o => new OfferDto(o.Id, o.Name, o.Comment, o.Price, o.CreationDate, itemId)));
        }
     
        //api/auctions/{id}
        //[ActionName("GetI")]
        [HttpGet]
        [Route("{offerId}")]
        public async Task<ActionResult<OfferDto>> Get(int auctionId, int itemId, int offerId)
        {
            var auction = await _auctionsRepository.GetAsync(auctionId);
            //not found 404
            if (auction == null)
            {
                return NotFound($"Auction with id '{auctionId}' not found'");
            }
            var item = await _itemsRepository.GetAsync(auctionId, itemId);
            if (item == null)
            {
                return NotFound($"Item with id '{itemId}' ");
            }
            var offer = await _offersRepository.GetAsync(itemId, offerId);
            if (offer == null)
            {
                return NotFound($"offer with id '{offerId}' ");
            }

            return new OfferDto(offer.Id, offer.Name, offer.Comment, offer.Price, offer.CreationDate, itemId);
        }

        [HttpPost]
        public async Task<ActionResult<OfferDto>> Create(CreateOfferDto createofferDto, int auctionId, int itemId)
        {//Id = createAuctionDto.Id,
            var auction = await _auctionsRepository.GetAsync(auctionId);
            if (auction == null)
            {
                return NotFound("auction not found");
            }
            var item = await _itemsRepository.GetAsync(auctionId, itemId);
            if (item == null)
            {
                return NotFound("itme not found");
            }
            var offer = new Offer
            {
                Name = createofferDto.Name,
                Comment = createofferDto.Comment,
                Price = createofferDto.Price,
                CreationDate = DateTime.UtcNow,
                Item = item
            };
            if (offer.Name == null || offer.Comment == null || offer.Price == null || offer.CreationDate == null)
            {
                return StatusCode(400, "Bad Request");
            }

            await _offersRepository.CreateAsync(offer);

            //201
            return Created($"api/auctions/{auctionId}/items/{itemId}/offers/{offer.Id}", new OfferDto(offer.Id, offer.Name, offer.Comment, offer.Price, offer.CreationDate, itemId));
        }
        [HttpPut]
        [Route("{offerId}")]
        public async Task<ActionResult<OfferDto>> Update(int auctionId, int itemId, int offerId, UpdateOfferDto updateOfferDto)
        {

            var auction = await _auctionsRepository.GetAsync(auctionId);
            //not found 404
            if (auction == null)
            {
                return NotFound("Auction not found");
            }
            var item = await _itemsRepository.GetAsync(auctionId, itemId);
            if (item == null)
            {
                return NotFound("Item not found");
            }
            var offer = await _offersRepository.GetAsync(itemId, offerId);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }
            offer.Name = updateOfferDto.Name;
            offer.Comment = updateOfferDto.Comment;

            await _offersRepository.UpdateAsync(offer);
            return Ok(new OfferDto(offer.Id, offer.Name, offer.Comment, offer.Price, offer.CreationDate, itemId));
        }
        [HttpDelete]
        [Route("{offerId}")]
        public async Task<ActionResult> Remove(int auctionId, int itemId, int offerId)
        {
            var auction = await _auctionsRepository.GetAsync(auctionId);

            //404
            if (auction == null)
            {
                return NotFound("Auction not found");
            }
            var item = await _itemsRepository.GetAsync(auctionId, itemId);
            if (item == null)
            {
                return NotFound("Item not found");
            }
            var offer = await _offersRepository.GetAsync(itemId, offerId);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }
            await _offersRepository.DeleteAsync(offer);

            //204
            return NoContent();
        }
    }
}
