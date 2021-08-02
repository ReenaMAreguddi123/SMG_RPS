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

            //start the game
            LetsPlay();
        }


        private static void LetsPlay()
        {
            Console.Write("Let's play, What is your name :");
            var playerName = Console.ReadLine();

            Console.WriteLine($"Welcome {playerName}!!!, you are playing against application.");

            var playOn = true;
            var numberOfRounds = 0;

            IGame game = new Game();

            while (playOn)
            {
                //get player and system choice
                var playerChoice = game.PlayerChoice();
                var systemChoice = game.SystemChoice();

                //caculate result
                var result = game.RoundResult(playerChoice, systemChoice);
                
                Console.WriteLine($"********* Round: {numberOfRounds + 1} ***************");
                
                switch (result)
                {
                    case Result.Player_Won:
                        Console.Write("You won!!!");
                        break;
                    case Result.System_Won:
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
                
                    var finalResult = game.FinalResult();

                    var winner = string.Empty;
                    if (finalResult == Result.Player_Won)
                    {
                        winner = playerName + "-- Congratulations!!!";
                    }
                    else if (finalResult == Result.System_Won)
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
