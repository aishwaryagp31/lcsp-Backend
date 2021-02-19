using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackendAPI.Models
{
    public class ServicePortalContext : IdentityDbContext
    {
        public ServicePortalContext(DbContextOptions<ServicePortalContext> options) : base(options)
        {

        }
        public DbSet<User> Userss { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}

