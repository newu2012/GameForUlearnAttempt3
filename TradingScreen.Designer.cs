using System.ComponentModel;

namespace GameForUlearnAttempt3
{
    partial class TradingScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.lblMyInventory = new System.Windows.Forms.Label();
            this.lblVendorInventory = new System.Windows.Forms.Label();
            this.dgvMyItems = new System.Windows.Forms.DataGridView();
            this.dgvVendorItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.dgvMyItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvVendorItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMyInventory
            // 
            this.lblMyInventory.Location = new System.Drawing.Point(15, 15);
            this.lblMyInventory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMyInventory.Name = "lblMyInventory";
            this.lblMyInventory.Size = new System.Drawing.Size(100, 23);
            this.lblMyInventory.TabIndex = 0;
            this.lblMyInventory.Text = "Инвентарь";
            // 
            // lblVendorInventory
            // 
            this.lblVendorInventory.Location = new System.Drawing.Point(440, 15);
            this.lblVendorInventory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorInventory.Name = "lblVendorInventory";
            this.lblVendorInventory.Size = new System.Drawing.Size(125, 15);
            this.lblVendorInventory.TabIndex = 1;
            this.lblVendorInventory.Text = "Торговец";
            // 
            // dgvMyItems
            // 
            this.dgvMyItems.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyItems.Location = new System.Drawing.Point(15, 42);
            this.dgvMyItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvMyItems.Name = "dgvMyItems";
            this.dgvMyItems.Size = new System.Drawing.Size(418, 220);
            this.dgvMyItems.TabIndex = 2;
            // 
            // dgvVendorItems
            // 
            this.dgvVendorItems.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorItems.Location = new System.Drawing.Point(440, 42);
            this.dgvVendorItems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvVendorItems.Name = "dgvVendorItems";
            this.dgvVendorItems.Size = new System.Drawing.Size(365, 220);
            this.dgvVendorItems.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(440, 265);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 50);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть окно торговли";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TradingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 320);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvVendorItems);
            this.Controls.Add(this.dgvMyItems);
            this.Controls.Add(this.lblVendorInventory);
            this.Controls.Add(this.lblMyInventory);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TradingScreen";
            this.Text = "Окно торговли";
            ((System.ComponentModel.ISupportInitialize) (this.dgvMyItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvVendorItems)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblVendorInventory;
        private System.Windows.Forms.DataGridView dgvMyItems;
        private System.Windows.Forms.DataGridView dgvVendorItems;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMyInventory;
    }
}