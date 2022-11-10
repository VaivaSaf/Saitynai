using System;


namespace projektas.Data.Dtos.Auctions
{
    //public class AuctionsDto
    //{
        public record AuctionDto(int Id,string Name, string Description, DateTime StartingTime, DateTime EndingTime, DateTime CreationDate);
        public record CreateAuctionDto(string Name, string Description, DateTime CreationDate, DateTime StartingTime, DateTime EndingTime);
        public record UpdateAuctionDto(string Description, DateTime StartingTime, DateTime EndingTime);
    //}


}