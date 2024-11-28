using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProviderInJobType
    {
        [Key, NotNull]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }
        public int JobTypeId { get; set; }
        public JobType? JobType { get; set; }
    }
}
