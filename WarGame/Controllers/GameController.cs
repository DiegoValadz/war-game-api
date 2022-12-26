using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WarGame.Core;
using WarGame.DTOs;
using WarGame.Entities;
using WarGame.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarGame.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IGameEngine gameEngine;

        public GameController(ApplicationDbContext context, IMapper mapper, IGameEngine gameEngine)
        {
            this.context = context;
            this.mapper = mapper;
            this.gameEngine = gameEngine;
        }

        [HttpGet("computed")]
        public async Task<ActionResult<GameDTO>> Get()
        {
            await gameEngine.CreateGame();
            gameEngine.Start();
            return Ok(await gameEngine.Finish());
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(string id)
        {
            Game game = await context.Game
                           .Include(x => x.winner)
                           .Include(x => x.events)
                           .ThenInclude(y => y.player)
                            .Include(x => x.events)
                           .ThenInclude(y => y.card)
                            .Include(x => x.gamePlayers)
                           .ThenInclude(y => y.deck)
                           .ThenInclude(z => z.deckCards)
                           .Include(x => x.gamePlayers)
                           .ThenInclude(y => y.player)
                           .FirstOrDefaultAsync(x => x.id == id);

            return game;

        }

    
    }
}
