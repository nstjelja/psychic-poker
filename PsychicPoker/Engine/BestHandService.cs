using PsychicPoker.Domain;
using PsychicPoker.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine
{
    public class BestHandService
    {
        #region Members
        private List<Rule> m_Rules = new List<Rule>() {
            new FlushRule(),
            new FourOfAKindRule(),
            new FullHouseRule(),
            new HighCardRule(),
            new OnePairRule(),
            new RoyalFlushRule(),
            new StraightFlushRule(),
            new StraightRule(),
            new ThreeOfAKindRule(),
            new TwoPairRule(),
        };
        #endregion Members

        #region Methods
        public Hand GetBestHand(List<Card> cards) {
            Hand bestHand = null;

            m_Rules.ForEach(x => {
               var tempHand = x.BuildStrongestHand(cards);

               if (tempHand == null)
                   return;

               if (bestHand == null) {
                   bestHand = tempHand;
                   return;
               }


               if (bestHand.TotalRank >= tempHand.TotalRank)
                   return;

               bestHand = tempHand;

            });

            return bestHand;
        }
        #endregion Methods
    }
}
