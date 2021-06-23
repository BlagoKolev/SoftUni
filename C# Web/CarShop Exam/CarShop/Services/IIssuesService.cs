using CarShop.Models.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        CarIssuesViewModel GetAllIssues(string carId);
        void AddIssue(AddIssueFormModel model,string carId);
        void DeleteIssue(string issueId);
        void FixIssue(string issueId);
    }
}
