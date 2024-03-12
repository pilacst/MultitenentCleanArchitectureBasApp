using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inoflix.Web.Application.Helpers
{
    public class TokenConfigOptions
    {
        public const string JWT = "JWT";
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
        public int ExpirationInMin { get; set; }
    }
}
