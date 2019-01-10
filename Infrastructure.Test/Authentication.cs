using Infrastructure.Network.DynamoDB.Authentication;
using NUnit.Framework;

namespace Infrastructure.Test
{
    [TestFixture]
    public class Authentication
    {
        [TestCase("username", "password")]
        [TestCase("", "password")]
        [TestCase(" ", "password")]
        [TestCase("username", "")]
        [TestCase("username", " ")]
        [TestCase("", "")]
        [TestCase(" ", " ")]
        [TestCase(null, null)]
        [TestCase("username", null)]
        [TestCase(null, "password")]
        public void WhenGivenWrongCredentialThenShouldReturnFalse(string username, string password)
        {
            //Given, When
            var result = AccountAuthentication.AuthenticationPassed(username, password, AccountAuthentication.Method);

            //Then
            Assert.False(result);
        }
    }
}
