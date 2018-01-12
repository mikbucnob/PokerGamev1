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
        private int numPlayers = 2;//dont want to do less than 2
        private Player currentPlayer;
        private List<Player> players;
        private int turnCounter;
        List<Card> tableHand;
        private bool gameover;
        private bool handswap = true;


        public void Start()
        {
            deck = new Deck();
            deck.Shuffle();

            players = CreatePlayerList(numPlayers);
            do
            {
                // inside the loop - all players takes turn ()
                foreach (Player player in players)
                {
                    if (player.HasKnocked)
                    {
                        gameover = true;
                        break;
                    }
                    
                        switch (player.TakeTurn(CalculateMoves(player)))
                        {
                            case Move.Knock:
                                //can knock first go if first player wants to keep hand
                                //if player has to put, can't knock otherwise all turns can knock
                                //if first player knock keep handswap true
                                handswap = true;//hand not swapped at first round
                                player.HasKnocked = true;
                                break;
                            case Move.Put:
                                //game over if put
                                gameover = true;
                                break;
                            case Move.SwapCard:
                                player.SwapCard(tableHand);
                            //TODO choose what card to swap
                                break;
                            case Move.SwapHand:                                
                                handswap = false;
                                tableHand = player.SwapHand(tableHand);
                                break;
                        }
                        break;
                }
                
            }
            while (gameover != true);
            players.Sort();
            
            // TODO: end of game - compare hands to determine winner
            // evaluate *ALL* player's (sorted) hands - for each player, create evaluator
            // and put into collection
            // sort the evaluated hands
        }

        public List<Card> ReplaceCard(List<Card> hand, List<Card> replacementCards)
        {
            //TODO:
            return hand;
        }

        public int CalculateScore(List<Card> hand)
        {
            int score = 0;
            return score;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">The player whose turn it is</param>
        /// <returns>Return true if the game should be over</returns>
        public List<Move> CalculateMoves(Player player)
        {
            List<Move> moves = new List<Move>();
            Hand hand = player.Hand;
            if (hand.Equals(Hand.Flush) || hand.Equals(Hand.FullHouse) || hand.Equals(Hand.FourKind)
                || hand.Equals(Hand.StraightFlush))
            {
                moves.Add(Move.Put);
            }
            else
            {
                moves.Add(Move.Knock);
            }
            if (handswap)
            {
                moves.Add(Move.SwapHand);
            }
            else 
            {
                moves.Add(Move.SwapCard);
            }
            return moves;
        }

        public List<Player> CreatePlayerList(int numberofplayers)
        {
            int counter = 0;
            List<Player> playerlist = new List<Player>();
            tableHand = deck.Deal(5);
            while ((numberofplayers > 0) && (counter < numberofplayers))
            {
                counter++;
                playerlist.Add(new Player(deck.Deal(5)));
            }
            return playerlist;
        }
    }
}
