using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProviderInField
    {
        [Key, NotNull]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }
        public int FieldId { get; set; }
        public Field? Field { get; set; }
        public int NumOfRanks { get; set; }
        public int OveralAverage { get; set; }
        public int QualityAverage { get; set; }
        public int PriceAverage { get; set; }
        public int TimelinesAverage { get; set; }
        public int AttitudeAverage { get; set; }
        public int VerySatisfiedCustomerNumbr { get; set; }
        public int SatisfiedCustomerNumber { get; set; } //תאריך משוב
        public int DissatisfiedCustomerNumber { get; set; } //תאריך אישרור

    }
}
