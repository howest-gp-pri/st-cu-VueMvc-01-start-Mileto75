using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services.Models
{
    public class ItemResultModel<T> where T : class
    {
        public IEnumerable<ValidationResult> ValidationErrors { get; set; }
        public IEnumerable<T> Items { get; set; }
        public bool IsSuccess { get; set; }
    }
}
