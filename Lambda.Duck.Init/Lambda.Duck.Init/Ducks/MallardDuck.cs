namespace Lambda.Duck.Init.Ducks
{
    public class MallardDuck : BaseDuck
    {
        public MallardDuck(string name) : base(name)
        {
            Talent = "This duck can walk on one leg for 3 km";
            TypeofDuck = GetType().Name;
        }
        public override bool CanFly => true;
        public override string Description => "This is a Mallard type of duck. These are commonly found in ponds and are red with spotted blue necks";
    }
}
