using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Quest PreviousQuest { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public List<QuestCompletionItem> QuestCompletionItems { get; set; }

        private List<Item> reward = new List<Item>();
        public List<Item> RewardItems
        {
            get
            {
                if (reward != null)
                    return reward;

                return new List<Item>();
            }
            set => reward = value;
        }

        public Quest(int id, string name, string description, Quest previousQuest, int rewardExperiencePoints, int rewardGold)
        {
            ID = id;
            Name = name;
            Description = description;
            PreviousQuest = previousQuest;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            QuestCompletionItems = new List<QuestCompletionItem>();
        }
    }
}