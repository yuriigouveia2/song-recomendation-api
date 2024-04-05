using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.LogService.Model
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpireInHours { get; set; }
        public string ValidIn { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string ApiGatewayUrl { get; set; }
    }
}
