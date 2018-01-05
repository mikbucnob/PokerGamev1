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
                    else if (TakeTurn(player))
                    {
                        gameover = true;
                        break;
                    }
                }
                
            }
            while (gameover != true);
            // end of game - compare hands to determine winner
            // evaluate *ALL* player's (sorted) hands - for each player, create evaluator
            // and put into collection
            // sort the evaluated hands
        }

        public List<Card> ReplaceCard(List<Card> hand, List<Card> replacementCards)
        {
            return hand;
        }

        public int CalculateScore(List<Card> hand)
        {
            int score = 0;
            return score;
        }


        public void Deal()
        {
            //for (int i = 0; i < numPlayers; i++)
            //{
            for (int j = 0; j < 5; j++)
            {
                // hand=
            }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Return true if the game should be over</returns>
        public bool TakeTurn(Player player)
        {

            List<Move> moves = new List<Move>();
            // TODO: swap logic and hand evaluator next

            // can I knock?
            // any move unless puttable hand (Need hand evaluator to determine)
            // .Sort()
            player.Hand.Sort();
            HandEvaluator playerHandEvaluator = new HandEvaluator(player.Hand.ToArray());
            Hand hand = playerHandEvaluator.EvaluateHand();

            // Can I put?
            // I *have* to put (because I have a specific hand)
            if (hand.Equals(Hand.Flush) || hand.Equals(Hand.FullHouse) || hand.Equals(Hand.FourKind)
                || hand.Equals(Hand.StraightFlush))
            {
                moves.Add(Move.Put);
            }
            else
            {
                moves.Add(Move.Knock);
            }
            // Can I swap card?
            // can't very first turn otherwise can(swappable)

            // Can I swap hand?
            // only very first turn of all players(opposite)
            if (handswap)
            {
                //enable card swap
                // pass to player's TakeTurn Method the swapHand move
                moves.Add(Move.SwapHand);
                //TODO: knock and put logic
            }
            else //handswap is false
            {
                //give player swap move
                moves.Add(Move.SwapCard);
            }
            Move decision = player.TakeTurn(moves);
            switch (decision)
            {
                case Move.Knock:
                    //can knock first go if first player wants to keep hand
                    //if player has to put, can't knock otherwise all turns can knock
                    //if first player knock keep handswap true
                    // TODO: this should only be available on the first round
                    handswap = true;//hand not swapped at first round
                    player.HasKnocked = true;
                    break;
                case Move.Put:
                    //game over if put
                    return true;
                case Move.SwapCard:
                    player.SwapCard(tableHand);
                    //do swap card stuff
                    break;
                case Move.SwapHand:
                    //do swap hand stuff
                    handswap = false;
                    tableHand = player.SwapHand(tableHand);
                    break;
            }
            return false;

        }

        public List<Player> CreatePlayerList(int numberofplayers)
        {
            int counter = 0;
            List<Player> playerlist = new List<Player>();
            tableHand = deck.Deal(5);//Original deck card amount of 52 unaffected when game is set up
            while ((numberofplayers > 0) && (counter < numberofplayers))
            {
                counter++;
                playerlist.Add(new Player(deck.Deal(5)));
            }
            return playerlist;
        }
    }
}
