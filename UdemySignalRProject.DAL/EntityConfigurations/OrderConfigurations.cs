using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.DAL.EntityConfigurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Date).HasColumnType("Date");
            builder.Property(x => x.Description).HasMaxLength(200);
        }
    }
}
