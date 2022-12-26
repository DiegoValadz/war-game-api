using WarGame.Entities;

namespace WarGame.DTOs
{
    public class EventDTO
    {
        public string id { get; set; }
        public int? playerId { get; set; }
        public string player { get; set; }
        public string card { get; set; }
        public string action { get; set; }

        public DateTime createdAt { get; set; }

        public EventDTO()
        {
            this.id = Guid.NewGuid().ToString();
        }
    }
}
