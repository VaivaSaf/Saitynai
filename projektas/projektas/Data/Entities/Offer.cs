using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projektas.Data.Entities
{
    public class Offer
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Comment { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        public Item Item { get; set; }
    }
}
