using Amazon.DynamoDBv2.DataModel;

namespace Infrastructure.Network.DynamoDB.Models
{
    [DynamoDBTable("Account")]
    public class AccountDB
    {
        [DynamoDBHashKey]
        public string Username { get; set; }

        public string Password { get; set; }

        public string Message { get; set; }

        public string FontColor { get; set; }

        public string MessageGreeting { get; set; }
    }
}
