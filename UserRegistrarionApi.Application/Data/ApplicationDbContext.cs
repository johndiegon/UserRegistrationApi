using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationApi.Application.Data.Repositories;

namespace UserRegistrationApi.Application.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<ContactEntity> Contact { get; set; }
        public DbSet<UserEntity> User { get; set; }

    }
}
