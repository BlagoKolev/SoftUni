using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly CarShopDbContext db;
        public IssuesService(CarShopDbContext db)
        {
            this.db = db;
        }

        public void AddIssue(AddIssueFormModel model, string carId)
        {
            var issue = new Issue
            {
                CarId = carId,
                Description = model.Description,
            };

            db.Issues.Add(issue);
            db.SaveChanges();
        }

        public void DeleteIssue(string issueId)
        {
            var issue = db.Issues
                .Where(i => i.Id == issueId)
                .FirstOrDefault();

            db.Issues.Remove(issue);
            db.SaveChanges();
        }

        public void FixIssue(string issueId)
        {
            var issue = db.Issues
                .Where(i => i.Id == issueId)
                .FirstOrDefault();
            issue.IsFixed = true;
            db.SaveChanges();
        }

        public CarIssuesViewModel GetAllIssues(string carId)
        {
            var car = this.db.Cars
                 .Where(c => c.Id == carId)
                 .Select(c => new CarIssuesViewModel
                 {
                     Id = c.Id,
                     Model = c.Model,
                     Year = c.Year,
                     Issues = c.Issues.Select(i => new IssuesViewModel
                     {
                         Id = i.Id,
                         Description = i.Description,
                         IsItFixed = i.IsFixed == true,
                     }).ToList()
                 })
                 .FirstOrDefault();

            return car;
        }
    }
}
