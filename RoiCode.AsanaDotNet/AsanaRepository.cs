using System.Collections.Generic;
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
                    var result = client.GetSingle<AsanaProject>($"/projects/{projectId}", "data");
                    allProjects.Add(projectId, result.ReturnedObject);
                });

            Parallel.ForEach(projectIds,
                projectId =>
                {
                    var result = client.GetMany<AsanaTask>($"/projects/{projectId}/tasks", "data");
                    allProjects[projectId].Tasks.AddRange(result.ReturnedObject);
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

        private static List<AsanaProject> GetTasksByProjectFrom(List<AsanaTask> returnedObject)
        {
            var allProjectsById = new Dictionary<long, AsanaProject>();
            AsanaProject currentAsanaProject;
            foreach (var asanaTask in returnedObject)
            {

                currentAsanaProject = asanaTask.Projects[0];
                if (currentAsanaProject == null)
                {
                    continue;
                }
                if (!allProjectsById.ContainsKey(currentAsanaProject.ID))
                {
                    allProjectsById.Add(currentAsanaProject.ID, currentAsanaProject);
                }
            }
            return allProjectsById.Values.ToList();
        }
    }
}
