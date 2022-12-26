namespace WarGame.Entities
{
    public class Player
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<GamePlayers> gamePlayers { get; set; }


    }
}
