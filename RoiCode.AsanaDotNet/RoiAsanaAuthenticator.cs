using RestSharp;
using RestSharp.Authenticators;

namespace RoiCode.AsanaDotNet
{
    internal class RoiAsanaAuthenticator : IAuthenticator
    {
        protected string PersonalAccessToken { get; set; }

        public RoiAsanaAuthenticator(string personalAccessToken)
        {
            PersonalAccessToken = personalAccessToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader("Authorization", "Bearer " + PersonalAccessToken);
        }
    }
}
