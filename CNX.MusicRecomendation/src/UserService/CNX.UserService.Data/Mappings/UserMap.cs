using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CNX.UserService.Repository.Constantes;
using CNX.UserService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CNX.UserService.Repository.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType(DbTypes.PostreSQL.Varchar);
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasColumnType(DbTypes.PostreSQL.Varchar).IsRequired();
            builder.Property(x => x.Deleted).HasColumnName("deleted").HasDefaultValue(false).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired().HasDefaultValue();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasDefaultValue();
            builder.Property(x => x.DeletedAt).HasColumnName("deleted_at").HasDefaultValue();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType(DbTypes.PostreSQL.Varchar).IsRequired();
            builder.Property(x => x.HometownId).IsRequired().HasColumnName("hometown_id");

            builder.Property(x => x.UserName).HasColumnName("user_name");
            builder.Property(x => x.NormalizedUserName).HasColumnName("normalized_user_name");
            builder.Property(x => x.NormalizedEmail).HasColumnName("normalized_email");
            builder.Property(x => x.SecurityStamp).HasColumnName("security_stamp");
            builder.Property(x => x.PasswordHash).HasColumnName("password_hash");

            builder.HasIndex(x => new { x.Email }).IsUnique();
            builder.HasIndex(x => new { x.Cpf }).IsUnique();

            #region Ignored properties
            builder.Ignore(x => x.LockoutEnd);
            builder.Ignore(x => x.TwoFactorEnabled);
            builder.Ignore(x => x.PhoneNumberConfirmed);
            builder.Ignore(x => x.PhoneNumber);
            builder.Ignore(x => x.ConcurrencyStamp);
            //builder.Ignore(x => x.SecurityStamp);
            builder.Ignore(x => x.EmailConfirmed);
            //builder.Ignore(x => x.NormalizedEmail);
            //builder.Ignore(x => x.NormalizedUserName);
            //builder.Ignore(x => x.UserName);
            builder.Ignore(x => x.LockoutEnabled);
            builder.Ignore(x => x.AccessFailedCount);
            #endregion

            #region Relacionamentos
            #endregion
        }
    }
}
