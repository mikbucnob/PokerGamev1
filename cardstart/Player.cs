using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        int counter;
        public bool HasKnocked {get; set;}


        public Player(List<Card> hand)
        {
            this.Hand = hand;
        }

        public List<Card> SwapHand(List<Card> swappingHand)
        {
            List<Card> temp = Hand;
            Hand = swappingHand;
            return temp;
        }

        public void SwapCard(List<Card> swapHand)
        {
            Card temp = swapHand[0];//do comments later!
            swapHand.RemoveAt(0);//take away from swapHand
            swapHand.Add(Hand[0]);//adding to swapHand the players card
            Hand.RemoveAt(0);//removing same card from player's hand
            Hand.Add(temp);//adding to the players hand the swap card
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
            return moves[choice];
        }



    }

}

