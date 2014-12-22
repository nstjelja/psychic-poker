using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class FullHouseRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Domain.Card> cards)
        {
            var threeOfKind = BestCardsSameFaceAndScore(cards, 3);
            var twoOfKind = BestCardsSameFaceAndScore(cards, 2);

            if (threeOfKind == null || twoOfKind == null)
                return null;

            threeOfKind.Item1.AddRange(twoOfKind.Item1);

            var hand = new Hand();
            hand.Name = "Full House";
            hand.RankPrimary = 700;
            hand.RankSecondry = threeOfKind.Item2 + twoOfKind.Item2;
            hand.Cards =  threeOfKind.Item1;


            return hand;

            
        }
    }
}
