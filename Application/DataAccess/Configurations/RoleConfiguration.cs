using Application.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.HasMany(r => r.Clients)
                .WithOne(c => c.Role)
                .HasForeignKey(c => c.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Role_Clients");
        }
    }
}
