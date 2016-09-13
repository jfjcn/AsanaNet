﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public List<AsanaTask> GetMyTasksForMyWorkspaceWithId(long workspaceId)
        {
            var client =
                new RoiRestClient(
                    AsanaBaseUrl, new
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);

            var result = client.GetMany<AsanaTask>($"tasks?workspace={workspaceId}&assignee=me", "data");

            return result.ReturnedObject;
        }

        public List<AsanaProject> GetMyTasksForProjectsWithId(IEnumerable<long> projectIds)
        {
            var client =
                new RoiRestClient(
                    AsanaBaseUrl, new
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);

            Dictionary<long, AsanaProject> allProjects = new Dictionary<long, AsanaProject>();

            Parallel.ForEach(projectIds,
                projectId =>
                {
                    var projectFromApi = client.GetSingle<AsanaProject>($"/projects/{projectId}", "data");
                    allProjects.Add(projectId, projectFromApi.ReturnedObject);

                    var tasksForProject = client.GetMany<AsanaTask>($"/projects/{projectId}/tasks", "data");
                    allProjects[projectId].Tasks.AddRange(tasksForProject.ReturnedObject);
                });

            return allProjects.Values.ToList();
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

        public AsanaTask CreateAsanaTask(string taskName, AsanaUser userToWhichToAssignTask, AsanaWorkspace workspaceToWichToAddTask)
        {
            var client =
                new RoiRestClient(
                    AsanaBaseUrl, new
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);

            var dataToPost = new RestDataContainerForPost()
            {
                data = new AsanaTaskPostModel()
                {
                    assignee = userToWhichToAssignTask.ID,
                    name = taskName,
                    workspace = workspaceToWichToAddTask.ID
                }
            };

            var result = client.Post<AsanaTask>($"tasks", dataToPost, "data");
            return result.ReturnedObject;
        }

        public AsanaTask CreateAsanaTask(string taskName, AsanaUser userToWhichToAssignTask,
            AsanaProject projectToWhichToAddTask)
        {
            var client =
                new RoiRestClient(
                    AsanaBaseUrl, new
                    RoiAsanaAuthenticator(AsanaPersonalAccessToken),
                    true);

            var dataToPost = new RestDataContainerForPost()
            {
                data = new AsanaTaskPostModel()
                {
                    assignee = userToWhichToAssignTask.ID,
                    name = taskName,
                    projects = projectToWhichToAddTask.ID.ToString()
                }
            };

            var result = client.Post<AsanaTask>($"tasks", dataToPost, "data");
            return result.ReturnedObject;
        }
    }
}
