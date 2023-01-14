using CarShop.ViewModels.Issues;

namespace CarShop.Services.Issues
{
    public interface IIssuesService
    {
        void CreateIssue(string carId, IssueInputModel model);

        AllIssuesViewModel GetAllIssues(string carId, string userId);

        void DeleteIssue(string issueId);

        void FixIssue(string issueId);
    }
}
