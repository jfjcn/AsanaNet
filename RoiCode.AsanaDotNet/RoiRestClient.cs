using System.Collections.Generic;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

namespace RoiCode.AsanaDotNet
{
    internal class RoiRestClient
    {
        protected RestClient InternalRestClient { get; }

        public RoiRestClient(string baseUrl) : this(baseUrl, null)
        {
        }

        public RoiRestClient(string baseUrl, IAuthenticator authenticator) :
            this(baseUrl, authenticator, false)
        {

        }

        public RoiRestClient(string baseUrl, IAuthenticator authenticator, bool useAdditionalTlsOrSslSecurity)
        {
            InternalRestClient = new RestClient(baseUrl);

            if (authenticator != null)
            {
                InternalRestClient.Authenticator = authenticator;
            }
            if (useAdditionalTlsOrSslSecurity)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 |
                                                   (SecurityProtocolType)768 |
                                                   (SecurityProtocolType)3072;
            }
        }

        public RoiRestClientResponse<TReturnedEntity> GetSingle<TReturnedEntity>(
            string resourceRelativePath) where TReturnedEntity : new()
        {
            return GetSingle<TReturnedEntity>(resourceRelativePath, null);
        }

        public RoiRestClientResponse<TReturnedEntity> GetSingle<TReturnedEntity>(
            string resourceRelativePath, string rootElementName) where TReturnedEntity : new()
        {
            var request = GetBasicRequest(
                resourceRelativePath, 
                Method.GET, 
                DataFormat.Json);
            
            if (!string.IsNullOrEmpty(rootElementName))
            {
                request.RootElement = rootElementName;
            }
            var response = InternalRestClient.Execute<TReturnedEntity>(request);

            var restClientResponse = new RoiRestClientResponse<TReturnedEntity>();

            if (response.ResponseStatus == ResponseStatus.Error) //TODO: what about other status enums?
            {
                restClientResponse.Success = false;
                restClientResponse.ErrorMessage = response.ErrorMessage;
                restClientResponse.Content = response.Content;
            }
            else
            {
                restClientResponse.Success = true;
                restClientResponse.ReturnedObject = response.Data;
//                foreach (var parameter in response.Headers)
//                {
                    //look through the headers for ResourceUri - location to the newly created object
                    //                    restClientResponse.ResourceUri = null;
                    //                    var absoluteUri = response.Headers.Location.AbsoluteUri;
                    //                    var lastForwardSlashLocation = absoluteUri.LastIndexOf("/");
                    //                    var parsedId =
                    //                        absoluteUri.Substring(
                    //                            lastForwardSlashLocation + 1,
                    //                            absoluteUri.Length - lastForwardSlashLocation - 1);
                    //                    restClientResponse.ResourceParsedId = parsedId;
//                }

            }
            restClientResponse.HttpStatusCode = (int)response.StatusCode;
            return restClientResponse;
        }

        public RoiRestClientResponse<List<TReturnedEntity>> GetMany<TReturnedEntity>(
            string resourceRelativePath, string rootElementName) where TReturnedEntity : new()
        {
            var request = GetBasicRequest(
                resourceRelativePath,
                Method.GET,
                DataFormat.Json);

            if (!string.IsNullOrEmpty(rootElementName))
            {
                request.RootElement = rootElementName;
            }
            var response = InternalRestClient.Execute<List<TReturnedEntity>>(request);

            var restClientResponse = new RoiRestClientResponse<List<TReturnedEntity>>();

            if (response.ResponseStatus == ResponseStatus.Error) //TODO: what about other status enums?
            {
                restClientResponse.Success = false;
                restClientResponse.ErrorMessage = response.ErrorMessage;
                restClientResponse.Content = response.Content;
            }
            else
            {
                restClientResponse.Success = true;
                restClientResponse.ReturnedObject = response.Data;
            }
            restClientResponse.HttpStatusCode = (int) response.StatusCode;
            return restClientResponse;
        }

        public RoiRestClientResponse<TReturnedEntity> Post<TReturnedEntity>(
            string resourceRelativePath, object resourceToCreate, string rootElement) where TReturnedEntity : class, new()
        {
            var request = GetBasicRequest(
                resourceRelativePath,
                Method.POST,
                DataFormat.Json);

            request.AddBody(resourceToCreate);

            if (!string.IsNullOrEmpty(rootElement))
            {
                request.RootElement = rootElement;
            }
            var response = InternalRestClient.Execute<TReturnedEntity>(request);

            var restClientResponse = new RoiRestClientResponse<TReturnedEntity>();

            if (response.ResponseStatus == ResponseStatus.Error) //TODO: what about other status enums?
            {
                restClientResponse.Success = false;
                restClientResponse.ErrorMessage = response.ErrorMessage;
                restClientResponse.Content = response.Content;
            }
            else
            {
                restClientResponse.ReturnedObject = response.Data;
                restClientResponse.Success = true;
                restClientResponse.ReturnedObject = response.Data;
            }

            restClientResponse.HttpStatusCode = (int)response.StatusCode;
            return restClientResponse;
        }

        private static RestRequest GetBasicRequest(string resourceRelativePath, Method httpMethod, DataFormat dataFormat)
        {
            var request = new RestRequest(httpMethod);
            request.Resource = resourceRelativePath;
            request.RequestFormat = dataFormat;
            return request;
        }

    }
}
