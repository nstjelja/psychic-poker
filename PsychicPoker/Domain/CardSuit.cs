using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Domain
{
    public class CardSuitLexicon
    {
        public readonly static Dictionary<string, CardSuit> Lexicon = new Dictionary<string, CardSuit>(){                     {"C", CardSuit.Clubs},
                      {"D", CardSuit.Diamonds},
                      {"H", CardSuit.Hearts},
                      {"S", CardSuit.Spades},
       
        };

    }
    public enum CardSuit
    {
        Empty,
        Clubs, 
        Diamonds, 
        Hearts, 
        Spades
    }
}
