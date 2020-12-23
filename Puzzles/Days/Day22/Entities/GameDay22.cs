using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day22
{
    public class GameDay22
    {
        public List<int> Player1Cards { get; set; }
        public List<int> Player2Cards { get; set; }
        private IGame game;

        public GameDay22(List<int> player1cards, List<int> player2cards)
        {
            Player1Cards = player1cards;
            Player2Cards = player2cards;
        }

        public bool GameEnded()
        {
            return Player1Cards.Count == 0 || Player2Cards.Count == 0;
        }
        public void PlayRound()
        {
            var p1Card = Player1Cards.First();
            var p2Card = Player2Cards.First();

            if (p1Card > p2Card)
                AddCardsToWinner(p1Card, p2Card, Player1Cards);
            else
                AddCardsToWinner(p2Card, p1Card, Player2Cards);

            RemoveFirstCards();
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

        private void AddCardsToWinner(int firstCard, int secondCard, List<int> winnerCards)
        {
            winnerCards.Add(firstCard);
            winnerCards.Add(secondCard);
        }
        private void RemoveFirstCards()
        {
            Player1Cards.RemoveAt(0);
            Player2Cards.RemoveAt(0);
        }
    }
}