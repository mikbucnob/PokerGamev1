using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Player : IComparable<Player>
    {
        public string Name { get; set; }
        private List<Card> Cards { get; set; }
        int counter;
        public bool HasKnocked {get; set;}
        public Hand Hand
        {
            get
            {
                Cards.Sort();
                HandEvaluator playerHandEvaluator = new HandEvaluator(Cards.ToArray());
                return playerHandEvaluator.EvaluateHand();
                //TODO: evaluator needs to be a class member because it is used
                // by the compareTo method (total and highcard values)
            }
        }


        public Player(List<Card> hand)
        {
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

        

        public Move TakeTurn(List<Move> moves)
        {
            // for loop over moves to prcess what's available...
            // foreach (Move move in moves) {

            // }

            //////////// Dumb AI //////////////
            Random r = new Random();
            int choice = r.Next(moves.Count);
            ///////////////////////////////////
            // To be replaced with 
            // A) Smart AI which makes a good decision???
            // B) Actual player's input from GUI/Command line

            switch (moves[choice])
            {
                case Move.Knock:
                    break;
                case Move.Put:
                    break;
                case Move.SwapCard:
                    break;
                case Move.SwapHand:
                    break;
            }
            return moves[choice];
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
                if (this.Hand.Total > other.HandValues.Total)
                    Console.WriteLine("Player WINS!");
                else if (playerHandEvaluator.HandValues.Total < computerHandEvaluator.HandValues.Total)
                    Console.WriteLine("Computer WINS!");
                //if both hands have the same poker hand ( eg. both have a pair of queens ), 
                //then the player with the next higher card
                else if (playerHandEvaluator.HandValues.HighCard > computerHandEvaluator.HandValues.HighCard)
                    Console.WriteLine("Player WINS!");
                else if (playerHandEvaluator.HandValues.HighCard < computerHandEvaluator.HandValues.HighCard)
                    Console.WriteLine("Computer WINS!");
                else
                    Console.WriteLine("DRAW, no one wins!");
            }
        }
    }
}

