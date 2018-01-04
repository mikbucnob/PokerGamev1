using System;

namespace PokerGame
{
    public enum Hand
    {
        Nothing,
        OnePair,
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind,
        StraightFlush
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }

    }


    class HandEvaluator
    {
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        private Card[] cards;
        private HandValue handValue;

        public HandEvaluator(Card[] sortedHand)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadesSum = 0;
            cards = new Card[5];
            Cards = sortedHand;
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }

        public Hand EvaluateHand()
        {
            //get the number of each suit on hand
            getNumberOfSuit();
            if (StraightFlush())
                return Hand.StraightFlush;
            else if (FourOfKind())
                return Hand.FourKind;
            else if (FullHouse())
                return Hand.FullHouse;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (ThreeOfKind())
                return Hand.ThreeKind;
            else if (TwoPairs())
                return Hand.TwoPairs;
            else if (OnePair())
                return Hand.OnePair;

            //if the hand is nothing, than the player with highest card wins
            handValue.HighCard = (int)cards[4].face;
            return Hand.Nothing;
        }

        private bool StraightFlush()
        {
            // TODO: Implement this method!
            // TODO: confirm all other methods are suitable
            // I have 5 cards with an unbroken sequence of face values
            // AND they are all the same suit
            // look at first card and remember value and suit
            
            // Loop:
            // look at next card and compare value and suit (to make sure face is one up and suit is equal)
            // inside loop return false if above condition not met
            // otherwise - loop exits and we return true

            throw new NotImplementedException();
        }

        private void getNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                if (element.suit == Card.Suit.Hearts)
                    heartsSum++;
                else if (element.suit == Card.Suit.Diamonds)
                    diamondSum++;
                else if (element.suit == Card.Suit.Clubs)
                    clubSum++;
                else if (element.suit == Card.Suit.Spades)
                    spadesSum++;

            }
        }

        private bool FourOfKind()
        {
            //if the first 4 cards, add values of the four cards and last card is the highest
            if (cards[0].face == cards[1].face
                && cards[0].face == cards[2].face &&
                cards[0].face == cards[3].face)
            {
                handValue.Total = (int)cards[1].face * 4;
                handValue.HighCard = (int)cards[4].face;
                return true;
            }
            else if (cards[1].face == cards[2].face
                && cards[1].face == cards[3].face &&
                cards[1].face == cards[4].face)
            {
                handValue.Total = (int)cards[1].face * 4;
                handValue.HighCard = (int)cards[0].face;
                return true;
            }

            return false;
        }

        private bool FullHouse()
        {
            //the first three cards and last two cards are of the same value
            //first two cards and last three cards are of the same value
            if ((cards[0].face == cards[1].face &&
                cards[0].face == cards[2].face &&
                cards[3].face == cards[4].face) ||
                (cards[0].face == cards[1].face &&
                cards[2].face == cards[3].face &&
                cards[2].face == cards[4].face))
            {
                handValue.Total = (int)(cards[0].face) +
                    (int)(cards[1].face) + (int)(cards[2].face)
                    + (int)(cards[3].face) + (int)(cards[4].face);
                return true;
            }
            return false;
        }

        private bool Flush()
        //if all suits are the same
        {
            //if flush, the player with higher cards win
            //whoever has the last card the highest, has automatically all the cards total higher
            if (heartsSum == 5 || diamondSum == 5 || clubSum == 5
                || spadesSum == 5)
            {
                //if flush, the player with higher cards win
                handValue.Total = (int)cards[4].face;
                return true;
            }
            return false;
        }

        private bool Straight()
        {
            //if 5 consecutive values
            if (cards[0].face + 1 == cards[1].face &&
               cards[1].face + 1 == cards[2].face &&
               cards[2].face + 1 == cards[3].face &&
               cards[3].face + 1 == cards[4].face)
            {
                //player with the highest value of the last card wins
                handValue.Total = (int)cards[4].face;
                return true;
            }

            return false;

        }

        private bool ThreeOfKind()
        {
            //if the 1,2,3 cards are the same OR
            //2,3,4 are the same
            //3,4,5 are the same
            //3rd card will always be a part of three of a kind
            if ((cards[0].face == cards[1].face &&
                cards[0].face == cards[2].face) ||
                (cards[1].face == cards[2].face &&
                cards[1].face == cards[3].face))
            {
                handValue.Total = (int)cards[2].face * 3;
                handValue.HighCard = (int)cards[4].face;
                return true;
            }
            else if (cards[2].face == cards[3].face &&
                cards[2].face == cards[4].face)
            {
                handValue.Total = (int)cards[2].face * 3;
                handValue.HighCard = (int)cards[1].face;
                return true;
            }
            return false;
        }

        private bool TwoPairs()
        {
            //if 1,2 and 3,4
            //if 1,2 and 4,5
            //if 2,3 and 4,5
            //with two pairs, the 2nd card will always be a part of one pair
            //and 4th card will always be a part of second pair
            if (cards[0].face == cards[1].face &&
                cards[2].face == cards[3].face)
            {
                handValue.Total = ((int)cards[1].face * 2) +
                    ((int)cards[3].face * 2);
                handValue.HighCard = (int)cards[4].face;
                return true;
            }
            else if (cards[0].face == cards[1].face &&
                cards[3].face == cards[4].face)
            {
                handValue.Total = ((int)cards[1].face * 2) +
                    ((int)cards[3].face * 2);
                handValue.HighCard = (int)cards[2].face;
                return true;
            }
            else if (cards[1].face == cards[2].face &&
                cards[3].face == cards[4].face)
            {
                handValue.Total = ((int)cards[1].face * 2) +
                    ((int)cards[3].face * 2);
                handValue.HighCard = (int)cards[0].face;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            //if 1,2 -> 5th card has the highest value
            //if 2,3
            //if 3,4
            //if 4,5 -> card #3 has the highest value
            if (cards[0].face == cards[1].face)
            {
                handValue.Total = (int)cards[0].face * 2;
                handValue.HighCard = (int)cards[4].face;
                return true;
            }
            else if (cards[1].face == cards[2].face)
            {
                handValue.Total = (int)cards[1].face * 2;
                handValue.HighCard = (int)cards[4].face;
                return true;
            }
            else if (cards[2].face == cards[3].face)
            {
                handValue.Total = (int)cards[2].face * 2;
                handValue.HighCard = (int)cards[4].face;
                return true;
            }
            else if (cards[3].face == cards[4].face)
            {
                handValue.Total = (int)cards[3].face * 2;
                handValue.HighCard = (int)cards[2].face;
                return true;
            }
            return false;
        }
    }
}
