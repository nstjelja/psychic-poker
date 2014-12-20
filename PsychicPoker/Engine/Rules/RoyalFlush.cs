using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class RoyalFlush : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Card> cards)
        {
            var royalFlushes = new List<List<Card>>();

            m_Suits.ForEach(s => {
                var cardsInSuite = FindCardsOfSameSuit(cards, s);

                if (cardsInSuite.Count < 5)
                    return;

                var royalFlush = cardsInSuite.Where(x => x.FaceValue == CardFaceValue.Ten || x.FaceValue == CardFaceValue.Jack || x.FaceValue == CardFaceValue.Queen || x.FaceValue == CardFaceValue.King || x.FaceValue == CardFaceValue.Ace).ToList();

                if (royalFlush.Count != 5)
                    return;

                royalFlushes.Add(royalFlush);

            });

            var handCardList = royalFlushes.FirstOrDefault();

            if (handCardList == null)
                return null;

            var hand = new Hand();
            hand.Cards = handCardList;
            hand.Name = "Royal Flush";
            hand.RankPrimary = 500;
            hand.RankSecondry = 0;

            return hand;
        }

       
    }
}
