using Amazon.DynamoDBv2;
using Lambda.Duck.Init.Ducks;
using Lambda.Duck.Init.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Amazon.XRay.Recorder.Handlers.AwsSdk;

namespace Lambda.Duck.Init.Operations
{
    public class DuckOperations
    {
        private readonly IDynamoDbRepository _repository = new DynamoDbRepository();
        private readonly AmazonDynamoDBClient _client = new AmazonDynamoDBClient();
        //private readonly ClusterDaxClient _client;

        public DuckOperations()
        {
            //var config = new DaxClientConfig("DAX_CLUSTER_ENDPOINT_HERE", 8111);
            //_client = new ClusterDaxClient(config);
            AWSSDKHandler.RegisterXRayForAllServices();
            _client = new AmazonDynamoDBClient();
            
        }

        const string TABLE_NAME = "Duck-DevAss";

        public async Task AddDuckToRepository(BaseDuck createdDuck)
        {
            try
            {
                var table = await _repository.GetTable(TABLE_NAME, _client);
                if (table != null)
                {
                    await _repository.AddDuckToTable(table, createdDuck);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to write to Table: " + e);
            }
        }

        internal void GenerateNewName(ref DuckDto input)
        {
            input.Name = Guid.NewGuid().ToString().Split('-')[0];
        }

        public IEnumerable<Type> GetTypesOfDucks()
        {
            Type type = typeof(BaseDuck);
            var listOfTypes = Assembly.GetExecutingAssembly().GetTypes();

            var listOfDuckTypes = listOfTypes.Where(t => t.BaseType == type);

            return listOfDuckTypes;
        }

        public BaseDuck RandomDuck(IEnumerable<Type> ducksType, string name)
        {
            var rand = new Random();
            var x = rand.Next(ducksType.Count());
            var el = ducksType.ElementAt(x);

            BaseDuck duck = (BaseDuck)Activator.CreateInstance(el, name);

            return duck;
        }
    }
}
