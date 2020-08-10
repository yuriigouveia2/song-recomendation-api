using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CNX.LogService.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.LogService.Repository.Mappings.Base
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedNever()
                .IsRequired();
            builder.Property(x => x.Deleted)
                .HasColumnName("deleted")
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValue();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasDefaultValue();
            builder.Property(x => x.DeletedAt).HasColumnName("deleted_at").HasDefaultValue();
        }
    }
}
