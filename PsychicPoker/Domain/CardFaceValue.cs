using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Domain
{
    public class CardFaceValueLexicon {
        public static readonly Dictionary<string, CardFaceValue> Lexicon = new Dictionary<string, CardFaceValue>(){            
        {"A",CardFaceValue.Ace},
        {"T", CardFaceValue.Ten},
        {"J", CardFaceValue.Jack},
        {"Q", CardFaceValue.Queen},
        {"K", CardFaceValue.King},
        {"2",CardFaceValue.Two},
        {"3",CardFaceValue.Three},
        {"4",CardFaceValue.Four},
        {"5",CardFaceValue.Five},
        {"6",CardFaceValue.Six},
        {"7",CardFaceValue.Seven},
        {"8",CardFaceValue.Eight},
        {"9", CardFaceValue.Nine}
        };

    }

    public enum CardFaceValue
    {
        Empty,
        Ace, 
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten, 
        Jack,
        Queen, 
        King,
        
    }
}
