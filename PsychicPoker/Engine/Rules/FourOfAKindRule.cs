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

            var fourOfKinds = new Dictionary<List<Card>,int>();

            m_Faces.ForEach(faceValue => {
                var sameFaceValue = cards.Where(x => x.FaceValue == faceValue).ToList();

                if (sameFaceValue.Count != 4)
                    return;

                fourOfKinds.Add(sameFaceValue, CalculateSecondaryRating(sameFaceValue));
                
            });

            var best = fourOfKinds.OrderByDescending(x => x.Value).Select(x => x.Key).FirstOrDefault();

            if (best == null)
                return null;

            var face = best.FirstOrDefault().FaceValue;

           var bestOtherCard = cards.Where(x => x.FaceValue != face).OrderByDescending(x => (int)x.FaceValue).FirstOrDefault();

           best.Add(bestOtherCard);

            var hand = new Hand();
            hand.Name = "Four of kind";
            hand.RankPrimary = 800;
            hand.RankSecondry = (int)bestOtherCard.FaceValue;
            hand.Cards = best;

            return hand;
        }
    }
}
