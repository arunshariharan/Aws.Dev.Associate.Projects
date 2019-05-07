using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lambda.Duck.Init.Ducks;
using Amazon.Lambda.Core;
using System.Reflection;
using System.Net;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambda.Duck.Init
{
    public class Function
    {
        public NewDucks FunctionHandler(DuckDto input, ILambdaContext context)
        {
            var ducksType = GetTypesOfDucks();

            if (string.IsNullOrEmpty(input.Name))
                throw new Exception("Does not contain name for a duck");

            return RandomDuck(ducksType, input.Name);
        }

        public IEnumerable<Type> GetTypesOfDucks()
        {
            Type type = typeof(NewDucks);
            var listOfTypes = Assembly.GetExecutingAssembly().GetTypes();

            var list = listOfTypes.Where(t => t.BaseType == type);

            return list;
        }

        public NewDucks RandomDuck(IEnumerable<Type> ducksType, string name)
        {
            var rand = new Random();
            var x = rand.Next(ducksType.Count());
            var el = ducksType.ElementAt(x);

            NewDucks duck = (NewDucks)Activator.CreateInstance(el, name);

            return duck;
        }
    }
}
