using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicPoker.Domain
{
    public class Hand
    {
        #region Properties
        public List<Card> Cards { get; set; }
        public string Name { get; set; }
        public int RankPrimary { get; set; }
        public int RankSecondry { get; set; }
        #endregion Properties
    }
}
