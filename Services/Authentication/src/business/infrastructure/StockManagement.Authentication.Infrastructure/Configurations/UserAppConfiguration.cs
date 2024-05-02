using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.User.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Authentication.Infrastructure.Configurations
{
    internal class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Surname).IsRequired(true);
            //builder.Property(x => x.CreatedUserId).IsRequired(true);
            builder.Property(x => x.PhoneNumber).IsRequired(true);
            builder.Property(x => x.Address).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(50);
        }
    }
}
