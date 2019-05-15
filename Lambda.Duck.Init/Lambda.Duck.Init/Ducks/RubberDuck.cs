namespace Lambda.Duck.Init.Ducks
{
    class RubberDuck : NewDucks
    {
        public RubberDuck(string name) : base(name)
        {
            Talent = "Can live without water forever!";
            TypeOfQuack = " Squueaks";
            TypeofDuck = GetType().Name;
        }
        public override bool CanFly => false;
        public override string Description => "Made from synthetic, it usually looks yellow with cute facial expressions";
    }
}
