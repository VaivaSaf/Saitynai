using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projektas.Auth.Model
{
    public static class ForumRoles
    {
        public const string Admin = nameof(Admin);
        public const string SystemUser = nameof(SystemUser);
        public static readonly IReadOnlyCollection<string> All = new[] { Admin, SystemUser };
    }
}
