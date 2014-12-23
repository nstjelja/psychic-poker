using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class ThreeOfAKindRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Domain.Card> cards)
        {
            var threeOfKind = BestCardsSameFaceAndScore(cards, 3);

            if (threeOfKind == null)
                return null;

            var face = threeOfKind.Item1.FirstOrDefault().FaceValue;

            var otherTwo = cards.Where(x => x.FaceValue == face).OrderByDescending(x => (int)x.FaceValue).Take(2).ToList();

            threeOfKind.Item1.AddRange(otherTwo);

            var hand = new Hand();
            hand.Cards = threeOfKind.Item1;
            hand.Name = "Three of a kind";
            hand.RankPrimary = 400;
            hand.RankSecondry = this.CalculateSecondaryRating(threeOfKind.Item1);

            return hand;
        }
    }
}
