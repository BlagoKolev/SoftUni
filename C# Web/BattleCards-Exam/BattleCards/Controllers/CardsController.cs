using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models.Cards;
using BattleCards.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly AppDbContext db;
        private readonly IValidator validator;
        private readonly ICardsService cardService;
        public CardsController(AppDbContext db, IValidator validator, ICardsService cardService)
        {
            this.db = db;
            this.validator = validator;
            this.cardService = cardService;
        }

        [Authorize]
        public HttpResponse All()
        {
            if (this.User.IsAuthenticated)
            {
                var cards = db.Cards
                    .Select(c => new AllCardsViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        Image = c.ImageUrl,
                        Attack = c.Attack,
                        Health = c.Health,
                        Keyword = c.Keyword
                    }).ToList();

                return this.View(cards);
            }
            return NotFound();
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCardsFormModel model)
        {

            var modelErrors = validator.ValidateCard(model);
            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            if (this.User.IsAuthenticated)
            {
                cardService.CreateCard(model, this.User.Id);
                return this.Redirect("/Cards/All");
            }
            return Unauthorized();
        }

        [Authorize]
        public HttpResponse Collection()
        {
            if (this.User.IsAuthenticated)
            {

                var cards = cardService.GetUsersCards(this.User.Id);
                return this.View(cards);
            }
            return Unauthorized();
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (this.User.IsAuthenticated)
            {
                cardService.RemoveFromCollection(cardId, this.User.Id);
                return this.Redirect("/Cards/Collection");
            }
            return Unauthorized();
        }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            if (this.User.IsAuthenticated)
            {
                int? cardIdCheck = cardService.AddToCollection(cardId, this.User.Id);
                if (cardIdCheck == null)
                {
                    return BadRequest();
                }
                return this.Redirect("/Cards/All");
            }
            return BadRequest();
        }
    }
}
