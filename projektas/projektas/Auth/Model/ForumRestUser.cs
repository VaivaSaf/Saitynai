using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace projektas.Auth.Model
{
    public class ForumRestUser : IdentityUser
    {
        [PersonalData]
        public string? Info { get; set; }
    }
}
