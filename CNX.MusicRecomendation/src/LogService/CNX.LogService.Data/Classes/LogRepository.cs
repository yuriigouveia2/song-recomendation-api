using CNX.LogService.Data.DataContext;
using CNX.LogService.Data.Interfaces;
using CNX.LogService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CNX.LogService.Data.Classes
{
    public class LogRepository : ILogRepository
    {
        private readonly LogContext _context;
        public LogRepository(LogContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Log log)
        {
            using(var scope = new TransactionScope())
            {
                try
                {


                    log.Id = Guid.NewGuid();
                    log.CreatedAt = DateTime.Now;
                    log.Deleted = false;

                    await _context.Logs.AddAsync(log);
                    _context.SaveChanges();
                    scope.Complete();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
