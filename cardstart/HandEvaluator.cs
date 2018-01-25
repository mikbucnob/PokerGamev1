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


    class HandEvaluator
    {
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        private Card[] cards;
        private int total;
        private int highCard;
        private Hand hand;


        public int Total { get => total; }
        public int HighCard { get => highCard; }
        public Hand TheHand { get => hand; }

        public HandEvaluator()
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadesSum = 0;
            cards = new Card[5];

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


        public Hand EvaluateHand(Card[] sortedHand)
        {

            Cards = sortedHand;
            //get the number of each suit on hand
            getNumberOfSuit();
            if (StraightFlush())
                hand = Hand.StraightFlush;
            else if (FourOfKind())
                hand = Hand.FourKind;
            else if (FullHouse())
                hand = Hand.FullHouse;
            else if (Flush())
                hand = Hand.Flush;
            else if (Straight())
                hand = Hand.Straight;
            else if (ThreeOfKind())
                hand = Hand.ThreeKind;
            else if (TwoPairs())
                hand = Hand.TwoPairs;
            else if (OnePair())
                hand = Hand.OnePair;
            else
            {
                //if the hand is nothing, than the player with highest card wins
                highCard = (int)cards[4].face;
                hand = Hand.Nothing;
            }
            return hand;
        }

        private bool StraightFlush()
        {
            if (heartsSum == 5 || diamondSum == 5 || clubSum == 5
                || spadesSum == 5)
            {
                // Brittle code - one slight change elsewhere means this shatters...
                if (cards[0].face + 1 == cards[1].face &&
               cards[1].face + 1 == cards[2].face &&
               cards[2].face + 1 == cards[3].face &&
               cards[3].face + 1 == cards[4].face)
                {
                    total = ((int)cards[0].face + (int)cards[1].face +
                (int)cards[1].face + (int)cards[2].face +
                (int)cards[2].face + (int)cards[3].face +
                 (int)cards[3].face + (int)cards[4].face);
                    highCard = (int)cards[4].face;
                    return true;
                }
            }
            return false;

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
            if (cards[0].face == cards[1].face
                && cards[0].face == cards[2].face &&
                cards[0].face == cards[3].face)
            {
                total = (int)cards[1].face * 4;
                highCard = (int)cards[4].face;
                return true;
            }
            else if (cards[1].face == cards[2].face
                && cards[1].face == cards[3].face &&
                cards[1].face == cards[4].face)
            {
                //total = (int)cards[1].face * 4;
                highCard = (int)cards[0].face;
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
                total = (int)(cards[0].face) +
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
                total = (int)cards[4].face;
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
                total = (int)cards[4].face;
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
                total = (int)cards[2].face * 3;
                highCard = (int)cards[4].face;
                return true;
            }
            else if (cards[2].face == cards[3].face &&
                cards[2].face == cards[4].face)
            {
                total = (int)cards[2].face * 3;
                highCard = (int)cards[1].face;
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
                total = ((int)cards[1].face * 2) +
                    ((int)cards[3].face * 2);
                highCard = (int)cards[4].face;
                return true;
            }
            else if (cards[0].face == cards[1].face &&
                cards[3].face == cards[4].face)
            {
                total = ((int)cards[1].face * 2) +
                    ((int)cards[3].face * 2);
                highCard = (int)cards[2].face;
                return true;
            }
            else if (cards[1].face == cards[2].face &&
                cards[3].face == cards[4].face)
            {
                total = ((int)cards[1].face * 2) +
                    ((int)cards[3].face * 2);
                highCard = (int)cards[0].face;
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
                total = (int)cards[0].face * 2;
                highCard = (int)cards[4].face;
                return true;
            }
            else if (cards[1].face == cards[2].face)
            {
                total = (int)cards[1].face * 2;
                highCard = (int)cards[4].face;
                return true;
            }
            else if (cards[2].face == cards[3].face)
            {
                total = (int)cards[2].face * 2;
                highCard = (int)cards[4].face;
                return true;
            }
            else if (cards[3].face == cards[4].face)
            {
                total = (int)cards[3].face * 2;
                highCard = (int)cards[2].face;
                return true;
            }
            return false;
        }
    }
}
