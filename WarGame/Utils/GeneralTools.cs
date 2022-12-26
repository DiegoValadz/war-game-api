using WarGame.DTOs;
using WarGame.Entities;

namespace WarGame.Utils
{
    public static class GeneralTools
    {
        public static readonly string RECENT_ADDED_PLAYERS = "RECENT_ADDED_PLAYERS";

        
        public static void EnqueueMany(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach (var card in newCards)
            {
                cards.Enqueue(card);
            }
        }
    }
}
