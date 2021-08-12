using System;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ThDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
