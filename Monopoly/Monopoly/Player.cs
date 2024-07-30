// See https://aka.ms/new-console-template for more information
using Monopoly;
using System.Collections;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace Main
{
    internal class Player()
    {        
        private int _id = 0;
        private int _playerLocation;
        private int _playerCurrencyAmount;
        new List<int> spacePrice = new LandingSpaces().SalePrice;


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int playerLocation
        {
            get { return _playerLocation; }
            set { _playerLocation = value; }
        }

        public int playerCurrencyAmount
        {
            get { return _playerCurrencyAmount; }
            set { _playerCurrencyAmount = value; }
        }

        public Player(int playerID = 0, int playerLocation = 0, int playerCurrencyAmount = 0) : this()
        {
            this.ID = playerID;
            this.playerLocation = playerLocation;
            this.playerCurrencyAmount = playerCurrencyAmount;
        }

        public void Move(int rolledDice)
        {
            playerLocation = rolledDice + playerLocation;
            if(playerLocation > 40 )
            {
                playerLocation -= +40;
            }
            Console.Write("Current Space:" + playerLocation);

        }

        public void GetLocation()
        {
            Console.WriteLine("The location of this player is: " + playerLocation);

        }

        public void setLocation(int newLocation)
        {
            playerLocation = newLocation;
        }
    }
}