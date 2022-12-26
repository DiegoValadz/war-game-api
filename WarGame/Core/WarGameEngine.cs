using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WarGame.DTOs;
using WarGame.Entities;
using WarGame.Utils;

namespace WarGame.Core
{
    public class WarGameEngine : IGameEngine
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public Game game { set; get; }
        public int turnCounter = 0;

        public Queue<Card> shuffuledCards { set; get; }
        public List<Event> events { get; set; }

        public WarGameEngine(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task CreateGame()
        {
            game = new Game();
            //Get Cards
            shuffuledCards = await GetFullDeck();

            //Get Players
            game.gamePlayers = await GetPlayers(2, GeneralTools.RECENT_ADDED_PLAYERS, game.id);

            //Initialize Events List
            game.events = new List<Event>();

            //Create Game in DB
            context.Add(game);
            await context.SaveChangesAsync();
        }

        private async Task<Queue<Card>> GetFullDeck()
        {
            List<Card> gameCardsList = await context.Card.ToListAsync();
            Queue<Card> gameCardsQueue = new Queue<Card>(gameCardsList);
            return GameTools.Shuffle(gameCardsQueue);
        }
        private async Task<List<GamePlayers>> GetPlayers(int numberOfPlayers, string selectionMode, string gameId)
        {
            List<GamePlayers> gamePlayers = new List<GamePlayers>();

            if (selectionMode == GeneralTools.RECENT_ADDED_PLAYERS)
            {

                for (int i = 0; i < numberOfPlayers; i++)
                {
                    Player player;
                    if (i > 0)
                        player = await context.Player.FirstOrDefaultAsync(x => x.id != gamePlayers[i - 1].playerId);
                    else
                        player = await context.Player.FirstOrDefaultAsync();

                    if (player != null)
                    {
                        //Deal Cards
                        Deck deck = new Deck();
                        deck.deckCards = GameTools.Deal(shuffuledCards, deck, (i + 1));

                        gamePlayers.Add(new GamePlayers
                        {
                            gameId = gameId,
                            playerId = player.id,
                            player = player,
                            deck = deck,
                        });
                    }
                    else
                        return null;
                }
            }
            return gamePlayers;
        }

        public void Start()
        {
            while (!IsEndOfGame())
            {
                PlayTurn();
                turnCounter++;
            }
        }


        private bool IsEndOfGame()
        {
            if (!game.gamePlayers[0].deck.deckCardsToPlay.Any())
            {
                EmitGameEvent(game.gamePlayers[0], Entities.Action.OUT_OF_CARDS, null);
                EmitGameEvent(game.gamePlayers[1], Entities.Action.WINS, null);
                game.winner = game.gamePlayers[1].player;
                EmitGameEvent(null, Entities.Action.END_GAME, null);
                return true;
            }
            else if (!game.gamePlayers[1].deck.deckCardsToPlay.Any())
            {
                EmitGameEvent(game.gamePlayers[1], Entities.Action.OUT_OF_CARDS, null);
                EmitGameEvent(game.gamePlayers[0], Entities.Action.WINS, null);
                game.winner = game.gamePlayers[0].player;
                EmitGameEvent(null, Entities.Action.END_GAME, null);
                return true;
            }
            else if (turnCounter > 1000)
            {
                EmitGameEvent(null, Entities.Action.INFINITE, null);
                EmitGameEvent(null, Entities.Action.END_GAME, null);
                return true;
            }
            return false;
        }


        private void PlayTurn()
        {
            Queue<Card> pool = new Queue<Card>();

            //Step 1: Each player flips a card
            Card[] playedCards = new Card[2];
            for (int i = 0; i < 2; i++)
            {
                playedCards[i] = game.gamePlayers[i].deck.deckCardsToPlay.Dequeue();
                pool.Enqueue(playedCards[i]);
                EmitGameEvent(game.gamePlayers[i], Entities.Action.PLAY_CARD, playedCards[i]);
            }

            //Step 2: If the cards have the same value, we have a War!
            //IMPORTANT: We CONTINUE to have a war 
            // as long as the flipped cards are the same value.
            while (playedCards[0].value == playedCards[1].value)
            {
                EmitGameEvent(null, Entities.Action.BEGIN_WAR, null);

                //If either player doesn't have enough cards for the War, they lose.
                for (int i = 0; i < 2; i++)
                {
                    if (game.gamePlayers[i].deck.deckCardsToPlay.Count < 2)
                    {
                        game.gamePlayers[i].deck.deckCardsToPlay.Clear();
                        return;
                    }
                }

                //Add One "face-down" card from each player to a common pool
                for (int i = 0; i < 2; i++)
                {
                    var faceDownCard = game.gamePlayers[i].deck.deckCardsToPlay.Dequeue();
                    pool.Enqueue(faceDownCard);
                    EmitGameEvent(game.gamePlayers[i], Entities.Action.FACE_DOWN_CARD_TO_POOL, faceDownCard);

                    //Pop the second card from each player's deck
                    playedCards[i] = game.gamePlayers[i].deck.deckCardsToPlay.Dequeue();
                    pool.Enqueue(playedCards[i]);
                    EmitGameEvent(game.gamePlayers[i], Entities.Action.PLAY_CARD, playedCards[i]);
                }

            }

            //Add the won cards to the winning player's deck, 
            //and display which player won that hand.  
            //This uses our custom extension method from earlier.
            if (playedCards[0].value < playedCards[1].value)
            {
                GeneralTools.EnqueueMany(game.gamePlayers[1].deck.deckCardsToPlay, pool);
                EmitGameEvent(game.gamePlayers[1], Entities.Action.TAKES_THE_HAND, null);
            }
            else
            {
                GeneralTools.EnqueueMany(game.gamePlayers[0].deck.deckCardsToPlay, pool);
                EmitGameEvent(game.gamePlayers[0], Entities.Action.TAKES_THE_HAND, null);
            }
        }

        private void EmitGameEvent(GamePlayers gamePlayer, Entities.Action action, Card card)
        {
            Event ev = new Event();
            ev.gameId = game.id;
            ev.action = action;
            ev.card = card;
            ev.createdAt = DateTime.Now;

            //eventDTO.action = Enum.GetName(typeof(Entities.Action), action);

            if (gamePlayer != null)
            {
                ev.playerId = gamePlayer.playerId;
                ev.player = gamePlayer.player;
            }

            if (card != null)
            {
                ev.cardId = card.id;
            }

            game.events.Add(ev);

        }

        public async Task<GameDTO> Finish()
        {
            context.Update(game);
            await context.SaveChangesAsync();
            return mapper.Map<GameDTO>(game);
        }
    }
}
