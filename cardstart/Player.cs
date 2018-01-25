using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    abstract class Player : IComparable<Player>
    {
        public string Name { get; set; }
        private List<Card> Cards { get; set; }
        protected List<Card> cards { get { return Cards; } }
        int counter;
        public bool HasKnocked {get; set;}
        private HandEvaluator playerHandEvaluator;
        public Hand Hand
        {
            get
            {
                Cards.Sort();
                return playerHandEvaluator.EvaluateHand(Cards.ToArray());
                //TODO: evaluator needs to be a class member because it is used
                // by the compareTo method (total and highcard values)
            }
        }

        public HandEvaluator handEvaluator { get{ return playerHandEvaluator; }  }

        public Player(List<Card> hand, HandEvaluator he)
        {
            playerHandEvaluator = he;
            GetPlayerName();
            this.Cards = hand;
        }

        public List<Card> SwapHand(List<Card> swappingHand)
        {
            List<Card> temp = Cards;
            Cards = swappingHand;
            return temp;
        }

        public void SwapCard(List<Card> swapHand)
        {
            Card temp = swapHand[0];
            swapHand.RemoveAt(0);//take away from swapHand
            swapHand.Add(Cards[0]);//adding to swapHand the players card
            Cards.RemoveAt(0);//removing same card from player's hand
            Cards.Add(temp);//adding to the players hand the swap card
            // TODO: finish this
        }

        public string GetPlayerName()
        {
            Console.Write("What is the player's name? ");
            Name = Console.ReadLine();
            return Name;
        }

        public abstract int MakeChoice(List<Move> moves);
        

        public Move TakeTurn(List<Move> moves)
        {
            // display hand
            // Display list of available moves to player (console)
            // get user input...

            // for loop over moves to prcess what's available...
            // foreach (Move move in moves) {

            // }

            //////////// Dumb AI //////////////
            
            ///////////////////////////////////
            // To be replaced with 
            // A) Smart AI which makes a good decision???
            // B) Actual player's input from GUI/Command line
            return moves[MakeChoice(moves)];
        }

        public int CompareTo(Player other)
        {
            if (Hand < other.Hand)
            {
                return -1;
            }
            else if (Hand > other.Hand)
            {
                return 1;
            }
            else
            {
                //first evaluate who has higher value of poker hand
                if (this.playerHandEvaluator.Total > other.handEvaluator.Total)
                    return 1;
                else if (playerHandEvaluator.Total < other.handEvaluator.Total)
                    return -1;
                //if both hands have the same poker hand ( eg. both have a pair of queens ), 
                //then the player with the next higher card
                else if (playerHandEvaluator.HighCard > other.handEvaluator.HighCard)
                    return 1;
                else if (playerHandEvaluator.HighCard < other.handEvaluator.HighCard)
                    return -1;
                else
                    return 0;
            }
        }
    }
}

