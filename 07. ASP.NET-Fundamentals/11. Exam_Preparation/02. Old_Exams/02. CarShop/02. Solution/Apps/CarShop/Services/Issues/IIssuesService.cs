using CarShop.ViewModels.Issues;

namespace CarShop.Services.Issues
{
    public interface IIssuesService
    {
        void CreateIssue(string carId, IssueInputModel model);
    }
}
