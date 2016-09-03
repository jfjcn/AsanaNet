using System.Collections.Generic;
using System.Configuration;

namespace RoiCode.AsanaDotNet
{
    public class AsanaRepository
    {
        private static readonly string AsanaBaseUrl = @"https://app.asana.com/api/1.0/";
        private static readonly string AsanaPersonalAccessToken = ConfigurationManager.AppSettings["AsanaPersonalAccessToken"];

        public AsanaUser GetMe()
        {
            var client = 
                new RoiRestClient(
                    AsanaBaseUrl, new 
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);
            var result = client.GetSingle<AsanaUser>("users/me", "data");
            return result.ReturnedObject;
        }


        public List<AsanaWorkspace> GetWorkspaces()
        {
            throw new System.NotImplementedException();
        }
    }
}
