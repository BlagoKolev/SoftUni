using CarShop.Models.Issues;
using CarShop.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IUserService userService;
        public IssuesController(IIssuesService issuesService, IUserService userService)
        {
            this.userService = userService;
            this.issuesService = issuesService;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            var car = issuesService.GetAllIssues(carId);
            return this.View(car);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model, string carId)
        {
            issuesService.AddIssue(model, carId);
            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string CarId, string issueId)
        {
            issuesService.DeleteIssue(issueId);
            return this.Redirect($"/Issues/CarIssues?carId={CarId}");
        }

        [Authorize]
        public HttpResponse Fix(string CarId, string issueId)
        {
            if (!userService.IsMechanic(this.User.Id))
            {
                return Unauthorized();
            }
            issuesService.FixIssue(issueId);
            return this.Redirect($"/Issues/CarIssues?carId={CarId}");
        }
    }
}
