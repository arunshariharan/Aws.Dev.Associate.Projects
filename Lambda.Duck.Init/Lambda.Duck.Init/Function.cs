using Amazon.Lambda.Core;
using Lambda.Duck.Init.Ducks;
using Lambda.Duck.Init.Operations;
using Lambda.Duck.Init.Validations;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambda.Duck.Init
{
    public class Function
    {
        public async Task<BaseDuck> FunctionHandler(DuckDto input, ILambdaContext context)
        {
            Validator.ValidateDuck(input);

            var duckOperations = new DuckOperations();

            if (string.IsNullOrEmpty(input.Name))
                duckOperations.GenerateNewName(ref input);
            
            var ducksType = duckOperations.GetTypesOfDucks();            

            var createdDuck = duckOperations.RandomDuck(ducksType, input.Name);

            await duckOperations.AddDuckToRepository(createdDuck);

            return createdDuck;
        }
    }
}
