using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.TravelContext
{
    public class TravelsContext : DbContext
    {
        public TravelsContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<UserEntity> UsersTable { get; set; }

        public DbSet<ListEntity> ListTable { get; set; }

    }
}
