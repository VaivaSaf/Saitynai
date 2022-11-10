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
    [Route("api/auctions/{auctionId}/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IAuctionsRepository _auctionsRepository;
        public ItemsController(IItemsRepository itemsRepository, IAuctionsRepository auctionsRepository)
        {
            _itemsRepository = itemsRepository;
            _auctionsRepository = auctionsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetMany(int auctionId)
        {
            var auction = await _auctionsRepository.GetAsync(auctionId);
            if (auction == null)
            {
                return NotFound("auction not found");
            }
            var items = await _itemsRepository.GetManyAsync(auctionId);
            return Ok(items.Select(o => new ItemDto(o.Id, o.Name, o.Description, o.Category, o.Country, o.CreationDate, o.MinimalPrice, auctionId)));// o => new ItemDto(o.Id, o.Name, o.Description, o.Category, o.Country, o.CreationDate, o.MinimalPrice));
            //  return auctions.Select(o => new AuctionDto(o.Id, o.Name, o.Description, o.StartingTime, o.EndingTime, o.CreationDate));
        }

        //api/auctions/{id}
        //[ActionName("GetI")]
        [HttpGet]
        [Route("{itemId}")]
        public async Task<ActionResult<ItemDto>> Get(int auctionId, int itemId)
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
            return new ItemDto(item.Id, item.Name, item.Description, item.Category, item.Country, item.CreationDate, item.MinimalPrice, auctionId);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> Create(CreateItemDto createItemDto, int auctionId)
        {//Id = createAuctionDto.Id,
            var auction = await _auctionsRepository.GetAsync(auctionId);
            if (auction == null)
            {
                return NotFound("auction not found");
            }
            var item = new Item
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Category = createItemDto.Category,
                Country = createItemDto.Country,
                CreationDate = DateTime.UtcNow,
                MinimalPrice = createItemDto.MinimalPrice,
                Auction = auction
            };
            if (item.Name == null || item.Description == null || item.Category == null || item.Country == null || item.CreationDate== null || item.MinimalPrice ==null)
            {
                return StatusCode(400, "Bad Request");
            }
            await _itemsRepository.CreateAsync(item);

            //201
            return Created($"api/auctions/{auctionId}/items/{item.Id}", new ItemDto(item.Id, item.Name, item.Description, item.Category, item.Country, item.CreationDate, item.MinimalPrice, auctionId));

        }

        [HttpPut]
        [Route("{itemId}")]
        public async Task<ActionResult<ItemDto>> Update(int auctionId, int itemId, UpdateItemDto updateItemDto)
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

            item.Name = updateItemDto.Name;
            item.Description = updateItemDto.Description;

            await _itemsRepository.UpdateAsync(item);
            return Ok(new ItemDto(item.Id, item.Name, item.Description, item.Category, item.Country, item.CreationDate, item.MinimalPrice, auctionId));
        }
        [HttpDelete]
        [Route("{itemId}")]
        public async Task<ActionResult> Remove(int auctionId, int itemId)
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
            try
            {
                await _itemsRepository.DeleteAsync(item);
                //204
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something is wrong");

            }
        }
    }
}
