using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class HumanPlayer : Player
    {
        public HumanPlayer(List<Card> hand, HandEvaluator he) : base(hand, he)
        {
        }

        public override int MakeChoice(List<Move> moves)
        {
            int counter = 0;
            Console.WriteLine("My cards:-");
            foreach (Card card in cards)
            {  
                Console.WriteLine(card);
            }
            foreach (Move move in moves)
            {
                Console.WriteLine(counter + ": " + move);
                counter++;
            }
            Console.WriteLine("What is your choice?");
            return(Int32.Parse(Console.ReadLine()));
            // display moves
            // get user choice
            
        }
    }
}
