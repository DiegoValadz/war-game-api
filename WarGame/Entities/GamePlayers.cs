using System.ComponentModel.DataAnnotations.Schema;

namespace WarGame.Entities
{
    public class GamePlayers
    {
        public string gameId { get; set; }
        public Game game { get; set; }
        public int playerId { get; set; }
        public Player player { get; set; }
        public int score { get; set; }
        public string deckId { get; set; }
        public Deck deck { get; set; }
   

    }
}
