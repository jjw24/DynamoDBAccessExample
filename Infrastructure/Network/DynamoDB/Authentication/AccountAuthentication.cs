using Infrastructure.Network.DynamoDB.Models;
using System;

namespace Infrastructure.Network.DynamoDB.Authentication
{
    public static class AccountAuthentication
    {
        public static bool AuthenticationPassed(this string username, string password, Func<string, string, bool> authenticationMethod)
        {
            return authenticationMethod(username, password);
        }

        public static bool Method(string username, string password)
        {
            var accountRetrieved = username.Load<AccountDB>(DynamoDBAccess.ConnectMethod);

            if (accountRetrieved == null
                || !Encryption.ValidatePassword(password, accountRetrieved.Password))
            {
                return false;
            }

            return true;
        }
    }
}
