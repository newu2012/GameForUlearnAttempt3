namespace GameForUlearnAttempt3
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.lblSelectedWeapon = new System.Windows.Forms.Label();
            this.lblSelectedPotion = new System.Windows.Forms.Label();
            this.btnTrade = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.lblMaxHP = new System.Windows.Forms.Label();
            this.lblMaxHitPoints = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Здоровье:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Золото:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Очки опыта:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Уровень:";
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.Location = new System.Drawing.Point(110, 18);
            this.lblHitPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(100, 23);
            this.lblHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            this.lblGold.Location = new System.Drawing.Point(110, 45);
            this.lblGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(100, 23);
            this.lblGold.TabIndex = 5;
            // 
            // lblExperience
            // 
            this.lblExperience.Location = new System.Drawing.Point(110, 73);
            this.lblExperience.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(100, 23);
            this.lblExperience.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.Location = new System.Drawing.Point(110, 99);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(100, 23);
            this.lblLevel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(617, 531);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Выбор действия";
            // 
            // cboWeapons
            // 
            this.cboWeapons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeapons.Location = new System.Drawing.Point(463, 558);
            this.cboWeapons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(150, 23);
            this.cboWeapons.TabIndex = 9;
            // 
            // cboPotions
            // 
            this.cboPotions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(463, 593);
            this.cboPotions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(150, 23);
            this.cboPotions.TabIndex = 10;
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(620, 558);
            this.btnUseWeapon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(85, 23);
            this.btnUseWeapon.TabIndex = 11;
            this.btnUseWeapon.Text = "Атаковать";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.Location = new System.Drawing.Point(620, 593);
            this.btnUsePotion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(85, 23);
            this.btnUsePotion.TabIndex = 12;
            this.btnUsePotion.Text = "Зелье";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.Location = new System.Drawing.Point(415, 420);
            this.btnNorth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(75, 40);
            this.btnNorth.TabIndex = 13;
            this.btnNorth.Text = "Север";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(415, 500);
            this.btnSouth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(75, 40);
            this.btnSouth.TabIndex = 14;
            this.btnSouth.Text = "Юг";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(490, 460);
            this.btnEast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(75, 40);
            this.btnEast.TabIndex = 15;
            this.btnEast.Text = "Восток";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(340, 460);
            this.btnWest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(75, 40);
            this.btnWest.TabIndex = 16;
            this.btnWest.Text = "Запад";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // rtbLocation
            // 
            this.rtbLocation.Location = new System.Drawing.Point(346, 18);
            this.rtbLocation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.Size = new System.Drawing.Size(360, 106);
            this.rtbLocation.TabIndex = 17;
            this.rtbLocation.Text = "";
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(346, 130);
            this.rtbMessages.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(360, 286);
            this.rtbMessages.TabIndex = 18;
            this.rtbMessages.Text = "";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.Location = new System.Drawing.Point(10, 130);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.Size = new System.Drawing.Size(320, 309);
            this.dgvInventory.TabIndex = 19;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Location = new System.Drawing.Point(10, 447);
            this.dgvQuests.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.Size = new System.Drawing.Size(320, 200);
            this.dgvQuests.TabIndex = 20;
            // 
            // lblSelectedWeapon
            // 
            this.lblSelectedWeapon.Location = new System.Drawing.Point(335, 558);
            this.lblSelectedWeapon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedWeapon.Name = "lblSelectedWeapon";
            this.lblSelectedWeapon.Size = new System.Drawing.Size(125, 23);
            this.lblSelectedWeapon.TabIndex = 21;
            this.lblSelectedWeapon.Text = "Выбранное оружие";
            // 
            // lblSelectedPotion
            // 
            this.lblSelectedPotion.Location = new System.Drawing.Point(335, 593);
            this.lblSelectedPotion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedPotion.Name = "lblSelectedPotion";
            this.lblSelectedPotion.Size = new System.Drawing.Size(125, 23);
            this.lblSelectedPotion.TabIndex = 22;
            this.lblSelectedPotion.Text = "Выбранное зелье";
            // 
            // btnTrade
            // 
            this.btnTrade.Location = new System.Drawing.Point(620, 620);
            this.btnTrade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(85, 23);
            this.btnTrade.TabIndex = 21;
            this.btnTrade.Text = "Торговля";
            this.btnTrade.UseVisualStyleBackColor = true;
            this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(415, 460);
            this.btnMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 40);
            this.btnMap.TabIndex = 23;
            this.btnMap.Text = "Карта";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // lblMaxHP
            // 
            this.lblMaxHP.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxHP.Location = new System.Drawing.Point(150, 18);
            this.lblMaxHP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxHP.Name = "lblMaxHP";
            this.lblMaxHP.Size = new System.Drawing.Size(100, 23);
            this.lblMaxHP.TabIndex = 24;
            this.lblMaxHP.Text = "Из";
            // 
            // lblMaxHitPoints
            // 
            this.lblMaxHitPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxHitPoints.Location = new System.Drawing.Point(172, 18);
            this.lblMaxHitPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxHitPoints.Name = "lblMaxHitPoints";
            this.lblMaxHitPoints.Size = new System.Drawing.Size(100, 23);
            this.lblMaxHitPoints.TabIndex = 25;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 651);
            this.Controls.Add(this.lblMaxHitPoints);
            this.Controls.Add(this.lblMaxHP);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.btnTrade);
            this.Controls.Add(this.lblSelectedPotion);
            this.Controls.Add(this.lblSelectedWeapon);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GameForm";
            this.Text = "Типо игра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize) (this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvQuests)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHitPoints;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.Label lblSelectedWeapon;
        private System.Windows.Forms.Label lblSelectedPotion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Label lblMaxHP;
        private System.Windows.Forms.Label lblMaxHitPoints;
        private System.Windows.Forms.Button btnTrade;
    }
}