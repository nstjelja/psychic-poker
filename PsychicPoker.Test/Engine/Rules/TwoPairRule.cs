using PsychicPoker.Domain;
using PsychicPoker.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Engine.Rules
{
    public class TwoPairRule : Rule
    {
        public override Domain.Hand BuildStrongestHand(List<Domain.Card> cards)
        {
            var pairs = new Dictionary<List<Card>, int>();

            m_Faces.ForEach(faceValue => {
                var pair = cards.Where(x => x.FaceValue == faceValue).ToList();

                if (pair.Count != 2)
                    return;

                pairs.Add(pair, pair.Sum(x => (int)x.FaceValue));
            });

            if (pairs.Count < 2)
                return null;

            var bestPairs = pairs.OrderByDescending(x => x.Value).Take(2).Select(x => x.Key).ToList();
            bestPairs[0].AddRange(bestPairs[1]);

            var faceOne = bestPairs[0][0].FaceValue;
            var faceTwo = bestPairs[1][0].FaceValue;

            var bestOtherCard = cards.Where(x => x.FaceValue != faceOne && x.FaceValue != faceTwo).OrderByDescending(x => (int)x.FaceValue).First();
            bestPairs[0].Add(bestOtherCard);

            var hand = new Hand();
            hand.Name = "Two pair";
            hand.Cards = bestPairs.First();
            hand.RankPrimary = 300;
            hand.RankSecondry = bestPairs.First().Sum(x => (int)x.FaceValue);

            return hand;

           
        }
    }
}
