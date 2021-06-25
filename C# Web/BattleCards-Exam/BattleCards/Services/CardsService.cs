using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly AppDbContext db;
        public CardsService(AppDbContext db)
        {
            this.db = db;
        }

        public object User { get; private set; }

        public int AddToCollection(int cardId, string userId)
        {
            var result = string.Empty;

            var card = this.db.Cards
                    .Where(x => x.Id == cardId)
                    .FirstOrDefault();

            if (card != null)
            {

                bool isUserOwnsCard = this.db.UserCards.Any(x => x.CardId == cardId && x.UserId == userId);

                if (!isUserOwnsCard)
                {
                    {
                        this.db.UserCards.Add(new UserCard
                        {
                            UserId = userId,
                            Card = card,
                        });

                        db.SaveChanges();

                    }
                }
            } 
            return card.Id;
        }

            public void CreateCard(AddCardsFormModel model, string userId)
            {
                var newCard = new Card
                {
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = model.Image,
                    Attack = model.Attack,
                    Health = model.Health,
                    Keyword = model.Keyword
                };

                this.db.Cards.Add(newCard);

                this.db.UserCards.Add(new UserCard
                {
                    UserId = userId,
                    Card = newCard
                });

                db.SaveChanges();
            }

            public ICollection<MyCollectionViewModel> GetUsersCards(string userId)
            {
                var cards = db.UserCards
                    .Where(u => u.UserId == userId)
                    .Select(u => new MyCollectionViewModel
                    {
                        CardId = u.Card.Id,
                        Name = u.Card.Name,
                        Description = u.Card.Description,
                        Attack = u.Card.Attack,
                        Health = u.Card.Health,
                        Image = u.Card.ImageUrl,
                        Keyword = u.Card.Keyword,
                    }).ToList();
                return cards;
            }

            public void RemoveFromCollection(int cardId, string userId)
            {
                var card = db.UserCards
                    .Where(uc => uc.UserId == userId && uc.CardId == cardId)
                    .FirstOrDefault();
                db.UserCards.Remove(card);
                db.SaveChanges();
            }
        }
    }
