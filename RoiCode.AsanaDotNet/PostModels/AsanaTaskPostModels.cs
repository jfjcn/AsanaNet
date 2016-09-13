namespace RoiCode.AsanaDotNet
{
    internal class AsanaTaskPostModelForWorkspaces
    {
        public long assignee { get; set; }
        public string name { get; set; }
        public long workspace { get; set; }
    }

    internal class AsanaTaskPostModelForProjects
    {
        public long assignee { get; set; }
        public string name { get; set; }
        public string projects { get; set; }
    }
}
