using System;
using System.Collections.Generic;
using System.Configuration;

namespace RoiCode.AsanaDotNet
{
    public class AsanaRepository
    {
        private static readonly string AsanaBaseUrl = @"https://app.asana.com/api/1.0/";

        public string AsanaPersonalAccessToken { get; }

        public AsanaRepository(string asanaPersonalAccessToken)
        {
            AsanaPersonalAccessToken = asanaPersonalAccessToken;
        }

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

        public List<AsanaProject> GetMyTasksForMyWorkspaceWithId(long workspaceId)
        {
            var client =
                new RoiRestClient(
                    AsanaBaseUrl, new
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);

            var result = client.GetMany<AsanaTask>($"tasks?workspace={workspaceId}&assignee=me", "data");

            var tasksByProject = GetTasksByProjectFrom(result.ReturnedObject);
            return tasksByProject;
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

        private static List<AsanaProject> GetTasksByProjectFrom(List<AsanaTask> returnedObject)
        {
            throw new NotImplementedException();
        }
    }
}
