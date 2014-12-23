using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class OnePairRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Domain.Card> cards)
        {
            var pairs = new Dictionary<List<Card>, int>();

            m_Faces.ForEach(faceValue =>
            {
                var pair = cards.Where(x => x.FaceValue == faceValue).ToList();

                if (pair.Count != 2)
                    return;

                pairs.Add(pair, pair.Sum(x => (int)x.FaceValue));
            });

            if (pairs.Count== 0)
                return null;

            var bestPairs = pairs.OrderByDescending(x => x.Value).Take(1).Select(x => x.Key).ToList();
          
            var faceOne = bestPairs[0][0].FaceValue;

            var bestOtherCard = cards.Where(x => x.FaceValue != faceOne).OrderByDescending(x => (int)x.FaceValue).Take(3).ToList();
            bestPairs[0].AddRange(bestOtherCard);

            var hand = new Hand();
            hand.Name = "One pair";
            hand.Cards = bestPairs.First();
            hand.RankPrimary = 200;
            hand.RankSecondry = bestPairs.First().Sum(x => (int)x.FaceValue);

            return hand;
        }
    }
}
