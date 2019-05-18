using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lambda.Duck.Finder.Models
{
    public class DuckQuery
    {
        [Required]
        public Guid DuckId { get; set; }
    }
}
