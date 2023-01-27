namespace Git.ViewModels.Commit
{
    public class CommitViewModel
    {
        public string Id { get; set; }

        public string RepositoryName { get; set; } = "";

        public string Description { get; set; }

        public string CreatedOn { get; set; }
    }
}
