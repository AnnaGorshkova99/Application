using Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Configurations
{
    class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable(nameof(Specialization));

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.HasMany(s => s.Employees)
                .WithOne(e => e.Specialization)
                .HasForeignKey(e => e.SpecializationId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Specialization_Employees");
        }
    }
}
