using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using projektas.Data.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using projektas.Auth.Model;

namespace projektas.Data
{
    public class ForumDbContext : IdentityDbContext<ForumRestUser>
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Offer> Offers { get; set; }
       // public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=kolekcionierius");
                optionsBuilder.UseSqlServer("Server=tcp:saitynai-db-serveris.database.windows.net,1433;Initial Catalog=saitynai-db;Persist Security Info=False;User ID=azureadmin;Password=Slaptazodis.1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //optionsBuilder.UseMySql("server=localhost;port=3306;database=kolekcionierius;uid=root;pwd=;Convert Zero Datetime=True;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.36-mysql"));
            }
        }
    }
}
