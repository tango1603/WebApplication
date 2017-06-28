using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addreses { get; set; }
    }
}
