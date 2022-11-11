using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projektas.Auth.Model
{
    public interface IUserOwnedResource
    {
        public string UserId { get; }
    }
}
