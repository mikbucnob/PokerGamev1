using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public enum Face { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
    public enum Suit { Spades = 1, Clubs, Diamonds, Hearts };

    public class Card
    {
        // int suit and int face
        // CONSTANTS
        // ENUM suit, ENUM face (ordinal = index) ACE = 0, ONE =1, TWO = 2, THREE = 3

        public Face face { get; set; }
        public Suit suit { get; set; }
        public Card(Face faceValue, Suit suitValue)
        {
            face = faceValue;
            suit = suitValue;
        }        

    }
}
