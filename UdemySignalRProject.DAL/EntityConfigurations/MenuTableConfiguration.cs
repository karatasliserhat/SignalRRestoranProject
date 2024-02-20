using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.DAL.EntityConfigurations
{
    public class MenuTableConfiguration : IEntityTypeConfiguration<MenuTable>
    {
        public void Configure(EntityTypeBuilder<MenuTable> builder)
        {
            builder.HasKey(x => x.MenuTableId);
            builder.Property(x => x.Name).HasMaxLength(80);
        }
    }
}
