using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace feedTheDuck.Context
{
    public class UserAccess
    {
        public UserAccess() { }

        public Guid Id { get; set; }
        public string User { get; set; }
        public string Code { get; set; }
        public DateTime CreatedOn { get; set; }

        internal static void OnModelCreating(EntityTypeBuilder<UserAccess> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .HasDefaultValueSql("(newid())");

            entity.Property(x => x.User)
                 .IsRequired()
                 .HasMaxLength(64);

            entity.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(x => x.CreatedOn)
                 .IsRequired();
        }
    }
}
