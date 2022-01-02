using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace feedTheDuck.Context
{
    public class DuckContext : DbContext
    {
        public DuckContext(DbContextOptions<DuckContext> options)
            : base(options)
        {

        }

        public DuckContext() { }

        public virtual DbSet<DuckFeedRecords> DuckFeedRecords { get; set; }
        public virtual DbSet<UserAccess> UserAccess { get; set; }
    }
}
