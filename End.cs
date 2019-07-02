using System;
using System.Windows.Forms;
using Engine;

namespace GameForUlearnAttempt3
{
    public partial class End : Form
    {
        public End()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnFormClosed(new FormClosedEventArgs(CloseReason.UserClosing));
                Application.Exit();
        }

        private void End_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}