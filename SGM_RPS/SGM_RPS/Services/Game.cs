using System;
using SGM_RPS.Interfaces;
using SGM_RPS.Models;

namespace SGM_RPS.Services
{
    public class Game : IGame
    {
        private int _playerPoints = 0;
        private int _systemPoints = 0;

        private int _rock = 0;
        private int _paper = 0;
        private int _scissors = 0;

        private readonly Random _random;

        public Game()
        {
            _random = new Random();
        }
        
        public Choice PlayerChoice()
        {
            DisplayPlayerChoice();

            do
            {
                var input = Console.ReadLine();

                Choice playerChoice;
                if (Enum.TryParse(input.ToUpper(), true, out playerChoice))
                {
                    return playerChoice;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    DisplayPlayerChoice();
                }
            } while (true);
        }

        public Choice SystemChoice()
        {
            var systemChoice = Choice.Paper;

            var randomChoice = _random.Next(1, 4);
            switch (randomChoice)
            {
                case 1:
                    systemChoice = Choice.Rock;
                    break;
                case 2:
                    systemChoice = Choice.Paper;
                    break;
                case 3:
                    systemChoice = Choice.Scissors;
                    break;
            }

            return systemChoice;
        }

        public Result RoundResult(Choice player, Choice system)
        {
            var result = Result.Draw;
            switch (system)
            {
                case Choice.Rock:
                    if (player == Choice.Rock)
                    {
                        result = Result.Draw;
                    }
                    else if (player == Choice.Paper)
                    {
                        result = Result.PlayerWon;
                        _playerPoints++;
                    }
                    else if (player == Choice.Scissors)
                    {
                        result = Result.SystemWon;
                        _systemPoints++;
                    }

                    break;
                case Choice.Paper:
                    if (player == Choice.Rock)
                    {
                        result = Result.SystemWon;
                        _systemPoints++;
                    }
                    else if (player == Choice.Paper)
                    {
                        result = Result.Draw;
                    }
                    else if (player == Choice.Scissors)
                    {
                        result = Result.PlayerWon;
                        _playerPoints++;
                    }

                    break;
                case Choice.Scissors:
                    if (player == Choice.Rock)
                    {
                        result = Result.PlayerWon;
                        _playerPoints++;
                    }
                    else if (player == Choice.Paper)
                    {
                        result = Result.SystemWon;
                        _systemPoints++;
                    }
                    else if (player == Choice.Scissors)
                    {
                        result = Result.Draw;
                    }

                    break;
            }

            CountChoice(player);
            CountChoice(system);

            return result;
        }

        public Result FinalResult()
        {
            if (_playerPoints > _systemPoints)
            {
                return Result.PlayerWon;
            }
            else if (_playerPoints < _systemPoints)
            {
                return Result.SystemWon;
            }
            else
            {
                return Result.Draw;
            }
        }

        public Choice MostUsedMove()
        {
            var max = Math.Max(_rock, Math.Max(_paper, _scissors));

            if (max == _rock)
                return Choice.Rock;

            if (max == _paper)
                return Choice.Paper;

            return Choice.Scissors;
        }

        private void CountChoice(Choice choice)
        {
            switch (choice)
            {
                case Choice.Rock:
                    _rock++;
                    break;
                case Choice.Paper:
                    _paper++;
                    break;
                case Choice.Scissors:
                    _scissors++;
                    break;
            }
        }

        private void DisplayPlayerChoice()
        {
            Console.WriteLine("Make your choice:");
            Console.WriteLine("************************");
            Console.WriteLine("R - Rock");
            Console.WriteLine("P - Paper");
            Console.WriteLine("S - Scissors");
            Console.WriteLine("************************");
        }
    }
}
