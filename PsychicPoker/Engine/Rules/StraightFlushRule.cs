using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class StraightFlushRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Domain.Card> cards)
        {
             var straightFlushes = new Dictionary<List<Card>, int>();

             m_Suits.ForEach(s =>
             {
                 var cardsInSuite = FindCardsOfSameSuit(cards, s);

                 if (cardsInSuite.Count < 5)
                     return;

                 var result = this.BestOrderedCardList(cardsInSuite);

                 if (result == null)
                     return;


                 straightFlushes.Add(result.Item1, result.Item2);
             });

             var bestFlush = straightFlushes.OrderByDescending(x => x.Value).Select(x => x.Key).FirstOrDefault();

             if (bestFlush == null)
                 return null;

             var hand = new Hand();
             hand.Name = "Straight flush";
             hand.RankPrimary = 900;
             hand.RankSecondry = CalculateSecondaryRating(bestFlush);
             hand.Cards = bestFlush;

             return hand;
        }
    }
}
