namespace WarGame.Entities
{
    public class DeckCards
    {
        public string deckId { get; set; }
        public Deck deck { get; set; }
        public string cardId { get; set; }
        public Card card { get; set; }
        public int order { get; set; }
    }
}
