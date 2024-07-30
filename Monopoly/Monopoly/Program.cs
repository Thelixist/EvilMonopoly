// See https://aka.ms/new-console-template for more information
using Monopoly;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace Main
{
    class Monopoly
    {
        static void Main(string[] args)
        {
            LandingSpaces landingSpaces = new LandingSpaces();

            Dictionary<string, Player> players = new Dictionary<string, Player>();
            players["Player1"] = new Player(1, 1, 200);
            players["Player2"] = new Player(2, 1, 200);
            players["Player3"] = new Player(3, 1, 200);
            players["Player4"] = new Player(4, 1, 200);
            ArrayList playerQueue = new ArrayList();
            //Startup
            //============================================================
            Console.WriteLine("Welcome to a game of evil Monopoly!");
            
            //Players
            Console.WriteLine("Enter the number of players.");
            var numPlayersAsString = Convert.ToInt32(Console.ReadLine());
            int numPlayers = Convert.ToInt32(numPlayersAsString);
            Console.WriteLine("There will be " + numPlayers);

            //Assigning players a number
            for (int i = 1; i < numPlayers + 1; i++)
            {
                playerQueue.Add(i);

            }

            
            landingSpaces.Initialize();
            landingSpaces.SalePrice.Count();
            
            

            //GAME ACTIVATION AFTER SETUP
            
            bool active = true;
            while (active == true)
            {


                //Gameplay
                //==============================
                object currentPlayer = playerQueue[0];
                Console.WriteLine("Player " + currentPlayer + ", roll the Dice by pressing *Enter*");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("Roll the Dice by pressing *Enter*");
                }
                //Rolls the Dice
                var rand = new Random();
                var rolledDice = rand.Next(2, 12);
                Console.WriteLine("Player " + playerQueue[0] + " had rolled: " + rolledDice);

                // Move Current Player || ********* Trying to select which player

                string key = "Player" + currentPlayer;
                if (players.TryGetValue(key, out Player selectedPlayer))
                {
                    selectedPlayer.Move(rolledDice);
                    int loc = selectedPlayer.playerLocation;
                    PlayTurn(loc);

                }
                else
                {
                    Console.WriteLine("Player not found.");
                }


                void PlayTurn(int playerLocation)
                {
                    landingSpaces.SpaceRetrieval(playerLocation);
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1: Pay the Fine");
                    Console.WriteLine("2: Do the deed");
                    Console.WriteLine("3: Take a shot");
                    int playerOption = int.Parse(Console.ReadLine());
                    bool active = true;
                    while (active == true)
                    {
                        switch (playerOption)
                        {
                            case 1:
                                PayFine(playerLocation, selectedPlayer.playerCurrencyAmount);
                                active = false;
                                break;
                            case 2:
                                DoTheDeed();
                                break;

                            case 3:
                                TakeAShot();
                                break;

                            default:
                                Console.WriteLine("Not an Option");
                                break;
                        }
                    }

                }

                void PayFine(int playerLocation = 0, int playerCurrency = 0)
                {
                    Console.WriteLine("Before Fine: " + playerCurrency);
                    int salePrice = landingSpaces.SalePrice[playerLocation];
                    playerCurrency = playerCurrency - salePrice;
                    selectedPlayer.playerCurrencyAmount = playerCurrency;
                    Console.WriteLine("After Final: " + playerCurrency);
                    Console.ReadKey();
                }



                ///END OF TURN
                //Circulate the player in the array. Moves the player to the back of the que

                playerQueue.RemoveAt(0);
                playerQueue.Add(currentPlayer);
                }
            }

        private static void TakeAShot()
        {
            throw new NotImplementedException();
        }

        private static void DoTheDeed()
        {
            throw new NotImplementedException();
        }
    }
}
