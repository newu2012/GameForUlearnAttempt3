using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;

namespace Engine
{
    public class Player : LivingCreature
    {
        private int _gold;
        private int _experiencePoints;
        private Location _currentLocation;

        public event EventHandler<MessageEventArgs> OnMessage;

        public int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public int ExperiencePoints
        {
            get => _experiencePoints;
            private set
            {
                _experiencePoints = value;
                OnPropertyChanged("ExperiencePoints");
                OnPropertyChanged("Level");
            }
        }

        public int Level => ExperiencePoints / 100 + 1;

        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                OnPropertyChanged("CurrentLocation");
            }
        }

        public Weapon CurrentWeapon { get; set; }

        public BindingList<InventoryItem> Inventory { get; set; }

        public List<Weapon> Weapons
        {
            get { return Inventory.Where(x => x.Details is Weapon).Select(x => x.Details as Weapon).ToList(); }
        }

        public List<Potion> Potions
        {
            get { return Inventory.Where(x => x.Details is Potion).Select(x => x.Details as Potion).ToList(); }
        }

        public BindingList<PlayerQuest> Quests { get; set; }

        public List<int> LocationsVisited { get; set; }

        private Monster CurrentMonster { get; set; }

        private Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;

            Inventory = new BindingList<InventoryItem>();
            Quests = new BindingList<PlayerQuest>();
            LocationsVisited = new List<int>();
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

                if (playerData.SelectSingleNode("/Player/Stats/CurrentWeapon") != null)
                {
                    var currentWeaponID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentWeapon").InnerText);
                    player.CurrentWeapon = (Weapon)World.ItemByID(currentWeaponID);
                }
                
                foreach (XmlNode node in playerData.SelectNodes("/Player/LocationsVisited/LocationVisited"))
                {
                    var id = Convert.ToInt32(node.Attributes["ID"].Value);
                    player.LocationsVisited.Add(id);
                }

                foreach (XmlNode node in playerData.SelectNodes("/Player/InventoryItems/InventoryItem"))
                {
                    var id = Convert.ToInt32(node.Attributes["ID"].Value);
                    var quantity = Convert.ToInt32(node.Attributes["Quantity"].Value);
                    for (var i = 0; i < quantity; i++)
                        player.AddItemToInventory(World.ItemByID(id));
                }

                foreach (XmlNode node in playerData.SelectNodes("/Player/PlayerQuests/PlayerQuest"))
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
                return CreateDefaultPlayer();
            }
        }

        public void MoveTo(Location location)
        {
            if (PlayerDoesNotHaveTheRequiredItemToEnter(location))
            {
                RaiseMessage("Вам нужно иметь " + location.ItemRequiredToEnter.Name + " чтобы пройти в эту локацию..");
                RaiseMessage("");
                return;
            }

            CurrentLocation = location;

            if (!LocationsVisited.Contains(CurrentLocation.ID))
                LocationsVisited.Add(CurrentLocation.ID);

            CompletelyHeal();

            if (location.HasAQuest)
                foreach (var e in location.QuestsAvailableHere)
                {
                    if (PlayerDoesNotHaveThisQuest(e))
                        if (PlayerCompletedPreviousQuest(e))
                            GiveQuestToPlayer(e);

                    if (PlayerHasNotCompletedQuest(e) &&
                        PlayerHasAllQuestCompletionItemsFor(e))
                        GivePlayerQuestRewards(e);
                }
            SetTheCurrentMonsterForTheCurrentLocation(location);
        }

        public void MoveNorth()
        {
            if (CurrentLocation.LocationToNorth != null)
                MoveTo(CurrentLocation.LocationToNorth);
        }

        public void MoveEast()
        {
            if (CurrentLocation.LocationToEast != null)
                MoveTo(CurrentLocation.LocationToEast);
        }

        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
                MoveTo(CurrentLocation.LocationToSouth);
        }

        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
                MoveTo(CurrentLocation.LocationToWest);
        }

        public void UseWeapon(Weapon weapon)
        {
            var damage = RandomNumberGenerator.NumberBetween(weapon.MinimumDamage, weapon.MaximumDamage);

            if (damage == 0)
                RaiseMessage("Вы промахнулись по " + CurrentMonster.Name);
            else
            {
                CurrentMonster.CurrentHitPoints -= damage;
                RaiseMessage("Вы попали по " + CurrentMonster.Name + " нанеся " + damage + " урона.");
            }

            if (CurrentMonster.IsDead)
            {
                LootTheCurrentMonster();
                MoveTo(CurrentLocation);
            }
            else
                LetTheMonsterAttack();
        }

        private void LootTheCurrentMonster()
        {
            RaiseMessage("");
            RaiseMessage("Вы победили " + CurrentMonster.Name);
            RaiseMessage("Вы получили " + CurrentMonster.RewardExperiencePoints + " опыта");
            RaiseMessage("Вы получили " + CurrentMonster.RewardGold + " золота");

            AddExperiencePoints(CurrentMonster.RewardExperiencePoints);
            Gold += CurrentMonster.RewardGold;

            foreach (var inventoryItem in CurrentMonster.LootItems)
            {
                AddItemToInventory(inventoryItem.Details);
                RaiseMessage(string.Format("Вы получили {0} {1}", inventoryItem.Quantity, inventoryItem.Description));
            }

            RaiseMessage("");
        }

        public void UsePotion(Potion potion)
        {
            if (potion is HealingPotion)
                HealPlayer(((HealingPotion) potion).AmountToHeal);
            else AddExperiencePoints(((ExperiencePotion) potion).AmountToAdd);
            RaiseMessage("Вы выпили " + potion.Name);
            
            RemoveItemFromInventory(potion);
        }

        public void AddItemToInventory(Item itemToAdd, int quantity = 1)
        {
            var existingItemInInventory = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);

            if (existingItemInInventory == null)
                Inventory.Add(new InventoryItem(itemToAdd, quantity));
            else
                existingItemInInventory.Quantity += quantity;

            RaiseInventoryChangedEvent(itemToAdd);
        }

        public void RemoveItemFromInventory(Item itemToRemove, int quantity = 1)
        {
            var item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToRemove.ID && ii.Quantity >= quantity);

            if (item != null)
            {
                item.Quantity -= quantity;

                if (item.Quantity == 0)
                    Inventory.Remove(item);

                RaiseInventoryChangedEvent(itemToRemove);
            }
        }

        public string ToXmlString()
        {
            var playerData = new XmlDocument();

            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);

            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);

            CreateNewChildXmlNode(playerData, stats, "CurrentHitPoints", CurrentHitPoints);
            CreateNewChildXmlNode(playerData, stats, "MaximumHitPoints", MaximumHitPoints);
            CreateNewChildXmlNode(playerData, stats, "Gold", Gold);
            CreateNewChildXmlNode(playerData, stats, "ExperiencePoints", ExperiencePoints);
            CreateNewChildXmlNode(playerData, stats, "CurrentLocation", CurrentLocation.ID);

            if (CurrentWeapon != null)
                CreateNewChildXmlNode(playerData, stats, "CurrentWeapon", CurrentWeapon.ID);

            XmlNode locationsVisited = playerData.CreateElement("LocationsVisited");
            player.AppendChild(locationsVisited);

            foreach (var locationID in LocationsVisited)
            {
                XmlNode locationVisited = playerData.CreateElement("LocationVisited");
                AddXmlAttributeToNode(playerData, locationVisited, "ID", locationID);
                locationsVisited.AppendChild(locationVisited);
            }

            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);

            foreach (var item in Inventory)
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");
                AddXmlAttributeToNode(playerData, inventoryItem, "ID", item.Details.ID);
                AddXmlAttributeToNode(playerData, inventoryItem, "Quantity", item.Quantity);
                inventoryItems.AppendChild(inventoryItem);
            }

            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);

            foreach (var quest in Quests)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");
                AddXmlAttributeToNode(playerData, playerQuest, "ID", quest.Details.ID);
                AddXmlAttributeToNode(playerData, playerQuest, "IsCompleted", quest.IsCompleted);
                playerQuests.AppendChild(playerQuest);
            }
            return playerData.InnerXml;
        }

        private bool HasRequiredItemToEnterThisLocation(Location location)
        {
            return location.DoesNotHaveAnItemRequiredToEnter || Inventory.Any(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
        }

        private void SetTheCurrentMonsterForTheCurrentLocation(Location location)
        {
            CurrentMonster = location.NewInstanceOfMonsterLivingHere();
            if (CurrentMonster != null)
                RaiseMessage("Вы видите " + CurrentMonster.Name);
        }

        private bool PlayerDoesNotHaveTheRequiredItemToEnter(Location location)
        {
            return !HasRequiredItemToEnterThisLocation(location);
        }

        private bool PlayerDoesNotHaveThisQuest(Quest quest)
        {
            return Quests.All(pq => pq.Details.ID != quest.ID);
        }

        private bool PlayerHasNotCompletedQuest(Quest quest)
        {
            return Quests.Any(pq => pq.Details.ID == quest.ID && !pq.IsCompleted);
        }

        private bool PlayerCompletedPreviousQuest(Quest quest)
        {
            if (quest.PreviousQuest == null)
                return true;
            if (Quests.Count != 0 && Quests.Any(pq => pq.Details == quest.PreviousQuest && pq.IsCompleted)) return true;
            
//            RaiseMessage("Перед тем как взять этот квест завершите квест:\"" +
//                         quest.PreviousQuest.Name + "\"");
//            RaiseMessage("");
            return false;
        }
        
        private void GiveQuestToPlayer(Quest quest)
        {
            RaiseMessage("Вы получили квест " + quest.Name);
            RaiseMessage(quest.Description);
            RaiseMessage("Чтобы завершить этот квест вернитесь с:");

            foreach (var qci in quest.QuestCompletionItems)
                RaiseMessage(string.Format("{0} {1}", qci.Quantity,
                    qci.Quantity == 1 ? qci.Details.Name : qci.Details.NamePlural));

            RaiseMessage("");
            Quests.Add(new PlayerQuest(quest));
        }

        private bool PlayerHasAllQuestCompletionItemsFor(Quest quest)
        {
            foreach (var qci in quest.QuestCompletionItems)
                if (!Inventory.Any(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity))
                    return false;
            return true;
        }

        private void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (var qci in quest.QuestCompletionItems)
            {
                var item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);
                if (item != null)
                    RemoveItemFromInventory(item.Details, qci.Quantity);
            }
        }

        private void AddExperiencePoints(int experiencePointsToAdd)
        {
            ExperiencePoints += experiencePointsToAdd;
            MaximumHitPoints = Level * 10;
        }

        private void GivePlayerQuestRewards(Quest quest)
        {
            RaiseMessage("");
            RaiseMessage("Вы завершили квест '" + quest.Name + "'.");
            RaiseMessage("Вы получили: ");
            RaiseMessage(quest.RewardExperiencePoints + " опыта");
            RaiseMessage(quest.RewardGold + " золота");
            foreach (var e in quest.RewardItems)
                RaiseMessage(e.Details.Name, true);
            RaiseMessage("");

            AddExperiencePoints(quest.RewardExperiencePoints);
            Gold += quest.RewardGold;

            RemoveQuestCompletionItems(quest);
            foreach (var e in quest.RewardItems)
                for (var i = 0; i < e.Quantity; i++)
                    AddItemToInventory(e.Details);

            MarkPlayerQuestCompleted(quest);
        }

        private void MarkPlayerQuestCompleted(Quest quest)
        {
            var playerQuest = Quests.SingleOrDefault(pq => pq.Details.ID == quest.ID);
            if (playerQuest != null)
                playerQuest.IsCompleted = true;
        }

        private void LetTheMonsterAttack()
        {
            var damageToPlayer = RandomNumberGenerator.NumberBetween(0, CurrentMonster.MaximumDamage);
            RaiseMessage(CurrentMonster.Name + " нанёс " + damageToPlayer + " урона.");
            CurrentHitPoints -= damageToPlayer;

            if (IsDead)
            {
                RaiseMessage(CurrentMonster.Name + " убил тебя.");
                RaiseMessage("");
                MoveHome();
            }
        }

        private void HealPlayer(int hitPointsToHeal)
        {
            CurrentHitPoints = Math.Min(CurrentHitPoints + hitPointsToHeal, MaximumHitPoints);
        }

        private void CompletelyHeal()
        {
            CurrentHitPoints = MaximumHitPoints;
        }

        private void MoveHome()
        {
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
        }

        private void CreateNewChildXmlNode(XmlDocument document, XmlNode parentNode, string elementName, object value)
        {
            XmlNode node = document.CreateElement(elementName);
            node.AppendChild(document.CreateTextNode(value.ToString()));
            parentNode.AppendChild(node);
        }

        private void AddXmlAttributeToNode(XmlDocument document, XmlNode node, string attributeName, object value)
        {
            var attribute = document.CreateAttribute(attributeName);
            attribute.Value = value.ToString();
            node.Attributes.Append(attribute);
        }

        private void RaiseInventoryChangedEvent(Item item)
        {
            if (item is Weapon)
                OnPropertyChanged("Weapons");

            if (item is Potion)
                OnPropertyChanged("Potions");
        }

        private void RaiseMessage(string message, bool addExtraNewLine = false)
        {
            OnMessage?.Invoke(this, new MessageEventArgs(message, addExtraNewLine));
        }
    }
}