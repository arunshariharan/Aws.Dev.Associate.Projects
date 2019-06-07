using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda.Duck.Finder.Models
{
    public class BaseDuck
    {
        public string Name { get; set; }
        public bool CanFly { get; set; }
        public string Description { get; set; }
        public string Talent { get; set; }
        public string TypeOfQuack { get; set; }
        public string TypeofDuck { get; set; }
        public Guid DuckId { get; set; }
        public DateTime Timestamp = DateTime.UtcNow;
    }
}
