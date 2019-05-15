using Lambda.Duck.Init.Ducks;
using System;

namespace Lambda.Duck.Init.Validations
{
    public static class Validator
    {
        public static void ValidateDuck(DuckDto input)
        {
            if (input == null)
                throw new ArgumentNullException("Input must not be empty");
        }
    }
}
