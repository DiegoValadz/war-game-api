using WarGame.Entities;

namespace WarGame.DTOs
{
    public class GamePlayerDTO
    {
        public int playerId { get; set; }
        public string deckId { get; set; }
        public string name { get; set; }
        public Queue<CardDTO> deck { get; set; }

    }
}
