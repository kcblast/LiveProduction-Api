using LiveProduction_Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Data
{
    public class LiveProductionDbConext : DbContext
    {
        public LiveProductionDbConext(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Update> Updated { get; set; }
    }
    
}
