using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Lambda.Duck.Init.Ducks;
using System.Threading.Tasks;

namespace Lambda.Duck.Init.Repository
{
    public interface IDynamoDbRepository
    {
        void AddDuckToTable(Table table, BaseDuck duck);
        Task<Table> GetTable(string tableName, AmazonDynamoDBClient client);
        
    }
}
