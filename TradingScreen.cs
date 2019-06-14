using System;
using System.Windows.Forms;
using Engine;

namespace GameForUlearnAttempt3
{
    public partial class TradingScreen : Form
    {
        private Player _currentPlayer;

        public TradingScreen(Player player)
        {
            _currentPlayer = player;
            InitializeComponent();

            var rightAlignedCellStyle = new DataGridViewCellStyle();
            rightAlignedCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMyItems.RowHeadersVisible = false;
            dgvMyItems.AutoGenerateColumns = false;

            dgvMyItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ItemID",
                Visible = false
            });

            dgvMyItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Название",
                Width = 145,
                DataPropertyName = "Description"
            });

            dgvMyItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "К-во",
                Width = 30,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = "Quantity"
            });

            dgvMyItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Цена",
                Width = 35,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = "Price"
            });

            dgvMyItems.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Продать 1",
                UseColumnTextForButtonValue = true,
                Width = 65,
                DataPropertyName = "ItemID"
            });

            dgvMyItems.DataSource = _currentPlayer.Inventory;

            dgvMyItems.CellClick += dgvMyItems_CellClick;

            dgvVendorItems.RowHeadersVisible = false;
            dgvVendorItems.AutoGenerateColumns = false;

            dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ItemID",
                Visible = false
            });

            dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Название",
                Width = 135,
                DataPropertyName = "Description"
            });

            dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Цена",
                Width = 35,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = "Price"
            });

            dgvVendorItems.Columns.Add(new DataGridViewButtonColumn
            {
                Text = "Купить 1",
                UseColumnTextForButtonValue = true,
                Width = 65,
                DataPropertyName = "ItemID"
            });

            dgvVendorItems.DataSource = _currentPlayer.CurrentLocation.VendorWorkingHere.Inventory;
            dgvVendorItems.CellClick += dgvVendorItems_CellClick;
        }

        private void dgvMyItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var itemID = dgvMyItems.Rows[e.RowIndex].Cells[0].Value;
                var itemBeingSold = World.ItemByID(Convert.ToInt32(itemID));

                if (itemBeingSold.Price == World.UNSELLABLE_ITEM_PRICE)
                    MessageBox.Show("Вы не можете продать " + itemBeingSold.Name);
                else
                {
                    _currentPlayer.RemoveItemFromInventory(itemBeingSold);
                    _currentPlayer.Gold += itemBeingSold.Price;
                }
            }
        }

        private void dgvVendorItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var itemID = dgvVendorItems.Rows[e.RowIndex].Cells[0].Value;
                var itemBeingBought = World.ItemByID(Convert.ToInt32(itemID));

                if (_currentPlayer.Gold >= itemBeingBought.Price)
                {
                    _currentPlayer.AddItemToInventory(itemBeingBought);
                    _currentPlayer.Gold -= itemBeingBought.Price;
                }
                else
                    MessageBox.Show("У вас недостаточно золота чтобы купить " + itemBeingBought.Name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}