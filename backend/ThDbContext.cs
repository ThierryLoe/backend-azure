using System;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class ThDbContext : DbContext
    {
        public ThDbContext(DbContextOptions<ThDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }

    }
}
