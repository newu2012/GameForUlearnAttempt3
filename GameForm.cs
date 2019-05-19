using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engine;
using System.IO;

namespace GameForUlearnAttempt3
{
    public partial class GameForm : Form
    {
        private Player player;
        private Monster currentMonster;
        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";
        
        public GameForm()
        {
            InitializeComponent();

            player = File.Exists(PLAYER_DATA_FILE_NAME) ? Player.CreatePlayerFromXmlString(File.ReadAllText(PLAYER_DATA_FILE_NAME)) : Player.CreateDefaultPlayer();
            
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            UpdatePlayerStats();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToWest);
        }
        
        private void rtbMessages_TextChanged(object sender, EventArgs e)
        {
            ScrollToBottomOfMessages();
        }
        
        private void ScrollToBottomOfMessages()
        {
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void MoveTo(Location newLocation)
        {
            //Does the location have any required items
            if (!player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location." + Environment.NewLine;
                return;
            }

            // Update the player's current location
            player.CurrentLocation = newLocation;

            // Show/hide available movement buttons
            btnNorth.Enabled = newLocation.LocationToNorth != null;
            btnEast.Enabled = newLocation.LocationToEast != null;
            btnSouth.Enabled = newLocation.LocationToSouth != null;
            btnWest.Enabled = newLocation.LocationToWest != null;

            // Display current location name and description
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            // Completely heal the player
            player.CurrentHitPoints = player.MaximumHitPoints;

            // Update Hit Points in UI
            lblHitPoints.Text = player.CurrentHitPoints.ToString();

            // Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                // See if the player already has the quest, and if they've completed it
                var playerAlreadyHasQuest = player.HasThisQuest(newLocation.QuestAvailableHere);
                var playerAlreadyCompletedQuest = player.CompletedThisQuest(newLocation.QuestAvailableHere);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        var playerHasAllItemsToCompleteQuest = player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the '" + newLocation.QuestAvailableHere.Name + "' quest." + Environment.NewLine;

                            // Remove quest items from inventory
                            player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            // Give quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardExperiencePoints + " experience points" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold + " gold" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            // Add the reward item to the player's inventory
                            player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            // Mark the quest as completed
                            player.MarkQuestCompleted(newLocation.QuestAvailableHere);
                        }
                    }
                }
                else
                {
                    // Display the messages
                    rtbMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    foreach (var qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                            rtbMessages.Text += qci.Quantity + " " + qci.Details.Name + Environment.NewLine;
                        else
                            rtbMessages.Text += qci.Quantity + " " + qci.Details.NamePlural + Environment.NewLine;
                    }
                    rtbMessages.Text += Environment.NewLine;

                    // Add the quest to the player's quest list
                    player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }

            // Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += "You see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;

                // Make a new monster, using the values from the standard monster in the World.Monster list
                var standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
                    standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                foreach (var lootItem in standardMonster.LootTable)
                    currentMonster.LootTable.Add(lootItem);

                cboWeapons.Enabled = true;
                cboPotions.Enabled = true;
                btnUseWeapon.Enabled = true;
                btnUsePotion.Enabled = true;
            }
            else
            {
                currentMonster = null;

                cboWeapons.Enabled = false;
                cboPotions.Enabled = false;
                btnUseWeapon.Enabled = false;
                btnUsePotion.Enabled = false;
            }

            // Refresh player's inventory list
            UpdateInventoryListInUI();

            // Refresh player's quest list
            UpdateQuestListInUI();

            // Refresh player's weapons combobox
            UpdateWeaponListInUI();

            // Refresh player's potions combobox
            UpdatePotionListInUI();
        }
        
        private void UpdatePlayerStats()
        {
            // Refresh player information and inventory controls
            lblHitPoints.Text = player.CurrentHitPoints.ToString();
            lblGold.Text = player.Gold.ToString();
            lblExperience.Text = player.ExperiencePoints.ToString();
            lblLevel.Text = player.Level.ToString();
        }

        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";

            dgvInventory.Rows.Clear();

            foreach (var inventoryItem in player.Inventory)
                if (inventoryItem.Quantity > 0)
                    dgvInventory.Rows.Add(inventoryItem.Details.Name, inventoryItem.Quantity.ToString());
        }

        private void UpdateQuestListInUI()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "State";

            dgvQuests.Rows.Clear();

            foreach (var playerQuest in player.Quests)
                dgvQuests.Rows.Add(playerQuest.Details.Name, playerQuest.IsCompleted.ToString());
        }

        private void UpdateWeaponListInUI()
        {
            var weapons = new List<Weapon>();

            foreach (var inventoryItem in player.Inventory)
                if (inventoryItem.Details is Weapon)
                    if (inventoryItem.Quantity > 0)
                        weapons.Add((Weapon)inventoryItem.Details);

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.SelectedIndexChanged -= cboWeapons_SelectedIndexChanged;
                cboWeapons.DataSource = weapons;
                cboWeapons.SelectedIndexChanged += cboWeapons_SelectedIndexChanged;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";
 
                if (player.CurrentWeapon != null)
                    cboWeapons.SelectedItem = player.CurrentWeapon;
                else
                    cboWeapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            var healingPotions = new List<HealingPotion>();

            foreach(var inventoryItem in player.Inventory)
                if(inventoryItem.Details is HealingPotion)
                    if(inventoryItem.Quantity > 0)
                        healingPotions.Add((HealingPotion)inventoryItem.Details);

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPotions.Enabled = false;
                btnUsePotion.Enabled = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            var currentWeapon = (Weapon) cboWeapons.SelectedItem;

            // Determine the amount of damage to do to the monster
            var damageToMonster =
                RandomNumberGenerator.NumberBetween(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);

            // Apply the damage to the monster's CurrentHitPoints
            currentMonster.CurrentHitPoints -= damageToMonster;

            // Display message
            rtbMessages.Text += "You hit the " + currentMonster.Name + " for " + damageToMonster +
                                " points." + Environment.NewLine;

            // Check if the monster is dead
            if (currentMonster.CurrentHitPoints <= 0)
            {
                // Monster is dead
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated the " + currentMonster.Name + Environment.NewLine;

                // Give player experience points for killing the monster
                player.ExperiencePoints += currentMonster.RewardExperiencePoints;
                rtbMessages.Text += "You receive " + currentMonster.RewardExperiencePoints +
                                    " experience points" + Environment.NewLine;

                // Give player gold for killing the monster 
                player.Gold += currentMonster.RewardGold;
                rtbMessages.Text += "You receive " + currentMonster.RewardGold + " gold" +
                                    Environment.NewLine;

                // Get random loot items from the monster
                var lootedItems = new List<InventoryItem>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (var lootItem in currentMonster.LootTable)
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));

                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                    foreach (var lootItem in currentMonster.LootTable)
                        if (lootItem.IsDefaultItem)
                            lootedItems.Add(new InventoryItem(lootItem.Details, 1));

                // Add the looted items to the player's inventory
                foreach (var inventoryItem in lootedItems)
                {
                    player.AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity + " " +
                                            inventoryItem.Details.Name + Environment.NewLine;
                    else
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity + " " +
                                            inventoryItem.Details.NamePlural + Environment.NewLine;
                }

                // Refresh player information and inventory controls
                lblHitPoints.Text = player.CurrentHitPoints.ToString();
                lblGold.Text = player.Gold.ToString();
                lblExperience.Text = player.ExperiencePoints.ToString();
                lblLevel.Text = player.Level.ToString();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                // Add a blank line to the messages box, just for appearance.
                rtbMessages.Text += Environment.NewLine;

                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(player.CurrentLocation);
            }
            else
            {
                // Determine the amount of damage the monster does to the player
                var damageToPlayer = RandomNumberGenerator.NumberBetween(0, currentMonster.MaximumDamage);

                // Display message
                rtbMessages.Text += "The " + currentMonster.Name + " did " + damageToPlayer +
                                    " points of damage." + Environment.NewLine;

                // Subtract damage from player
                player.CurrentHitPoints -= damageToPlayer;

                // Refresh player data in UI
                lblHitPoints.Text = player.CurrentHitPoints.ToString();

                if (player.CurrentHitPoints <= 0)
                {
                    // Display message
                    rtbMessages.Text += "The " + currentMonster.Name + " killed you." + Environment.NewLine;

                    // Move player to "Home"
                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }
            }
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            var potion = (HealingPotion)cboPotions.SelectedItem;

            // Add healing amount to the player's current hit points
            player.CurrentHitPoints += potion.AmountToHeal;

            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (player.CurrentHitPoints > player.MaximumHitPoints)
                player.CurrentHitPoints = player.MaximumHitPoints;

            // Remove the potion from the player's inventory
            foreach (var ii in player.Inventory)
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            
            // Display message
            rtbMessages.Text += "You drink a " + potion.Name + Environment.NewLine;

            // Monster gets their turn to attack

            // Determine the amount of damage the monster does to the player
            var damageToPlayer = RandomNumberGenerator.NumberBetween(0, currentMonster.MaximumDamage);

            // Display message
            rtbMessages.Text += "The " + currentMonster.Name + " did " + damageToPlayer + " points of damage." + Environment.NewLine;

            // Subtract damage from player
            player.CurrentHitPoints -= damageToPlayer;

            if (player.CurrentHitPoints <= 0)
            {
                // Display message
                rtbMessages.Text += "The " + currentMonster.Name + " killed you." + Environment.NewLine;

                // Move player to "Home"
                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            }

            // Refresh player data in UI
            lblHitPoints.Text = player.CurrentHitPoints.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
        }
        
        private void cboWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            player.CurrentWeapon = (Weapon)cboWeapons.SelectedItem;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(PLAYER_DATA_FILE_NAME, player.ToXmlString());
        }
    }
}