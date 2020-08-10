using CNX.LogService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNX.LogService.Data.Interfaces
{
    public interface ILogRepository
    {
        Task CreateAsync(Log log);
    }
}
