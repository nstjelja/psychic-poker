using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class StraightRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Domain.Card> cards)
        {
           var best =   BestOrderedCardList(cards);

           if (best == null)
               return null;

           if (best.Item1 == null)
               return null;

           if (best.Item1.Count == 0)
               return null;

           var hand = new Hand();
           hand.Name = "Straight";
           hand.Cards = best.Item1;
           hand.RankPrimary = 500;
           hand.RankSecondry = best.Item2;

           return hand;
            
        }
    }
}
