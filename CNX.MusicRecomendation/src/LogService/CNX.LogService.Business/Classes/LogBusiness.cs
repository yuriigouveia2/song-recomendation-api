using CNX.LogService.Business.Interfaces;
using CNX.LogService.Business.Utils;
using CNX.LogService.Data.Interfaces;
using CNX.LogService.Model;
using System.Threading.Tasks;
using CNX.LogService.Model.Entities;

namespace CNX.LogService.Business.Classes
{
    public class LogBusiness : BaseBusiness, ILogBusiness
    {
        private readonly ILogRepository _logRepository;

        public LogBusiness(ILogRepository logRepository,
                            INotifier notifier) : base(notifier)
        {
            _logRepository = logRepository;
        }

        public async Task Create(Log log)
        {
            await _logRepository.CreateAsync(log);
        }
    }
}
