using Amazon.DAX;
using Amazon.DynamoDBv2;
using Lambda.Duck.Init.Ducks;
using Lambda.Duck.Init.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            _client = new AmazonDynamoDBClient();
        }

        const string TABLE_NAME = "Duck-DevAss";

        public async void AddDuckToRepository(BaseDuck createdDuck)
        {
            var table = await _repository.GetTable(TABLE_NAME, _client);

            if (table != null)
            {
                _repository.AddDuckToTable(table, createdDuck);
            }
            else
            {
                Console.WriteLine("Unable to write to Table");
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
