using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace feedTheDuck.Context
{
    public class DuckFeedRecords
    {
        public DuckFeedRecords() { }

        public Guid Id { get; set; }
        public string Location { get; set; }
        public string DuckType { get; set; }
        public long DuckAmount { get; set; }
        public string Food { get; set; }
        public string FoodMetric { get; set; }
        public long FoodAmount { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        internal static void OnModelCreating(EntityTypeBuilder<DuckFeedRecords> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id)
                .HasDefaultValueSql("(newid())");

            entity.Property(x => x.Location)
                 .IsRequired()
                 .HasMaxLength(32);

            entity.Property(x => x.DuckType)
                .IsRequired()
                .HasMaxLength(32);

            entity.Property(x => x.Food)
                 .IsRequired()
                 .HasMaxLength(256);

            entity.Property(x => x.FoodMetric)
                .IsRequired()
                .HasMaxLength(8);

            entity.Property(x => x.FoodAmount)
                 .IsRequired();

            entity.Property(x => x.DuckAmount)
                .IsRequired();

            entity.Property(x => x.DuckType)
                .IsRequired()
                .HasMaxLength(32);

            entity.Property(x => x.CreatedBy)
                 .IsRequired()
                 .HasMaxLength(64);

            entity.Property(x => x.UpdatedBy)
                .IsRequired()
                .HasMaxLength(64);

            entity.Property(x => x.CreatedOn)
                .IsRequired();

            entity.Property(x => x.UpdatedOn)
                .IsRequired();

        }
    }
}
