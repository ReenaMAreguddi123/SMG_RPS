using SGM_RPS.Interfaces;
using SGM_RPS.Models;
using System;
using SGM_RPS.Services;

namespace SGM_RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------- Rock Paper Scissors ----------");

            LetsPlay();
        }


        private static void LetsPlay()
        {
            Console.Write("Lets play, What is your name :");
            var playerName = Console.ReadLine();

            Console.WriteLine($"Welcome {playerName}!!!, you are playing against application.");

            var playOn = true;
            var numberOfRounds = 0;

            IGame game = new Game();

            while (playOn)
            {
                var playerChoice = game.PlayerChoice();
                var systemChoice = game.SystemChoice();

                var result = game.RoundResult(playerChoice, systemChoice);
                
                Console.WriteLine("************************");
                
                switch (result)
                {
                    case Result.PlayerWon:
                        Console.Write("You won!!!");
                        break;
                    case Result.SystemWon:
                        Console.Write("System won!!!");
                        break;
                    case Result.Draw:
                        Console.Write("It's draw!!!");
                        break;
                }

                Console.WriteLine($" ({playerChoice} Vs {systemChoice})");

                numberOfRounds++;

                Console.WriteLine("Play again (Y or N)?");
                var playAgain = Console.ReadLine();

                if (playAgain.ToUpper() == "N")
                {
                    playOn = false;

                    Console.WriteLine("----- Game Summary -----");

                    Console.WriteLine("************************");

                    var finalResult = game.FinalResult();

                    var winner = string.Empty;
                    if (finalResult == Result.PlayerWon)
                    {
                        winner = playerName + "-- Congragulations!!!";
                    }
                    else if (finalResult == Result.SystemWon)
                    {
                        winner = "System -- Better luck next time!!!";

                    }
                    else if (finalResult == Result.Draw)
                    {
                        winner = "Its a Draw!!";

                    }

                    Console.WriteLine("*************************************");

                    Console.WriteLine($"The winner is : {winner}");
                    Console.WriteLine($"Number of turns : {numberOfRounds}");
                    Console.WriteLine($"Most used move : {game.MostUsedMove()}");

                    Console.WriteLine("*************************************");
                }
            }
        }

    }
}
