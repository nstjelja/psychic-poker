using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class FourOfAKindRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Card> cards)
        {

            var best = BestCardsSameFaceAndScore(cards, 4);

            if (best == null)
                return null;

            var face = best.Item1.FirstOrDefault().FaceValue;

           var bestOtherCard = cards.Where(x => x.FaceValue != face).OrderByDescending(x => (int)x.FaceValue).FirstOrDefault();

            best.Item1.Add(bestOtherCard);

            var hand = new Hand();
            hand.Name = "Four of kind";
            hand.RankPrimary = 800;
            hand.RankSecondry = (int)bestOtherCard.FaceValue;
            hand.Cards = best.Item1;

            return hand;
        }
    }
}
