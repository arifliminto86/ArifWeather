using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;

using ArifWeather.Model;
namespace ArifWeather.Service
{
    /// example of the complete request url : "http://dataservice.accuweather.com/locations/v1/regions?apikey=SWyBGk7GA5PUugswQ3znssNrJYeh1WUw"
    public class BaseService
    {
        private const string DEFAULT_APP_KEY = "SWyBGk7GA5PUugswQ3znssNrJYeh1WUw";
        
        private const string DEFAULT_URL = @"http://dataservice.accuweather.com";
    
        protected const int Timeout = 60;

        protected const string Default_Location_Key = "26797";

        protected User _currentUser;

        protected string _AppKey { get; set; }

        protected RestClient _restClient { get; set; }        


        public BaseService(User user)
        {
            _currentUser = user;
            _AppKey = DEFAULT_APP_KEY;
            _restClient = new RestClient(DEFAULT_URL);
        }

        public BaseService(string url, string appKey, User user)
        {
            _currentUser = user;
            _AppKey = appKey;
            _restClient = new RestClient(url);
        }

        public RestRequest BuildGetRequest(string requestName, Method method, List<Parameter> queryParameters = null)
        {
            //authenticate user
            _restClient.Authenticator = new SimpleAuthenticator("Username", _currentUser.UserName, "Password", _currentUser.Password);

            var restRequest = new RestRequest(requestName, method);
            restRequest.AddQueryParameter("apikey", _AppKey);
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
