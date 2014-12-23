using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Domain
{
    public class Card
    {
        #region Properties
        public CardFaceValue FaceValue { get; set; }
        public CardSuit Suit { get; set; }
        public string ShortHandName {
            get {
                var suitShortHand = Suit.ToString()[0].ToString();

                var faceIntValue = (int)FaceValue;

                if (faceIntValue >= 2 && faceIntValue <= 9) {
                    return String.Format("{0}{1}", faceIntValue, suitShortHand);
                }

                var faceShortHand = FaceValue.ToString()[0].ToString();

                return String.Format("{0}{1}", faceShortHand, suitShortHand);
            }
        }
        #endregion Properties

        #region Methods
        public static Card Create(string text)
        {
            if (String.IsNullOrEmpty(text))
                throw new ArgumentException("Card text must not be empty");

            if (text.Length != 2)
                throw new ArgumentException("Card length must be exactly two");

            var faceValue = CardFaceValueLexicon.Lexicon[text[0].ToString()];
            var cardSuit = CardSuitLexicon.Lexicon[text[1].ToString()];

            var card = new Card() { 
                FaceValue = faceValue,
                Suit = cardSuit
            };

            return card;
        }

        public override string ToString()
        {
            if (FaceValue == CardFaceValue.Empty || Suit == CardSuit.Empty)
                return "Empty";

            return String.Format("{0} of {1}", FaceValue, Suit);
        }
        #endregion Methods


    }
}
