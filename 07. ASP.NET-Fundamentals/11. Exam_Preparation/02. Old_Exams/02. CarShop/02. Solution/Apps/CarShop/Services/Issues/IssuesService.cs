using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Issues;
using System;
using System.Linq;

namespace CarShop.Services.Issues
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateIssue(string carId, IssueInputModel model)
        {
            var issue = new Issue
            { 
                CarId = carId,
                Description = model.Description,
                IsFixed = false
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }
    }
}
