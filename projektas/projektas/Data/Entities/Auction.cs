using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using projektas.Auth.Model;

namespace projektas.Data.Entities
{
    public class Auction : IUserOwnedResource
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string Description { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime StartingTime { get; set; }
        [Required]
        public DateTime EndingTime { get; set; }

        [Required]
        public string UserId { get; set; }

        public ForumRestUser User { get; set; }

    }
}
