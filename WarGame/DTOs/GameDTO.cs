using WarGame.Entities;

namespace WarGame.DTOs
{
    public class GameDTO
    {
        public string id { get; set; }
        public PlayerDTO winner { get; set; }
        public List<EventDTO> events { get; set; }
        public List<GamePlayerDTO> players { get; set; }

    }
}
