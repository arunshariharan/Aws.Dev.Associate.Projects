using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Lambda.Duck.Init.Ducks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Duck.Init.Repository
{
    class DynamoDbRepository : IDynamoDbRepository
    {
        public async void AddDocument(Table table, NewDucks duck)
        {
            var serializedDuck = JsonConvert.SerializeObject(duck);
            Document duckDocument = Document.FromJson(serializedDuck);

            await table.PutItemAsync(duckDocument);
        }

        public AmazonDynamoDBClient CreateClient()
        {
            try
            {
                AmazonDynamoDBClient client = new AmazonDynamoDBClient();
                return client;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create dynomoDB Client. " + ex.Message);
                throw new Exception();
            }
        }

        public void CreateTable()
        {
            throw new NotImplementedException();
        }

        public bool DeleteDocument()
        {
            throw new NotImplementedException();
        }

        public async Task<Table> GetTable(string tableName, AmazonDynamoDBClient client)
        {
            ListTablesResponse response = await client.ListTablesAsync(limit: 1);
            if (response.TableNames.Contains(tableName))
            {
                return Table.LoadTable(client, tableName);
            }

            return null;
        }

        public bool UpdateDocument()
        {
            throw new NotImplementedException();
        }
    }
}
