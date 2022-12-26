namespace WarGame.Entities
{
    public class Card
    {
        public string id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public Suit suit { get; set; }
        public int value { get; set; }
        public List<DeckCards> deckCards { get; set; }
        public Card()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int num = rnd.Next();
            this.id = Guid.NewGuid().ToString()+ num;
        }

    }
}
