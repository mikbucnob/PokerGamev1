using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Deck
    {
        private List<Card> deck;
        
        public Deck()
        {
            deck = new List<Card>();
            CreateDeck();  
            foreach (Card card in deck)
            {
                Console.WriteLine(String.Format("{0}: {1}", card.suit, card.face));
            }
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
            Random random = new Random();
            for (int i=0; i < deck.Count; i++)
            {
                int j = random.Next(1, deck.Count);
                Card temp = deck[j];
                deck[j] = deck[i];
                deck[i] = temp;
            }
            return deck;
        }

        public List<Card> Deal(int cardsToDeal)
        {
            List<Card> hand = deck.Take(cardsToDeal).ToList();
            deck.RemoveRange(0, cardsToDeal);
            return hand;//taking number of references from deck and returning as list
        }

    }
}
