using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Lambda.Duck.Init.Ducks;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Lambda.Duck.Init.Repository
{
    class DynamoDbRepository : IDynamoDbRepository
    {
        const int MAX_PAGE_SIZE = 1;

        public async void AddDuckToTable(Table table, BaseDuck duck)
        {
            var serializedDuck = JsonConvert.SerializeObject(duck);
            Document duckDocument = Document.FromJson(serializedDuck);

            await table.PutItemAsync(duckDocument);
        }
        
        public async Task<Table> GetTable(string tableName, AmazonDynamoDBClient client)
        {
            ListTablesResponse response = await client.ListTablesAsync(limit: MAX_PAGE_SIZE);
            if (response.TableNames.Contains(tableName))
            {
                return Table.LoadTable(client, tableName);
            }

            return null;
        }
    }
}
