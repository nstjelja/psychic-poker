using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine
{
    public abstract class Rule
    {
        #region Memebers
        protected List<CardSuit> m_Suits = new List<CardSuit>() { 
                CardSuit.Clubs, CardSuit.Diamonds, CardSuit.Hearts, CardSuit.Spades
            };

        protected List<CardFaceValue> m_Faces = new List<CardFaceValue>() { 
            CardFaceValue.Ace,
            CardFaceValue.Two,
            CardFaceValue.Three,
            CardFaceValue.Four,
            CardFaceValue.Five,
            CardFaceValue.Six,
            CardFaceValue.Seven,
            CardFaceValue.Eight,
            CardFaceValue.Nine,
            CardFaceValue.Ten,
            CardFaceValue.Jack,
            CardFaceValue.Queen,
            CardFaceValue.King,
            CardFaceValue.HighAce
            
        };
        #endregion Members

        #region Abstract
        public abstract Hand BuildStrongestHand(List<Card> cards);
        #endregion Abstract

        #region Methods
        protected List<Card> FindCardsOfSameSuit(List<Card> cards, CardSuit suit)
        {
            var cardsInSuit = cards.Where(x => x.Suit == suit).ToList();
            return cardsInSuit;
        }

        protected Tuple<List<Card>,int> BestOrderedCardList(List<Card> cards) {
            var orderedCollection = OrderCardListBasedOnSuitValue(cards);


            var pages = Math.Ceiling((double)orderedCollection.Count / 5);

            var sequences = new List<List<Card>>();

            for (var currentPage = 0; currentPage < pages; currentPage++)
            {
                var page = orderedCollection.Take(5).Skip(currentPage * 5).ToList();
                var areThey = AreCardsInSequence(page);

                if (!areThey)
                    continue;

                sequences.Add(page);
            }



            var lastSequence = sequences.LastOrDefault();

            if (lastSequence == null)
                return null;

            var value = (int)lastSequence.Sum(x => (decimal)x.FaceValue);

            return new Tuple<List<Card>,int>(lastSequence, value);
        }

        protected List<Card> OrderCardListBasedOnSuitValue(List<Card> cards)
        {
            var ordering = cards.OrderBy(card => (int)card.FaceValue).ToList();

            return ordering;
        
        }

        protected bool AreCardsInSequence(List<Card> cards) {
            bool areThey = true;

            for (var i = 0; i < cards.Count; i++) {
                if (areThey == false)
                    break;

                if (i == 0)
                    continue;

                var current = (int) cards[i].FaceValue;

                var previous = (int)cards[i-1].FaceValue;

                if ((current - previous) == 1)
                    continue;

                areThey = false;
                break;
               
            }

            return areThey;
        
        }

        protected int CalculateSecondaryRating(List<Card> cards) {
           return (int)cards.Sum(x => (int)x.FaceValue);
        
        }

        protected Tuple<List<Card>, int> BestCardsSameFaceAndScore(List<Card> cards, int number) {
            var result = new Dictionary<List<Card>,int>();
            m_Faces.ForEach(faceValue =>
            {
                var sameFaceValue = cards.Where(x => x.FaceValue == faceValue).ToList();

                if (sameFaceValue.Count != number)
                    return;

                result.Add(sameFaceValue, CalculateSecondaryRating(sameFaceValue));

            });

            var best = result.OrderByDescending(x => x.Value).FirstOrDefault();

            if (best.Key == null)
                return null;

            return new Tuple<List<Card>, int>(best.Key, best.Value);
        }
        #endregion Methods
    }
}
