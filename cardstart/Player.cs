using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Player
    {
        public string name { get; set; }
        public int numPlayers { get; set; }
        List<Card> hand;
        int counter;
        
        public Player(List<Card> deckOfCards)
        {
        
        

        }



        public int GetNumberPlayers()
        {
            Console.Write("How many players?: ");
            numPlayers = Convert.ToInt32(Console.ReadLine());
            return numPlayers;
        }

        public string GetPlayerName()
        {
            Console.Write("What is the player's name? ");
            name = Console.ReadLine();
            return name;
        }

        public Move TakeTurn(params Move[] moves) {
            // for loop over moves to prcess what's available...
           // foreach (Move move in moves) {

           // }

            //////////// Dumb AI //////////////
            Random r = new Random();
            int choice = r.Next(moves.Length);
            ///////////////////////////////////
            // To be replaced with 
            // A) Smart AI which makes a good decision???
            // B) Actual player's input from GUI/Command line

            switch (moves[choice]) {
                case Move.Knock:
                    // No action required
                    break;
                case Move.Put:
                    // No action required
                    break;
                case Move.SwapCard:
                    // choose card to swap and card to swap with
                    break;
                case Move.SwapHand:
                    // No action required
                    break;
            }



        }

    }
}
