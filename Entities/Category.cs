﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        [Key, NotNull]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }=DateTime.Now;
        public DateTime UpdateTime { get; set; }= DateTime.Now;
        public string? CategoryName { get; set; }
        public string? PhotoURL { get; set; }
    }
}
