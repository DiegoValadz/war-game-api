using System.ComponentModel.DataAnnotations.Schema;

namespace WarGame.Entities
{
    //Dropped Entity considering the time and requirements
    public class Deck
    {
        public string id { get; set; }
        public List<DeckCards> deckCards { get; set; }
        [NotMapped]
        public Queue<Card> deckCardsToPlay { get; set; }
        public Deck()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int num = rnd.Next();
            this.id = Guid.NewGuid().ToString() + num;
        }
    }
}
