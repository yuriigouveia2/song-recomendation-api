using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CNX.LogService.Repository.Constantes;
using CNX.LogService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CNX.LogService.Repository.Mappings.Base;

namespace CNX.LogService.Repository.Mappings
{
    public class LogMap : BaseMap<Log>
    {
        public override void Configure(EntityTypeBuilder<Log> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Content).HasColumnName("content").HasColumnType(DbTypes.PostreSQL.Varchar).IsRequired();
        }
    }
}
