using System;
using System.Collections.Generic;
using System.Configuration;

namespace RoiCode.AsanaDotNet
{
    public class AsanaRepository
    {
        private static readonly string AsanaBaseUrl = @"https://app.asana.com/api/1.0/";
        private static readonly string AsanaPersonalAccessToken = ConfigurationManager.AppSettings["AsanaPersonalAccessToken"];
        private static readonly long MyBulletJournalWorkspaceId = 123134;

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
            var client =
                new RoiRestClient(
                    AsanaBaseUrl, new
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);

            var result = client.GetMany<AsanaWorkspace>($"tasks?workspace={MyBulletJournalWorkspaceId}&assignee=me", "data");

            return result.ReturnedObject;
        }

        public List<AsanaWorkspace> GetMyWorkspaces()
        {
            var client =
                new RoiRestClient(
                    AsanaBaseUrl, new
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);
            var result = client.GetMany<AsanaWorkspace>("workspaces", "data");

            return result.ReturnedObject;
        }

        public AsanaWorkspace GetWorkspace(long workspaceId)
        {
            var client =
                new RoiRestClient(
                    AsanaBaseUrl, new
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);
            var result = client.GetSingle<AsanaWorkspace>($"workspaces/{workspaceId}", "data");
            return result.ReturnedObject;
        }
    }
}
