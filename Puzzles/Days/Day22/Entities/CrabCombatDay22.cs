using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day22
{
    public class CrabCombatDay22 : IGame
    {
        public List<int> Player1Cards { get; set; }
        public List<int> Player2Cards { get; set; }
        public CrabCombatDay22(List<int> player1cards, List<int> player2cards)
        {
            Player1Cards = player1cards;
            Player2Cards = player2cards;
        }
   
        public virtual void PlayRound()
        {
            PlayNormalCombat();
        }
        public bool GameEnded()
        {
            return Player1Cards.Count == 0 || Player2Cards.Count == 0;
        }
        public ulong GetWinnerScore()
        {
            ulong score = 0;
            var winnerCards = Player1Cards.Union(Player2Cards).ToList();
            var cardsInWinnerDeck = winnerCards.Count();

            for (int i = 1; i <= cardsInWinnerDeck; i++)
                score += (ulong)(i * winnerCards[cardsInWinnerDeck - i]);

            return score;
        }

        protected void AddCardsToWinner(int firstCard, int secondCard, List<int> winnerCards)
        {
            winnerCards.Add(firstCard);
            winnerCards.Add(secondCard);
        }
        protected void RemoveFirstCards()
        {
            Player1Cards.RemoveAt(0);
            Player2Cards.RemoveAt(0);
        }
        protected void PlayNormalCombat()
        {
            var p1Card = Player1Cards.First();
            var p2Card = Player2Cards.First();

            if (p1Card > p2Card)
            {
                AddCardsToWinner(p1Card, p2Card, Player1Cards);
            }
            else
            {
                AddCardsToWinner(p2Card, p1Card, Player2Cards);
            }
            RemoveFirstCards();
        }
        protected bool IsPlayer1Winner()
        {
            return Player2Cards.Count == 0;
        }
    }
}