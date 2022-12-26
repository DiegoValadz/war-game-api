using WarGame.DTOs;

namespace WarGame.Core
{
    public interface IGameEngine
    {
        //public GameDTO game { set; get; }

        public Task CreateGame();
        public void Start();
        public Task<GameDTO> Finish();


    }
}