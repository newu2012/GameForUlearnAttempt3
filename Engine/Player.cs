using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }

        public int Level => ExperiencePoints / 100 + 1;
        public Location CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }

        private Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }
        
        public static Player CreateDefaultPlayer()
        {
            var player = new Player(10, 10, 20, 0);
            player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));
            player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);
 
            return player;
        }
        
        public static Player CreatePlayerFromXmlString(string xmlPlayerData)
        {
            try
            {
                var playerData = new XmlDocument();
 
                playerData.LoadXml(xmlPlayerData);
 
                var currentHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentHitPoints").InnerText);
                var maximumHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaximumHitPoints").InnerText);
                var gold = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Gold").InnerText);
                var experiencePoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/ExperiencePoints").InnerText);
 
                var player = new Player(currentHitPoints, maximumHitPoints, gold, experiencePoints);
 
                var currentLocationID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentLocation").InnerText);
                player.CurrentLocation = World.LocationByID(currentLocationID);
 
                foreach(XmlNode node in playerData.SelectNodes("/Player/InventoryItems/InventoryItem"))
                {
                    var id = Convert.ToInt32(node.Attributes["ID"].Value);
                    var quantity = Convert.ToInt32(node.Attributes["Quantity"].Value);
 
                    for(var i = 0; i < quantity; i++)
                    {
                        player.AddItemToInventory(World.ItemByID(id));
                    }
                }
 
                foreach(XmlNode node in playerData.SelectNodes("/Player/PlayerQuests/PlayerQuest"))
                {
                    var id = Convert.ToInt32(node.Attributes["ID"].Value);
                    var isCompleted = Convert.ToBoolean(node.Attributes["IsCompleted"].Value);
 
                    var playerQuest = new PlayerQuest(World.QuestByID(id));
                    playerQuest.IsCompleted = isCompleted;
 
                    player.Quests.Add(playerQuest);
                }
 
                return player;
            }
            catch
            {
                // If there was an error with the XML data, return a default player object
                return Player.CreateDefaultPlayer();
            }
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            return location.ItemRequiredToEnter == null || Inventory.Exists(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
            // See if the player has the required item in their inventory
        }

        public bool HasThisQuest(Quest quest)
        {
            return Quests.Exists(pq => pq.Details.ID == quest.ID);
        }

        public bool CompletedThisQuest(Quest quest)
        {
            return Quests.Exists(pq => pq.Details.ID == quest.ID && pq.IsCompleted);
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (var qci in quest.QuestCompletionItems)
                // Check each item in the player's inventory, to see if they have it, and enough of it
                if (!Inventory.Exists(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity))
                    return false;
            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (var qci in quest.QuestCompletionItems)
            {
                var item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);
                if (item != null)
                    // Subtract the quantity from the player's inventory that was needed to complete the quest
                    item.Quantity -= qci.Quantity;
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            var item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);
            if (item == null)
                // They didn't have the item, so add it to their inventory, with a quantity of 1
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            else
                // They have the item in their inventory, so increase the quantity by one
                item.Quantity++;
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list
            var playerQuest = Quests.SingleOrDefault(pq => pq.Details.ID == quest.ID);
            if (playerQuest != null)
                playerQuest.IsCompleted = true;
        }

        public string ToXmlString()
        {
            var playerData = new XmlDocument();

            // Create the top-level XML node
            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);

            // Create the "Stats" child node to hold the other player statistics nodes
            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);

            // Create the child nodes for the "Stats" node
            XmlNode currentHitPoints = playerData.CreateElement("CurrentHitPoints");
            currentHitPoints.AppendChild(playerData.CreateTextNode(CurrentHitPoints.ToString()));
            stats.AppendChild(currentHitPoints);

            XmlNode maximumHitPoints = playerData.CreateElement("MaximumHitPoints");
            maximumHitPoints.AppendChild(playerData.CreateTextNode(MaximumHitPoints.ToString()));
            stats.AppendChild(maximumHitPoints);

            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(Gold.ToString()));
            stats.AppendChild(gold);

            XmlNode experiencePoints = playerData.CreateElement("ExperiencePoints");
            experiencePoints.AppendChild(playerData.CreateTextNode(ExperiencePoints.ToString()));
            stats.AppendChild(experiencePoints);

            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(CurrentLocation.ID.ToString()));
            stats.AppendChild(currentLocation);

            // Create the "InventoryItems" child node to hold each InventoryItem node
            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);

            // Create an "InventoryItem" node for each item in the player's inventory
            foreach (var item in Inventory)
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");

                var idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Details.ID.ToString();
                inventoryItem.Attributes.Append(idAttribute);

                var quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                inventoryItem.Attributes.Append(quantityAttribute);

                inventoryItems.AppendChild(inventoryItem);
            }

            // Create the "PlayerQuests" child node to hold each PlayerQuest node
            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);

            // Create a "PlayerQuest" node for each quest the player has acquired
            foreach (var quest in Quests)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");

                var idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = quest.Details.ID.ToString();
                playerQuest.Attributes.Append(idAttribute);

                var isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = quest.IsCompleted.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);

                playerQuests.AppendChild(playerQuest);
            }

            return playerData.InnerXml; // The XML document, as a string, so we can save the data to disk
        }
    }
}