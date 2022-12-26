using AutoMapper;
using System;
using WarGame.DTOs;
using WarGame.Entities;

namespace WarGame.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Entities.Action, ActionDTO>().ReverseMap();

            CreateMap<Player, PlayerDTO>().ReverseMap();
            CreateMap<Player, PlayerCDTO>().ReverseMap();

            CreateMap<Game, GameDTO>()
              .ForMember(dest => dest.players, opt => opt.MapFrom(MapGamePlayersToGamePlayersDTO));

            CreateMap<GameDTO, Game>()
            .ForMember(dest => dest.gamePlayers, opt => opt.MapFrom(MapGamePlayersDTOToGamePlayers));
            CreateMap<GamePlayerDTO, Player>();

            CreateMap<GamePlayerDTO, PlayerDTO>()
                   .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.playerId))
                   .ForMember(dest => dest.firstName, opt => opt.MapFrom(MapSeparetedName))
                   .ForMember(dest => dest.lastName, opt => opt.MapFrom(MapSeparetedLastName))

                   ;


            CreateMap<Event, EventDTO>()
                .ForMember(dest => dest.action, opt => opt.MapFrom(MapActionToString))
                .ForMember(dest => dest.player, opt => opt.MapFrom(src => src.player.firstName + " " + src.player.lastName))
                .ForMember(dest => dest.card, opt => opt.MapFrom(src => src.card.name));



            CreateMap<EventDTO, Event>()
                .ForMember(dest => dest.action, opt => opt.MapFrom(MapStringToAction));


            CreateMap<DeckCards, EventDTO>().ReverseMap();

        }
        private Entities.Action MapStringToAction(EventDTO eventDTO, Event ev)
        { 
            return (Entities.Action) Enum.Parse(typeof(Entities.Action), eventDTO.action);
        }
        private string MapActionToString(Event ev, EventDTO eventDTO)
        {
            if(ev == null)
            {
                return "No Action";
            }
            else
            {
                return Enum.GetName(typeof(Entities.Action), ev.action);
            }
        }

        
        private string MapSeparetedName(GamePlayerDTO gamePlayerDTO, PlayerDTO playerDTO,string type)
        {
            return gamePlayerDTO.name.Split(" ")[0];
        }

        private string MapSeparetedLastName(GamePlayerDTO gamePlayerDTO, PlayerDTO playerDTO, string type)
        {
            return gamePlayerDTO.name.Split(" ")[1];
        }

        private List<GamePlayers> MapGamePlayersDTOToGamePlayers(GameDTO gameDTO,Game game)
        {
            var players = new List<GamePlayers>();

            if (gameDTO.players == null)
            {
                return players;
            }

            foreach (var gp in gameDTO.players)
            {
                GamePlayers gamePlayer = new GamePlayers
                {
                    playerId = gp.playerId,
                    player = new Player() { id= gp.playerId,firstName = gp.name.Split(" ")[0], lastName = gp.name.Split(" ")[0], },
                };

                Deck deck = new Deck();

                List<DeckCards> deckCards= new List<DeckCards>();

                while (gp.deck.Any()) 
                {
                    DeckCards deckCard = new DeckCards();
                    deckCard.deckId = gp.deckId;
                    deckCard.cardId = gp.deck.Dequeue().id;


                    deckCards.Add(deckCard);
                }
                deck.id = gp.deckId;
                deck.deckCards = deckCards;

                gamePlayer.deckId = gp.deckId;
                gamePlayer.deck = deck;


                gamePlayer.gameId = gameDTO.id;
              

                players.Add(gamePlayer);

            }

            return players;
        }


        private List<GamePlayerDTO> MapGamePlayersToGamePlayersDTO(Game game, GameDTO gameDTO)
        {
            var players = new List<GamePlayerDTO>();

            if (game.gamePlayers == null)
            {
                return players;
            }

            foreach (var gp in game.gamePlayers)
            {
                GamePlayerDTO gamePlayerDTO = new GamePlayerDTO
                {
                    playerId = gp.player.id,
                    deckId = gp.deckId,
                    name = gp.player.firstName + " "+ gp.player.lastName
                };

                gp.deck.deckCards.OrderBy(x => x.order);
                Queue<CardDTO> deck = new Queue<CardDTO>();

                for (int i = 0; i < gp.deck.deckCards.Count; i++)
                {
                    deck.Enqueue(new CardDTO()
                    {
                        id = gp.deck.deckCards[i].card.id,
                        name = gp.deck.deckCards[i].card.name,
                        shortName = gp.deck.deckCards[i].card.shortName,
                        value = gp.deck.deckCards[i].card.value,
                        order = gp.deck.deckCards[i].order
                    }
                    );
                }
                gamePlayerDTO.deck = deck;
                players.Add(gamePlayerDTO);

            }

            return players;
        }
       
    }
}
