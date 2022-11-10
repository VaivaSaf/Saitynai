using System;
using projektas.Data.Entities;

namespace projektas.Data.Dtos.Items
{
    //public class AuctionsDto
    //{
    public record OfferDto(int Id, string Name, string Comment, decimal Price, DateTime CreationDate, int ItemId);
    public record CreateOfferDto(string Name, string Comment, decimal Price, DateTime CreationDate);
    public record UpdateOfferDto(string Name, string Comment);
    //}


}