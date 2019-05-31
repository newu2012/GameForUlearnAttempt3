using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        private readonly SortedList<int, int> _monstersAtLocation = new SortedList<int, int>();

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item ItemRequiredToEnter { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; }
        public Vendor VendorWorkingHere { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }

        public bool HasAMonster => _monstersAtLocation.Count > 0;
        public bool HasAQuest => QuestsAvailableHere != null;
        public bool DoesNotHaveAnItemRequiredToEnter => ItemRequiredToEnter == null;

        public Location(int id, string name, string description,
            Item itemRequiredToEnter = null, List<Quest> questsAvailableHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestsAvailableHere = questsAvailableHere ?? new List<Quest>();
        }

        public void AddMonster(int monsterID, int percentageOfAppearance)
        {
            if (_monstersAtLocation.ContainsKey(monsterID))
            {
                _monstersAtLocation[monsterID] = percentageOfAppearance;
            }
            else
            {
                _monstersAtLocation.Add(monsterID, percentageOfAppearance);
            }
        }

        public Monster NewInstanceOfMonsterLivingHere()
        {
            if (!HasAMonster)
            {
                return null;
            }

            var totalPercentages = _monstersAtLocation.Values.Sum();

            var randomNumber = RandomNumberGenerator.NumberBetween(1, totalPercentages);

            var runningTotal = 0;

            foreach (var monsterKeyValuePair in _monstersAtLocation)
            {
                runningTotal += monsterKeyValuePair.Value;
                if (randomNumber <= runningTotal)
                    return World.MonsterByID(monsterKeyValuePair.Key).NewInstanceOfMonster();
            }
            return World.MonsterByID(_monstersAtLocation.Keys.Last()).NewInstanceOfMonster();
        }
    }
}