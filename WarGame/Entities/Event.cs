namespace WarGame.Entities
{
    public class Event
    {
        public string id { get; set; }
        public int? playerId { get; set; }
        public Player? player { get; set; }
        public string gameId { get; set; }
        public Game game { get; set; }
        public string? cardId { get; set; }
        public Card? card { get; set; }
        public Action action { get; set; }
        public DateTime createdAt { get; set; }

        public Event()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int num = rnd.Next();
            this.id = Guid.NewGuid().ToString() + num;
        }
    }
}
