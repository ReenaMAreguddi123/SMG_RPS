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


        /// <summary>
        /// Reads player choice from console
        /// </summary>
        /// <returns>Choice</returns>
        public Choice PlayerChoice()
        {
            DisplayPlayerChoice();            

            do
            {
                var input = Console.ReadLine();
                input = input.ToUpper();

                if (input == "R" || input == "P" || input == "S")
                {
                    switch(input)
                    {
                        case "R":
                            return Choice.Rock;                         
                        case "P":
                           return Choice.Paper;                            
                        case "S":
                            return Choice.Scissors;                          
                    }                   
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    DisplayPlayerChoice();
                }
            } while (true);            
        }


        /// <summary>
        /// Returns random system choice
        /// </summary>
        /// <returns>Choice</returns>
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

        /// <summary>
        /// Decides winner for the round
        /// </summary>
        /// <param name="player"></param>
        /// <param name="system"></param>
        /// <returns>Result</returns>
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
                        result = Result.Player_Won;
                        _playerPoints++;
                    }
                    else if (player == Choice.Scissors)
                    {
                        result = Result.System_Won;
                        _systemPoints++;
                    }

                    break;
                case Choice.Paper:
                    if (player == Choice.Rock)
                    {
                        result = Result.System_Won;
                        _systemPoints++;
                    }
                    else if (player == Choice.Paper)
                    {
                        result = Result.Draw;
                    }
                    else if (player == Choice.Scissors)
                    {
                        result = Result.Player_Won;
                        _playerPoints++;
                    }

                    break;
                case Choice.Scissors:
                    if (player == Choice.Rock)
                    {
                        result = Result.Player_Won;
                        _playerPoints++;
                    }
                    else if (player == Choice.Paper)
                    {
                        result = Result.System_Won;
                        _systemPoints++;
                    }
                    else if (player == Choice.Scissors)
                    {
                        result = Result.Draw;
                    }

                    break;
            }

            //update move count
            CountChoice(player);
            CountChoice(system);

            return result;
        }

        /// <summary>
        /// Returns final winner after all rounds
        /// </summary>
        /// <returns></returns>
        public Result FinalResult()
        {
            if (_playerPoints > _systemPoints)
            {
                return Result.Player_Won;
            }
            else if (_playerPoints < _systemPoints)
            {
                return Result.System_Won;
            }
            else
            {
                return Result.Draw;
            }
        }

        /// <summary>
        /// Returns most used move
        /// </summary>
        /// <returns></returns>
        public Choice MostUsedMove()
        {
            var max = Math.Max(_rock, Math.Max(_paper, _scissors));

            if (max == _rock)
                return Choice.Rock;

            if (max == _paper)
                return Choice.Paper;

            return Choice.Scissors;
        }

        /// <summary>
        /// keeps count of each move
        /// </summary>
        /// <param name="choice"></param>
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
            Console.WriteLine();
            Console.WriteLine("Make your choice:");
            Console.WriteLine("************************");
            Console.WriteLine("R - Rock");
            Console.WriteLine("P - Paper");
            Console.WriteLine("S - Scissors");
            Console.WriteLine("************************");
        }
    }
}
