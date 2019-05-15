using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lambda.Duck.Init.Ducks;
using Amazon.Lambda.Core;
using System.Reflection;
using System.Net;
using Lambda.Duck.Init.Repository;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Lambda.Duck.Init.Operations;
using Lambda.Duck.Init.Validations;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambda.Duck.Init
{
    public class Function
    {
        public NewDucks FunctionHandler(DuckDto input, ILambdaContext context)
        {
            Validator.ValidateDuck(input);

            var duckOperations = new DuckOperations();

            if (string.IsNullOrEmpty(input.Name))
                duckOperations.GenerateNewName(ref input);
            
            var ducksType = duckOperations.GetTypesOfDucks();            

            var createdDuck = duckOperations.RandomDuck(ducksType, input.Name);

            duckOperations.AddDuckToRepository(createdDuck);

            return createdDuck;
        }
    }
}
