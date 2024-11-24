using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rank
    {
        [Key, NotNull]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }
        public string? CustomerName { get; set; }
        public string? ServiceInfo { get; set; }
        public int QualityRating { get; set; }
        public int PriceRating { get; set; }
        public int TimelinesRating { get; set; }
        public int AttitudeRating { get; set; }
        public string? Feedback { get; set; }
        public DateTime FeedbackDate { get; set; } //תאריך משוב
        public DateTime ApprovalDate { get; set; } //תאריך אישרור

    }
}
