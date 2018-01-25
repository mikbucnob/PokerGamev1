using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class ComputerPlayer : Player
    {
        public ComputerPlayer(List<Card> hand, HandEvaluator he) : base(hand, he)
        {
            // Don't have to do anything if we don't want to
            // setup AI strategy - maybe from different options
        }

        public override int MakeChoice(List<Move> moves)
        {
            //makes object and calculates random choice according to moves available
            return new Random().Next(moves.Count);
            
        }
    }
}
