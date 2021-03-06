﻿using System;

namespace Lambda.Duck.Init.Ducks
{
    public abstract class BaseDuck
    {
        public BaseDuck(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public abstract bool CanFly { get; }
        public abstract string Description { get; }
        public string Talent { get; set; } = "No special Talent";
        public string TypeOfQuack { get; set; } = "Quacks";
        public string TypeofDuck { get; set; } = "Basic Duck";

        public Guid DuckId = Guid.NewGuid();
        public DateTime Timestamp = DateTime.UtcNow;
    }
}
