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

                 var orderedCollection = OrderCardListBasedOnSuitValue(cardsInSuite);


                 var pages = Math.Ceiling((double)orderedCollection.Count / 5);

                 var sequences = new List<List<Card>>();
                 
                 for (var currentPage = 0; currentPage < pages; currentPage++){
                    var page = orderedCollection.Take(5).Skip(currentPage*5).ToList();
                    var areThey = AreCardsInSequence(page);

                    if (!areThey)
                        continue;

                    sequences.Add(page);
                 }

               

                 var lastSequence = sequences.LastOrDefault();

                 if (lastSequence == null)
                     return;
               
                 var value = (int)lastSequence.Sum(x => (decimal)x.FaceValue);

                 straightFlushes.Add(lastSequence, value);
             });

             var bestFlush = straightFlushes.OrderByDescending(x => x.Value).Select(x => x.Key).FirstOrDefault();

             if (bestFlush == null)
                 return null;

             var hand = new Hand();
             hand.Name = "Straight flush";
             hand.RankPrimary = 900;
             hand.RankSecondry = (int)bestFlush.Sum(x => (int)x.FaceValue);
             hand.Cards = bestFlush;

             return hand;
        }
    }
}
