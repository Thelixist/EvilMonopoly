using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Monopoly
{
    internal class LandingSpaces
    {
        LandingSpacesLogic landingSpacesLogic = new();
        private ArrayList _spaceID = new ArrayList();
        private ArrayList _spaceName = new ArrayList();
        private List<int> _salePrice = new List<int>();
        private ArrayList _spaceDescription = new ArrayList();
        private bool useTruthNext = true; // Flag to alternate between truth and dare

        public ArrayList SpaceID
        {
            get { return _spaceID; }
            set { _spaceID = value; }
        }

        public ArrayList SpaceName
        {
            get { return _spaceName; }
            set { _spaceName = value; }
        }

        public List<int> SalePrice
        {
            get { return _salePrice; }
            set { _salePrice = value; }
        }

        public ArrayList SpaceDescription
        {
            get { return _spaceDescription; }
            set { _spaceDescription = value; }
        }

        List<string> questionsTruth = new List<string>();
        List<string> questionsDare = new List<string>();

        public void SpaceRetrieval(int landingSpaceID = 0)
        {
            if (landingSpaceID >= 0 && landingSpaceID < _salePrice.Count)
            {
                Console.ReadKey();
                Console.WriteLine($"Space ID: {_spaceID[landingSpaceID]}, Name: {_spaceName[landingSpaceID]}, Sale Price: {_salePrice[landingSpaceID]}, Description: {_spaceDescription[landingSpaceID]}");
            }
            else
            {
                Console.WriteLine("Invalid landing space ID.");
            }
        }

        public void Initialize()
        {
            SpaceID.Add(0);
            SpaceName.Add(0);
            SalePrice.Add(0);
            SpaceDescription.Add(0);
            Console.WriteLine();
            Console.WriteLine("Initializer");

            string questionsTruthOrDare = "..\\..\\..\\..\\News-Scraper\\TruthOrDareQuestions.csv";
            using (StreamReader sr1 = new StreamReader(questionsTruthOrDare))
            {
                sr1.ReadLine();
                string line1;
                while ((line1 = sr1.ReadLine()) != null)
                {
                    string[] splitted1 = line1.Split(',');
                    if (splitted1.Length >= 2)
                    {
                        try
                        {
                            string truthSplit = splitted1[0];
                            string dareSplit = splitted1[1];

                            questionsTruth.Add(truthSplit);
                            questionsDare.Add(dareSplit);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine($"Data format error: {e.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Line does not contain enough data: " + line1);
                    }
                }
            }

            string csvPath = "..\\..\\..\\..\\MonopolyBoard.csv";

            using (StreamReader sr = new StreamReader(csvPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitted = line.Split(',');

                    if (splitted.Length >= 3)
                    {
                        try
                        {
                            int spaceIDSplit = int.Parse(splitted[0]);
                            string spaceNameSplit = splitted[1];
                            int salePriceSplit = int.Parse(splitted[2]);
                            string spaceDescriptionSplit = splitted[3];

                            _spaceID.Add(spaceIDSplit);
                            _salePrice.Add(salePriceSplit);

                            NameAssignment(spaceIDSplit);

                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine($"Data format error: {e.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Line does not contain enough data: " + line);
                    }
                }
            }
        }

        private void NameAssignment(int spaceIDSplit)
        {
            var random = new Random();
            if (landingSpacesLogic.spaceGO.Contains(spaceIDSplit))
            {
                _spaceName.Add("Pass Go!");
                _spaceDescription.Add("Collect $200!");
            }
            else if (landingSpacesLogic.spaceRailRoad.Contains(spaceIDSplit))
            {
                _spaceName.Add("Railroad Crossing");
                _spaceDescription.Add("Pay $200 to make dares of your own or Drink! CHOO CHOO");
            }
            else if (landingSpacesLogic.spaceRegular.Contains(spaceIDSplit))
            {
                if (useTruthNext)
                {
                    if (spaceIDSplit < questionsTruth.Count)
                    {
                        var randomTruth = random.Next(1, questionsTruth.Count);
                        _spaceDescription.Add(questionsTruth[randomTruth]);
                        _spaceName.Add("Truth");
                    }
                }
                else
                {
                    if (spaceIDSplit < questionsDare.Count)
                    {
                        var randomDare = random.Next(1, questionsDare.Count);
                        _spaceDescription.Add(questionsDare[randomDare]);
                        _spaceName.Add("Dare");
                    }
                }
                useTruthNext = !useTruthNext; // Alternate the flag
            }
            else if (landingSpacesLogic.spaceChance.Contains(spaceIDSplit))
            {
                _spaceName.Add("Chance");
                SpaceDescription.Add("Feelin' lucky -- Punk?");
            }
            else if (landingSpacesLogic.spaceComChest.Contains(spaceIDSplit))
            {
                _spaceName.Add("Community Chest");
                _spaceDescription.Add("Take $200 or 1 Sock from the person to your left.");
            }
            else if (landingSpacesLogic.taxIncome.Contains(spaceIDSplit))
            {
                _spaceName.Add("Taxed");
                _spaceDescription.Add("Everybody pays $25");
            }
            else if (landingSpacesLogic.spaceVisiting == spaceIDSplit)
            {
                _spaceName.Add("Visiting");
                _spaceDescription.Add("Your dad showed up to give this to you. Then left. Again.");
            }
            else if (landingSpacesLogic.spaceCompanyElectric == spaceIDSplit)
            {
                _spaceName.Add("The Electric");
                _spaceDescription.Add("Bust out some dance moves, the person to your right chooses the dance.");
            }
            else if (landingSpacesLogic.spaceSafeZone == spaceIDSplit)
            {
                _spaceName.Add("SAFE!");
                _spaceDescription.Add("Take a deep breath. You need it.");
            }
            else if (landingSpacesLogic.spaceCompanyWater == spaceIDSplit)
            {
                _spaceName.Add("Drink some water");
                _spaceDescription.Add("Seriously, you need it. Thirsty Hoe.");
            }
            else if (landingSpacesLogic.spaceJail == spaceIDSplit)
            {
                _spaceName.Add("Jail");
                _spaceDescription.Add("You are left with nothing but a shot of tequila... 3 of them.. 1 for each time you don't roll doubles ");
            }
            else if (landingSpacesLogic.spaceTaxSuper == spaceIDSplit)
            {
                _spaceName.Add("Super Tax");
                _spaceDescription.Add("The bet is $100 each. Was it really worth it? Everybody roll, highest gets the pot.");
            }
            else
            {
                Console.WriteLine("Logic Error in LandingSpacesLogic");
            }
        }
    }
}
