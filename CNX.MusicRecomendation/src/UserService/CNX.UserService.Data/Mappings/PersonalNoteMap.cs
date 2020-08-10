using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CNX.UserService.Repository.Constantes;
using CNX.UserService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CNX.UserService.Repository.Mappings.Base;

namespace CNX.UserService.Repository.Mappings
{
    public class PersonalNoteMap : BaseMap<PersonalNote>
    {
        public override void Configure(EntityTypeBuilder<PersonalNote> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Note).HasColumnName("note").HasColumnType(DbTypes.PostreSQL.Varchar).IsRequired();
            builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();

            #region Relacionamentos
            builder.HasOne(x => x.User).WithMany(x => x.PersonalNotes).HasForeignKey(x => x.UserId);
            #endregion
        }
    }
}
