namespace Lambda.Duck.Init.Ducks
{
    class WoodenDuck : NewDucks
    {
        public WoodenDuck(string name) : base(name)
        {
            Talent = "Will never drown!";
            TypeofDuck = GetType().Name;
        }
        public override bool CanFly => false;
        public override string Description => "Made from Hardwood usually, this is brownish red in color. Usually the size of palm, this can be custom colored.";

    }
}
