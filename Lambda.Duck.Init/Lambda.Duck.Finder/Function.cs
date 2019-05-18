using Amazon.Lambda.Core;
using Lambda.Duck.Finder.Models;
using Lambda.Duck.Finder.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambda.Duck.Finder
{
    public class Function
    {
        public async Task<List<BaseDuck>> FunctionHandler(DuckQuery input, ILambdaContext context)
        {
            var repository = new DynamoDbRepository();
            return await repository.FindDuck(input);
        }
    }
}
