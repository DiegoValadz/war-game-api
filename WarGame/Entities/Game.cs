namespace WarGame.Entities
{
    public class Game
    {
        public string id { get; set; }
        public int? winnerId { get; set; }
        public Player winner { get; set; }
        public List<Event> events { get; set; }
        public List<GamePlayers> gamePlayers { get; set; }

        public Game()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int num = rnd.Next();
            this.id = Guid.NewGuid().ToString() + num;
        }


    }
}
