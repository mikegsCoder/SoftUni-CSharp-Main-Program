namespace Git.ViewModels.Commit
{
    public class CreateCommitInputModel
    {
        public string Description { get; set; }

        public string Id { get; set; }

        public string CreatorId { get; set; } = string.Empty;
    }
}
