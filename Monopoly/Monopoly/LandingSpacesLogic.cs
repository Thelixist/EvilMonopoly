using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    internal class LandingSpacesLogic
    {
        private int[] _spaceRegular = new int[23]
        {
            2, 4, 7, 9, 10, 12, 14, 15, 17, 19,
            20, 22, 24, 25, 27, 28, 30, 32, 33,
            35, 36, 38, 40
        };
        private int[] _spaceComChest = new int[3] { 3, 18, 34 };
        private int[] _taxIncome = new int[1] { 5 };
        private int[] _spaceChance = new int[3] { 8, 23, 37 };
        private int[] _spaceRailRoad = new int[4] { 6, 16, 26, 36 };
        private int[] _spaceGO = new int[1] { 1 };
        private int _spaceVisiting = 11;
        private int _spaceCompanyElectric = 13;
        private int _spaceSafeZone = 21;
        private int _spaceCompanyWater = 29;
        private int _spaceJail = 31;
        private int _spaceTaxSuper = 39;

        public int[] spaceRegular
        {
            get { return _spaceRegular; }
            set { _spaceRegular = value; }
        }

        public int[] spaceComChest
        {
            get { return _spaceComChest; }
            set { _spaceComChest = value; }
        }

        public int[] taxIncome
        {
            get { return _taxIncome; }
            set { _taxIncome = value; }
        }

        public int[] spaceChance
        {
            get { return _spaceChance; }
            set { _spaceChance = value; }
        }

        public int[] spaceRailRoad
        {
            get { return _spaceRailRoad; }
            set { _spaceRailRoad = value; }
        }
        public int[] spaceGO
        {
            get { return _spaceGO; }
            set { _spaceGO = value; }
        }
        public int spaceVisiting
        {
            get { return _spaceVisiting; }
            set { _spaceVisiting = value; }
        }
        
        public int spaceCompanyElectric
        {
            get { return _spaceCompanyElectric; }
        }
        public int spaceCompanyWater
        {
            get { return _spaceCompanyWater; }
        }
        public int spaceSafeZone
        {
            get { return _spaceSafeZone; }
        }
        public int spaceJail
        {
            get { return _spaceJail; }
        }
        public int spaceTaxSuper
        {
            get { return _spaceTaxSuper; }
        }
    }

}
