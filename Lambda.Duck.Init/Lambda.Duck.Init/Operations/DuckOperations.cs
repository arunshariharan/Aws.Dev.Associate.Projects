using Amazon.DynamoDBv2;
using Lambda.Duck.Init.Ducks;
using Lambda.Duck.Init.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lambda.Duck.Init.Operations
{
    public class DuckOperations
    {
        private readonly IDynamoDbRepository _repository = new DynamoDbRepository();
        private readonly AmazonDynamoDBClient _client = new AmazonDynamoDBClient();

        const string TABLE_NAME = "Duck-DevAss";

        public async void AddDuckToRepository(NewDucks createdDuck)
        {
            var table = await _repository.GetTable(TABLE_NAME, _client);

            if (table != null)
            {
                _repository.AddDocument(table, createdDuck);
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
            Type type = typeof(NewDucks);
            var listOfTypes = Assembly.GetExecutingAssembly().GetTypes();

            var listOfDuckTypes = listOfTypes.Where(t => t.BaseType == type);

            return listOfDuckTypes;
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
