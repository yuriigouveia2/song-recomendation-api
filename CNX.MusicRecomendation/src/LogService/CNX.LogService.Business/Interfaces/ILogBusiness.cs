using CNX.LogService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNX.LogService.Business.Interfaces
{
    public interface ILogBusiness
    {
        Task Create(Log log);
    }
}
