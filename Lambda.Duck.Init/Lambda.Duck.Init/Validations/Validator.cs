using Lambda.Duck.Init.Ducks;
using System;
using System.Collections.Generic;
using System.Text;

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
