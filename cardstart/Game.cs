using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public enum Move { SwapHand, SwapCard, Knock, Put };

    class Game
    {
        private Deck deck;
        private int numPlayers;
        private Player currentPlayer;
        private List<Player> players;
        private int turnCounter;
        List<Card> hand;
        private bool gameover;
        public int numplayers;
        
        public void Start()
        {
            StartGame(2);
            do
            {
           
            // inside the loop - all players takes turn ()
            foreach(Player player in players)
                {
                    TakeTurn(player);
                }
         
            Console.ReadLine();
            }
            while (gameover != true);
         
        }

        public List<Card> ReplaceCard(List<Card> hand, List<Card> replacementCards)
        {
            return hand;
        }

        public int CalculateScore(List<Card> hand)
        {
            int score = 0;
            return score;
        }


        public void Deal()
        {
            //for (int i = 0; i < numPlayers; i++)
            //{
                for (int j = 0; j < 5; j++)
                {
                   // hand=
                }
            //}
        }

        public void StartGame(int numPlayers)
        {
            deck = new Deck();

            players=CreatePlayerList(numPlayers);
            //Deal(myDeck);
        }

        public void TakeTurn(Player player)
        {
            player.TakeTurn(Move.Knock, Move.Put);
            player.TakeTurn(Move.Knock, Move.Put, Move.SwapCard, Move.SwapHand);
            // go to next player in turn, tell them to move
            // in loop; turnCounter++
            // until out of players
            // declare winner
            // start new round
        }

        public List<Player> CreatePlayerList(int numberofplayers)
        {
            int counter = 0;
            List<Player> playerlist = new List<Player>();
            while ((numberofplayers > 0)&& (counter <= numberofplayers))
            {
                counter++;
                playerlist.Add(new Player(deck.Deal(5)));
            }
            return playerlist;            
        }
    }
}
