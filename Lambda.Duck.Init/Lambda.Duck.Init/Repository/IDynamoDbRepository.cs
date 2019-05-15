using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Lambda.Duck.Init.Ducks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Duck.Init.Repository
{
    public interface IDynamoDbRepository
    {
        void AddDocument(Table table, NewDucks duck);
        AmazonDynamoDBClient CreateClient();
        Task<Table> GetTable(string tableName, AmazonDynamoDBClient client);
        void CreateTable();        
        bool DeleteDocument();
        bool UpdateDocument();
        
    }
}
