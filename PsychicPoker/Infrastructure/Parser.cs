using CsvHelper;
using CsvHelper.Configuration;
using PsychicPoker.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Infrastructure
{
    public class Parser
    {

        public List<List<Card>> Parse(TextReader reader)
        {
            var csvReader = new CsvReader(reader, new CsvConfiguration() { 
                Delimiter=" ",
                IgnoreBlankLines = true,
                HasHeaderRecord = false,
                HasExcelSeparator = false,
                TrimFields = true
            });

            var result = new List<List<Card>>();

            while(csvReader.Read()){
                var cardSet = getCards(csvReader);
                result.Add(cardSet);
            }

            return result;
        }

        private List<Card> getCards(CsvReader csvReader) {
            var result = new List<Card>();

            for (var i = 0; i < 10; i++)
            {
                var text = csvReader.GetField(i);
                var card = Card.Create(text);

                result.Add(card);

                if (card.FaceValue == CardFaceValue.Ace) {
                    var highAce = new Card() { 
                        Suit = card.Suit,
                        FaceValue = CardFaceValue.HighAce
                    };

                    result.Add(highAce);
                }
            }

            return result;
        }
    }
}
