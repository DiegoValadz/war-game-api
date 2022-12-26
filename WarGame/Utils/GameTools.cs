using WarGame.Entities;

namespace WarGame.Utils
{
    public class GameTools
    {

        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();
            for (int i = 2; i <= 14; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Enqueue(new Card()
                    {
                        id = Guid.NewGuid().ToString(),
                        suit = suit,
                        value = i,
                        name = GetCardName(i, suit, false),
                        shortName = GetCardName(i, suit, true)
                    });
                }
            }
            return cards;
        }

        public static Queue<Card> Shuffle(Queue<Card> cards)
        {
            List<Card> transformedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                //Step 2: Randomly pick a card which has not been shuffled
                int k = r.Next(n + 1);

                //Step 3: Swap the selected item 
                //        with the last "unselected" card in the collection
                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Queue<Card> shuffledCards = new Queue<Card>();
            foreach (var card in transformedCards)
            {
                shuffledCards.Enqueue(card);
            }

            return shuffledCards;
        }

        private static string GetCardName(int value, Suit suit, bool isShort)
        {
            string valueDisplay = "";
            if (value >= 2 && value <= 10)
            {
                valueDisplay = value.ToString();
            }
            else if (value == 11)
            {
                valueDisplay = (isShort) ? "J" : "Jack";
            }
            else if (value == 12)
            {
                valueDisplay = (isShort) ? "Q" : "Queen";
            }
            else if (value == 13)
            {
                valueDisplay = (isShort) ? "K" : "King";
            }
            else if (value == 14)
            {
                valueDisplay = (isShort) ? "A" : "Ace";
            }

            if (!isShort)
                valueDisplay += " of " + Enum.GetName(typeof(Suit), suit);
            else
                valueDisplay += Enum.GetName(typeof(Suit), suit)[0];

            return valueDisplay;
        }

        public static List<DeckCards> Deal(Queue<Card> cards, Deck deck, int playerNumber)
        {
            List<DeckCards> deckCards = new List<DeckCards>();

            int cardsCounter = 2;

            int deckCounter = 0;

            deck.deckCardsToPlay = new Queue<Card>();


            for (int i = 0; i < 52; i++)
            {

                if (playerNumber == 1)
                {
                    if (cardsCounter % 2 == 0)
                    {
                        var dequeueCard = cards.Dequeue();
                        deckCards.Add(new DeckCards()
                        {
                            cardId = dequeueCard.id,
                            deckId = deck.id,
                            order = deckCounter
                        });
                        deck.deckCardsToPlay.Enqueue(dequeueCard);

                        deckCounter++;
                    }
                }
                else if(playerNumber == 2)
                {
                    if (cardsCounter % 2 != 0)
                    {
                        var dequeueCard = cards.Dequeue();

                        deckCards.Add(new DeckCards()
                        {
                            cardId = dequeueCard.id,
                            deckId = deck.id,
                            order = deckCounter
                        });
                        deck.deckCardsToPlay.Enqueue(dequeueCard);

                        deckCounter++;
                    }
                }
                cardsCounter++;
            }

            return deckCards;


        }
    }
}
