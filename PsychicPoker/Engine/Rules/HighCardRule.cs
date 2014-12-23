using PsychicPoker.Domain;
using PsychicPoker.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Test.Engine.Rules
{
    public class HighCardRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Card> cards)
        {
            var orderedList = this.OrderCardListBasedOnSuitValue(cards);
            orderedList.Reverse();


            var hand = new Hand();
            hand.Cards = orderedList.Take(5).ToList();
            hand.Name = "High card";
            hand.RankPrimary = 100;
            hand.RankSecondry = hand.Cards.Sum(x => (int)x.FaceValue);

            return hand;
        }
    }
}
