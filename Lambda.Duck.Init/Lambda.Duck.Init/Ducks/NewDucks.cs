using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda.Duck.Init.Ducks
{
    public abstract class NewDucks
    {
        public NewDucks(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public abstract bool CanFly { get; }
        public abstract string Description { get; }
        public string Talent { get; set; } = "No special Talent";
        public string TypeOfQuack { get; set; } = "Quacks";
        public string TypeofDuck { get; set; } = "Basic Duck";
    }
}
