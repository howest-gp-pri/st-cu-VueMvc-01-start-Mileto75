using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services.Models
{
    public class AuthenticateResultModel
    {
        public bool Success { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
