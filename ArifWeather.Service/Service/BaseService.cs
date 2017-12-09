using System.Collections.Generic;
using ArifWeather.Model;
using RestSharp;
using RestSharp.Authenticators;

namespace ArifWeather.Service.Service
{
    /// example of the complete request url : "http://dataservice.accuweather.com/locations/v1/regions?apikey=SWyBGk7GA5PUugswQ3znssNrJYeh1WUw"
    public class BaseService
    {
        private const string DefaultAppKey = "SWyBGk7GA5PUugswQ3znssNrJYeh1WUw";
        
        protected const int Timeout = 60;

        protected const string DefaultLocationKey = "26797";

        protected User CurrentUser;

        protected string AppKey { get; set; }

        protected RestClient RestClient { get; set; }        


        public BaseService(User user, string apiUrl)
        {
            CurrentUser = user;
            AppKey = DefaultAppKey;
            RestClient = new RestClient(apiUrl);
        }

        public BaseService(string url, string appKey, User user)
        {
            CurrentUser = user;
            AppKey = appKey;
            RestClient = new RestClient(url);
        }

        public RestRequest BuildGetRequest(string requestName, Method method, List<Parameter> queryParameters = null)
        {
            //authenticate user
            RestClient.Authenticator = new SimpleAuthenticator("Username", CurrentUser.UserName, "Password", CurrentUser.Password);

            var restRequest = new RestRequest(requestName, method);
            restRequest.AddQueryParameter("apikey", AppKey);
            restRequest.RequestFormat = DataFormat.Json;

            if (queryParameters != null && queryParameters.Count > 0)
            {
                foreach(var queryParameter in queryParameters)
                {
                    restRequest.AddParameter(queryParameter);
                }
            }
            return restRequest;
        }
    }
}
