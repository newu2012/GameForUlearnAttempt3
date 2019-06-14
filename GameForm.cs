using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Engine;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace GameForUlearnAttempt3
{
    public partial class GameForm : Form
    {
        private Player _player;
        private const string PlayerDataFileName = "PlayerData.xml";

        public GameForm()
        {
            KeyPreview = true;
            
            InitializeComponent();
            
            KeyDown+= OnKeyDown;
            
            _player = File.Exists(PlayerDataFileName) 
                ? Player.CreatePlayerFromXmlString(File.ReadAllText(PlayerDataFileName)) 
                : Player.CreateDefaultPlayer();

            lblHitPoints.DataBindings.Add("Text", _player, "CurrentHitPoints");
            lblGold.DataBindings.Add("Text", _player, "Gold");
            lblExperience.DataBindings.Add("Text", _player, "ExperiencePoints");
            lblLevel.DataBindings.Add("Text", _player, "Level");

            dgvInventory.RowHeadersVisible = false;
            dgvInventory.AutoGenerateColumns = false;

            dgvInventory.DataSource = _player.Inventory;

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Название предмета",
                Width = 197,
                DataPropertyName = "Description"
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Количество",
                DataPropertyName = "Quantity"
            });

            dgvInventory.ScrollBars = ScrollBars.Vertical;

            dgvQuests.RowHeadersVisible = false;
            dgvQuests.AutoGenerateColumns = false;

            dgvQuests.DataSource = _player.Quests;

            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Название квеста",
                Width = 197,
                DataPropertyName = "Name"
            });

            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Готовность",
                DataPropertyName = "IsCompleted"
            });

            cboWeapons.DataSource = _player.Weapons;
            cboWeapons.DisplayMember = "Name";
            cboWeapons.ValueMember = "Id";

            if (_player.CurrentWeapon != null)
                cboWeapons.SelectedItem = _player.CurrentWeapon;

            cboWeapons.SelectedIndexChanged += cboWeapons_SelectedIndexChanged;

            cboPotions.DataSource = _player.Potions;
            cboPotions.DisplayMember = "Name";
            cboPotions.ValueMember = "Id";

            _player.PropertyChanged += PlayerOnPropertyChanged;
            _player.OnMessage += DisplayMessage;

            _player.MoveTo(_player.CurrentLocation);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    _player.MoveNorth();
                    break;
                case Keys.Right:
                case Keys.D:
                    _player.MoveEast();
                    break;
                case Keys.Down:
                case Keys.S:
                    _player.MoveSouth();
                    break;
                case Keys.Left:
                case Keys.A:
                    _player.MoveWest();
                    break;
            }
        }

        private void DisplayMessage(object sender, MessageEventArgs messageEventArgs)
        {
            rtbMessages.Text += messageEventArgs.Message + Environment.NewLine;

            if (messageEventArgs.AddExtraNewLine)
                rtbMessages.Text += Environment.NewLine;

            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void PlayerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "Weapons")
            {
                var currentWeapon = cboWeapons.SelectedItem;
                cboWeapons.DataSource = _player.Weapons;
                if (_player.Weapons.Contains(currentWeapon))
                    cboWeapons.SelectedItem = currentWeapon;
                if (!_player.Weapons.Any())
                {
                    cboWeapons.Enabled = false;
                    btnUseWeapon.Enabled = false;
                }
            }

            if (propertyChangedEventArgs.PropertyName == "Potions")
            {
                cboPotions.DataSource = _player.Potions;
                if (!_player.Potions.Any())
                {
                    cboPotions.Enabled = false;
                    btnUsePotion.Enabled = false;
                }
            }

            if (propertyChangedEventArgs.PropertyName == "CurrentLocation")
            {
                btnNorth.Enabled = _player.CurrentLocation.LocationToNorth != null;
                btnEast.Enabled = _player.CurrentLocation.LocationToEast != null;
                btnSouth.Enabled = _player.CurrentLocation.LocationToSouth != null;
                btnWest.Enabled = _player.CurrentLocation.LocationToWest != null;

                btnTrade.Enabled = _player.CurrentLocation.VendorWorkingHere != null;

                rtbLocation.Text = _player.CurrentLocation.Name + Environment.NewLine;
                rtbLocation.Text += _player.CurrentLocation.Description + Environment.NewLine;

                
                btnUseWeapon.Enabled = _player.Weapons.Any();
                btnUsePotion.Enabled = _player.Potions.Any();
                cboPotions.Enabled = _player.Potions.Any();

                btnUseWeapon.Enabled = _player.CurrentLocation.HasAMonster && _player.Weapons.Any();
            }
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            _player.MoveNorth();
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            _player.MoveEast();
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            _player.MoveSouth();
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            _player.MoveWest();
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            var currentWeapon = (Weapon)cboWeapons.SelectedItem;
            _player.UseWeapon(currentWeapon);
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            var potion = (Potion)cboPotions.SelectedItem;
            _player.UsePotion(potion);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(PlayerDataFileName, _player.ToXmlString());
        }

        private void cboWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            _player.CurrentWeapon = (Weapon)cboWeapons.SelectedItem;
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            var tradingScreen = new TradingScreen(_player);
            tradingScreen.StartPosition = FormStartPosition.CenterParent;
            tradingScreen.ShowDialog(this);
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            var mapScreen = new WorldMap(_player);
            mapScreen.StartPosition = FormStartPosition.CenterParent;
            mapScreen.ShowDialog(this);
        }
    }
}