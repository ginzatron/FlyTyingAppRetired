using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.DataLayer
{
    public class UsersContext : IdentityDbContext<IdentityUser>
    {
        public UsersContext(DbContextOptions<UsersContext> options)
        :base(options)
        {
        }
    }
}
