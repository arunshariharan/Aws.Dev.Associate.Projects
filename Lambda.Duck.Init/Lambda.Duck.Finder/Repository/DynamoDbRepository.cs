using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Lambda.Duck.Finder.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DAX;

namespace Lambda.Duck.Finder.Repository
{
    public class DynamoDbRepository
    {
        private const int MAX_PAGE_SIZE = 1;
        private const string TABLE_NAME = "Duck-DevAss";
        private readonly AmazonDynamoDBClient _client;
        //private readonly ClusterDaxClient _client;

        public DynamoDbRepository()
        {
            //var clientconfig = new DaxClientConfig("DAX_CLUSTER_ENDPOINT_HERE", 8111);
            //_client = new ClusterDaxClient(clientconfig);
            _client = new AmazonDynamoDBClient();
        }

        public async Task<List<BaseDuck>> FindDuck(DuckQuery param)
        {
            List<BaseDuck> ducks = new List<BaseDuck>();
            QueryRequest request = ConstructQuery(param);

            var response = await _client.QueryAsync(request);

            return ExtractDucksFromResponse(ducks, response);
        }

        private static List<BaseDuck> ExtractDucksFromResponse(List<BaseDuck> ducks, QueryResponse response)
        {
            foreach (var item in response.Items)
            {
                var duckDocument = Document.FromAttributeMap(item);
                var duckModel = JsonConvert.DeserializeObject<BaseDuck>(duckDocument.ToJson());
                ducks.Add(duckModel);
            }

            return ducks;
        }

        private static QueryRequest ConstructQuery(DuckQuery param)
        {
            return new QueryRequest
            {
                TableName = TABLE_NAME,
                KeyConditionExpression = "DuckId = :duckId",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> { { ":duckId", new AttributeValue { S = param.DuckId.ToString() } } },
                Limit = 1
            };
        }
    }
}
