using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.MusicRecomendation.Model.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
