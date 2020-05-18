using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnightsBridge.Areas.Identity.Data;
using KnightsBridge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KnightsBridge.Data
{
    public class KnightsBridgeContext : IdentityDbContext<KnightsBridgeUser>
    {
        public DbSet<Event> Events { get; set;
        }
        public KnightsBridgeContext(DbContextOptions<KnightsBridgeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
