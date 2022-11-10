using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projektas.Data.Dtos.Auctions;
using projektas.Data.Repositories;
using projektas.Data.Entities;

namespace projektas.Controllers
{
    [ApiController]
    [Route("api/auctions")]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionsRepository _auctionsRepository;
        public AuctionsController(IAuctionsRepository auctionsRepository)
        {
            _auctionsRepository = auctionsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<AuctionDto>> GetMany()
        {
            // _auctionsRepository.GetManyAsync();
            var auctions = await _auctionsRepository.GetManyAsync();
            return auctions.Select(o => new AuctionDto(o.Id, o.Name, o.Description, o.StartingTime, o.EndingTime, o.CreationDate));

        }
        //api/auctions/{id}
        [ActionName("GetA")]
        [HttpGet]
        [Route("{auctionId}")]
        public async Task<ActionResult<AuctionDto>> Get(int auctionId)
        {
            var auction = await _auctionsRepository.GetAsync(auctionId);
            //not found 404
            if (auction == null)
            {
                return NotFound($"Auction with id '{auctionId} not found'");
            }
            return new AuctionDto(auction.Id, auction.Name, auction.Description, auction.StartingTime, auction.EndingTime, auction.CreationDate);
        }

        [HttpPost]
        public async Task<ActionResult<AuctionDto>> Create(CreateAuctionDto createAuctionDto)
        {//Id = createAuctionDto.Id,
            var auction = new Auction { Name = createAuctionDto.Name, Description = createAuctionDto.Description, CreationDate = DateTime.UtcNow,
                StartingTime = createAuctionDto.StartingTime, EndingTime = createAuctionDto.EndingTime };

            if (auction.Name == null || auction.Description == null || auction.CreationDate == null || auction.StartingTime == null || auction.EndingTime == null)
            {
                return StatusCode(400, "Bad Request");
            }
            await _auctionsRepository.CreateAsync(auction);

            //201
            return CreatedAtAction("GetA", new { auctionId = auction.Id }, new AuctionDto(auction.Id, auction.Name, auction.Description, auction.StartingTime, auction.EndingTime, auction.CreationDate));

        }

        [HttpPut]
        [Route("{auctionId}")]
        public async Task<ActionResult<AuctionDto>> Update(int auctionId, UpdateAuctionDto updateAuctionDto)
        {

            var auction = await _auctionsRepository.GetAsync(auctionId);
            //not found 404
            if (auction == null)
            {
                return NotFound("Auction not found");
            }
            auction.Description = updateAuctionDto.Description;
            auction.StartingTime = updateAuctionDto.StartingTime;
            auction.EndingTime = updateAuctionDto.EndingTime;
            await _auctionsRepository.UpdateAsync(auction);
            return Ok(new AuctionDto(auction.Id, auction.Name, auction.Description, auction.StartingTime, auction.EndingTime, auction.CreationDate));
        }
        [HttpDelete]
        [Route("{auctionId}")]
        public async Task<ActionResult> Remove(int auctionId)
        {
            var auction = await _auctionsRepository.GetAsync(auctionId);

            //404
            if(auction == null)
            {
                return NotFound("Auction not found");
            }
            try
            {
                await _auctionsRepository.DeleteAsync(auction);

                //204
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Something is wrong");
            }
        }
    }
}
