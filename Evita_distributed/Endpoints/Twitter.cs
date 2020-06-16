using System;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography;
using RestSharp;
using RestSharp.Authenticators;
using System.Web;

namespace Evita_distributed.Endpoints
{
    public class Twitter
    {
        private string TwitterApiUrl { get; set; }
        private RestClient Client { get; set; }

        public Twitter()
        {
            TwitterApiUrl = "https://api.twitter.com";
            Client = new RestClient(TwitterApiUrl);
        }


        public string GetAccessToken(string key, string secret, string oauth_token, string oauth_token_secret, string oauth_verifier)
        {

            var request = new RestRequest("/oauth/access_token", Method.POST);

            //oauth_token_secret is unknown at this state of the application. Passing an empty string
            Client.Authenticator = OAuth1Authenticator.ForAccessToken(key, secret, oauth_token, oauth_token_secret, oauth_verifier);

            var response = Client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var qs = HttpUtility.ParseQueryString(response.Content);
                //we have token

                //TODO Save User Details in database
                string oauthToken = qs["oauth_token"];
                string oauthTokenSecret = qs["oauth_token_secret"];
                string userId = qs["user_id"];
                string screenName = qs["screen_name"];
                string xAuthExpires = qs["x_auth_expires"];

                return screenName;
            }
            else
            {
                //fail to get token
                return "Error";
            }
        }
    }
}