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
        //testing github2
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

        public void TakeTurn(params Move[] moves) {
            // for loop over moves to prcess what's available...

        }

    }
}
