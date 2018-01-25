using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Card : IComparable<Card>
    {
    public enum Face { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
    public enum Suit { Spades = 1, Clubs, Diamonds, Hearts };

        /*private String [] faceTypes = { "Aces", "Ones", "Two" };
       private String[] suitTypes = { "Hearts", "Spades", "Clubs", "Diamonds" };*/
        //can use strings as well

        // CONSTANTS
        // ENUM suit, ENUM face (ordinal = index) ACE = 0, ONE =1, TWO = 2, THREE = 3

        public Face face { get; set; }
        public Suit suit { get; set; }
        public Card(Face faceValue, Suit suitValue)
        {
            face = faceValue;
            suit = suitValue;
        }

        public int CompareTo(Card other)
        {
            // we KNOW the other is a card for sure. so write logic to find which is higher/lower
            // -1
            if (this.face < other.face)
            {
                return -1;
            }
            else if (this.face > other.face)
            {
                return 1;
            }
            else if (this.suit > other.suit)
            {
                return 1;
            }
            else if (this.suit < other.suit)
            {
                return -1;
            }
            else //face and suit are equal
            {
                return 0;
            }
            
        }

        public override string ToString()
        {
            return face.ToString() +" of "+ suit.ToString();
        }
    }
}
