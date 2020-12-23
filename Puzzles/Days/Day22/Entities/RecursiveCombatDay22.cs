using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Day22
{
    public class RecursiveCombatDay22 : CrabCombatDay22
    {
        private HashSet<string> Player1PlayedSets { get; }
        private HashSet<string> Player2PlayedSets { get; }

        public RecursiveCombatDay22(List<int> player1cards, List<int> player2cards) : base(player1cards, player2cards)
        {
            Player1PlayedSets = new HashSet<string>();
            Player2PlayedSets = new HashSet<string>();
        }

        public override void PlayRound()
        {
            if (!AreGameSetsUnique())
            {
                TotalPlayer1VictoryResult();
                return;
            }

            AddCardsToHistoryOfThisGame();

            if (ShouldStartSubGame())
            {
                PlaySubGame();
                return;
            }

            PlayNormalCombat();
        }

        private bool AreGameSetsUnique()
        {
            return !Player1PlayedSets.Contains(GetIdentifier(Player1Cards))
                && !Player2PlayedSets.Contains(GetIdentifier(Player2Cards));
        }
        private void AddCardsToHistoryOfThisGame()
        {
            Player1PlayedSets.Add(GetIdentifier(Player1Cards));
            Player2PlayedSets.Add(GetIdentifier(Player2Cards));
        }
        private string GetIdentifier(List<int> list)
        {
            return string.Join(',', list);
        }

        private bool ShouldStartSubGame()
        {
            return Player1Cards.First() <= (Player1Cards.Count() - 1)
                && Player2Cards.First() <= (Player2Cards.Count() - 1);
        }
        private void PlaySubGame()
        {
            var subGame = CreateSubGame();
            ExecuteSubGame(subGame);

            if (subGame.IsPlayer1Winner())
                AddCardsToWinner(Player1Cards.First(), Player2Cards.First(), Player1Cards);
            else
                AddCardsToWinner(Player2Cards.First(), Player1Cards.First(), Player2Cards);

            RemoveFirstCards();
        }
        private RecursiveCombatDay22 CreateSubGame()
        {
            var subsetPlayer1 = Player1Cards.Skip(1).Take(Player1Cards.First()).ToList();
            var subsetPlayer2 = Player2Cards.Skip(1).Take(Player2Cards.First()).ToList();

            return new RecursiveCombatDay22(subsetPlayer1, subsetPlayer2);
        }
        private void ExecuteSubGame(RecursiveCombatDay22 subGame)
        {
            while (!subGame.GameEnded())
                subGame.PlayRound();
        }

        private void TotalPlayer1VictoryResult()
        {
            Player1Cards = Player1Cards.Union(Player2Cards).ToList();
            Player2Cards = new List<int>();
        }
    }
}