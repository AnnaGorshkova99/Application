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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable(nameof(Room));

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.HasMany(r => r.Clients)
                .WithOne(c => c.Room)
                .HasForeignKey(c => c.RoomId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Room_Clients");
        }
    }
}
