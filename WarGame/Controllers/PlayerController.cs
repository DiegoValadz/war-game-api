using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarGame.DTOs;
using WarGame.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarGame.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PlayerController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("scores")]
        public async Task<ActionResult<object>> GetPlayersRanking()
        {
            var results = await context.Game.Join(context.Player, g => g.winnerId, p => p.id, (game, player) => new
            {
                playerName = player.firstName + " "+ player.lastName,
                game = game.id
            }).GroupBy(gp => gp.playerName).Select(gp => new
            {
                Name = gp.Key,
                TotalVictories = gp.Count()

            }).ToListAsync();


            return results;
        }

        [HttpGet("{id}", Name = "GetPlayerById")]
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            return await context.Player.FirstOrDefaultAsync(x=> x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> Post([FromBody] PlayerCDTO playerCDTO)
        {
            var player = mapper.Map<Player>(playerCDTO);
            context.Add(player);
            await context.SaveChangesAsync();
        
            var playerDTO = mapper.Map<PlayerDTO>(player);
            return CreatedAtRoute("GetPlayerById", new { id = playerDTO.id }, playerDTO);
        }

       
    }
}
