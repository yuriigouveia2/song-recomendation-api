using CNX.LogService.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.LogService.Model.Entities
{
    public class Log : BaseEntity
    {
        public string Content { get; set; }
    }
}
