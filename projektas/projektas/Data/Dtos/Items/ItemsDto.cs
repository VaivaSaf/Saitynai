using System;
using projektas.Data.Entities;

namespace projektas.Data.Dtos.Items
{
    //public class AuctionsDto
    //{
    public record ItemDto(int Id, string Name, string Description, Category Category, string Country, DateTime CreationDate, decimal MinimalPrice, int AuctionId);
    public record CreateItemDto(string Name, string Description, Category Category, string Country, DateTime CreationDate, decimal MinimalPrice);
    public record UpdateItemDto(string Name, string Description);
    //}


}