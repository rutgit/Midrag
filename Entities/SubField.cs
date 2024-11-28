using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SubField
    {
        [Key, NotNull]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public int FieldId { get; set; }
        public Field? Field { get; set; }
        public string SubFieldName { get; set; }
    }
}
