using Pear.Africa.Assessment.Domain.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pear.Africa.Assessment.Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        // Add User and Role navigation properties
        public void Configure(EntityTypeBuilder<User> builder)
        {

            // Each User can have many UserLogins
            builder
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            builder
                .HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

        }
    }
}
