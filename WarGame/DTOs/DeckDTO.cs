using WarGame.Entities;

namespace WarGame.DTOs
{
    public class DeckDTO
    {
        public string id { get; set; }
        public Queue<CardDTO> cards { get; set; }
    }
}
