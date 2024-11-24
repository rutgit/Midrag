using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PhotosInRank
    {
        [Key, NotNull]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int RankId { get; set; }
        public Rank? Rank { get; set; }
        public string? PhotoURL { get; set; }
        public bool IsNice { get; set; }
    }
}
