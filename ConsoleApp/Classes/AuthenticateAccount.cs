using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Tweetinvi;

namespace ConsoleApp.Classes
{
    public class AuthenticateAccount
    {
        public async Task AuthenticateAcc()
        {
            var appClient = new TwitterClient("CONSUMER_KEY", "CONSUMER_SECRET");

            // Start the authentication process
            var authenticationRequest = await appClient.Auth.RequestAuthenticationUrlAsync();

            // Go to the URL so that Twitter authenticates the user and gives him a PIN code.
            Process.Start(new ProcessStartInfo(authenticationRequest.AuthorizationURL)
            {
                UseShellExecute = true
            });

            // Ask the user to enter the pin code given by Twitter
            Console.WriteLine("Please enter the code and press enter.");
            var pinCode = Console.ReadLine();

            // With this pin code it is now possible to get the credentials back from Twitter
            var userCredentials = await appClient.Auth.RequestCredentialsFromVerifierCodeAsync(pinCode, authenticationRequest);

            // You can now save those credentials or use them as followed
            // to save, write them to files using:
            /*
                userClient.Credentials.AccessToken.ToString();
                // save to file

            */
            var userClient = new TwitterClient(userCredentials);
            var user = await userClient.Users.GetAuthenticatedUserAsync();
            
            Console.WriteLine("Congratulation you have authenticated the user: " + user);
        }
    }
}