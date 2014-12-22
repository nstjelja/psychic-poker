using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class FlushRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Domain.Card> cards)
        {
            var cardList = new Dictionary<List<Card>,int>();
             m_Suits.ForEach(s => {
                var cardsInSuite = FindCardsOfSameSuit(cards, s).OrderByDescending( x => (int) x.FaceValue).Take(5).ToList();;

                if (cardsInSuite.Count != 5)
                    return;


               
                cardList.Add(cardsInSuite, this.CalculateSecondaryRating(cardsInSuite));



             });

            var item = cardList.OrderByDescending(x => x.Value).FirstOrDefault();

            if (item.Key == null)
                return null;


             var hand = new Hand();
                hand.Cards = item.Key;
                hand.Name = "Flush";
                hand.RankPrimary = 700;
                hand.RankSecondry = (int)item.Key.FirstOrDefault().FaceValue;


                return hand;
        }
    }
}
