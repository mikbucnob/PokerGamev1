using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Deck
    {
        List<Card> deck;

        /*private String [] faceTypes = { "Aces", "Ones", "Two" };
        private String[] suitTypes = { "Hearts", "Spades", "Clubs", "Diamonds" };*/
        //can use strings as well

        public Deck()
        {
            deck = new List<Card>();
            CreateDeck();  
            foreach (Card card in deck)
            {
                Console.WriteLine(String.Format("{0}: {1}", card.suit, card.face));
            }
            // deck[count] = new Card(faceTypes[count % 13], suitTypes[count / 13]);
        }

        private void CreateDeck()
        {
            Array faceValues = Enum.GetValues(typeof(Card.Face));
            Array suitValues = Enum.GetValues(typeof(Card.Suit));

            foreach (Card.Suit suit in suitValues)
            {
                foreach (Card.Face face in faceValues)
                {
                    Console.WriteLine(String.Format("{0}: {1}", suit, face));
                    deck.Add(new Card(face, suit));
                }
            }
        }

        public Deck(List<Card> cardDeck)
        {
            deck = cardDeck;
        }

        public List<Card> Shuffle()
        {
            Console.WriteLine("-------------------------------------");
            //Console.WriteLine("Deck count = " + deck.Count);
            Random random = new Random();
            for (int i=0; i < deck.Count; i++)
            {
                int j = random.Next(1, deck.Count);
                Card temp = deck[j];
                deck[j] = deck[i];
                deck[i] = temp;
            }
            //Console.WriteLine("Deck count = " + deck.Count);
            return deck;
            
        }

        public List<Card> Deal(int cardsToDeal)
        {//original deck is not modified
            List<Card> hand = deck.Take(cardsToDeal).ToList();
            deck.RemoveRange(0, cardsToDeal);
            return hand;//taking number of references from deck and returning as list
        }

    }
}
