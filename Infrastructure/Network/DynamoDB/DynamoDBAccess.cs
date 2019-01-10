using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System;

namespace Infrastructure.Network.DynamoDB
{
    public static class DynamoDBAccess
    {
        public static DynamoDBContext ConnectMethod()
        {
            var config = new AmazonDynamoDBConfig();

            AmazonDynamoDBClient client = new AmazonDynamoDBClient(config);

            var context = new DynamoDBContext(client);

            return context;
        }

        //SDK cant handle ""- empty string
        public static T Load<T>(this string userName, Func<DynamoDBContext> connect)
            => connect().Load<T>(string.IsNullOrWhiteSpace(userName) ? " " : userName.ToLower());
    }
}
