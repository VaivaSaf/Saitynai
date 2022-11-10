using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projektas.Data.Entities
{
    public class Item
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Description { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required, StringLength(50)]
        public string Country { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public decimal MinimalPrice { get; set; }

        public Auction Auction { get; set; }

    }
}
