using ApiRest.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.DataAccess
{
    public class ApiDbContext : IdentityDbContext
    {
        public DbSet<FootballTeam> Teams { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Ignore<Entity>();
            base.OnModelCreating(modelbuilder);
        }

    }
}
