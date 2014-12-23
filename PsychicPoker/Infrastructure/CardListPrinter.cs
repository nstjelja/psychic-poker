using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Infrastructure
{
    public class CardListPrinter
    {
        public void Print(List<Card> cards, Hand hand) {
           var filteredOut =  cards.Where(x => x.FaceValue != CardFaceValue.HighAce).ToList();

           var result = new StringBuilder();

           result.Append("Hand: ");

           filteredOut.Take(5).ToList().ForEach(x => result.AppendFormat(" {0} ", x.ShortHandName));

           result.Append(" Deck: ");

           filteredOut.Take(5).Skip(5).ToList().ForEach(x => result.AppendFormat(" {0} ", x.ShortHandName));

           result.Append(" Best hand: ");
           result.Append(hand.Name);

           var line = result.ToString();

           Console.WriteLine(line);
        }
    }
}
