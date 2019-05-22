using System;
using System.Windows.Forms;

namespace GameForUlearnAttempt3
{
    public partial class TradingScreen : Form
    {
        public TradingScreen()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}