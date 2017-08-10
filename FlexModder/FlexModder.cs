using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlexModder
{
    public partial class MainFormWindow : Form
    {
        public MainFormWindow()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ModSummaryListViewBox.Columns.Add("Name", 200);
            ModSummaryListViewBox.Columns.Add("Type", 60);
        }

        private void ModSummaryListViewBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddToModTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AddToModTextBox.Text.Contains("AddBlock"))
            {
                ObjectTypeTextBox.Text = "Block";
            }
            else if (AddToModTextBox.Text.Contains("AddSword"))
            {
                ObjectTypeTextBox.Text = "Sword";
            }
            else if (AddToModTextBox.Text.Contains("AddBow"))
            {
                ObjectTypeTextBox.Text = "Bow";
            }
            else {
                ObjectTypeTextBox.Text = "Unknown";
            }
        }
    }
}
