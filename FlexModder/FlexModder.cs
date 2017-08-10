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
        String[] argsArr;
        List<ModObject> modObjList = new List<ModObject>();

        public MainFormWindow()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateModSummary();
        }

        private void PopulateModSummary()
        {
            modObjList.Add(new ModObject("Waffle Block", "Block"));
            modObjList.Add(new ModObject("Waffle Sword", "Sword"));
            String[] wbArr = { "Waffle Block", "Block" };
            String[] wsArr = { "Waffle Sword", "Sword" };
            ListViewItem waffleBlockLVI = new ListViewItem(wbArr);
            ListViewItem waffleSwordLVI = new ListViewItem(wsArr);
            waffleBlockLVI.Group = ModSummaryListViewBox.Groups[0];
            waffleSwordLVI.Group = ModSummaryListViewBox.Groups[1];
            ModSummaryListViewBox.Items.Add(waffleBlockLVI);
            ModSummaryListViewBox.Items.Add(waffleSwordLVI);
        }

        private void ModSummaryListViewBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddToModTextBox_TextChanged(object sender, EventArgs e)
        {
            String objType = "???";
            String objName = "???";
            String args = "";
            
            // Simple Check for Object Type
            if (AddToModTextBox.Text.Contains("AddBlock"))
            {
                objType = "Block";
            }
            else if (AddToModTextBox.Text.Contains("AddSword"))
            {
                objType = "Sword";
            }
            else if (AddToModTextBox.Text.Contains("AddBow"))
            {
                objType = "Bow";
            }
            else {
                objType = "???";
            }
            ObjectTypeTextBox.Text = objType;

            // Simple Check for Object Name
            if (AddToModTextBox.Text.Contains("Add" + objType + "("))
            {
                int argsStart = AddToModTextBox.Text.IndexOf("(") + 1;
                int argsEnd;
                if (AddToModTextBox.Text.Contains(")"))
                {
                    argsEnd = AddToModTextBox.Text.IndexOf(")");
                }
                else
                {
                    argsEnd = AddToModTextBox.Text.Length;
                }
                int argsLength = Math.Max(argsEnd - argsStart, 0);

                args = AddToModTextBox.Text.Substring(argsStart, argsLength);
                argsArr = args.Split(',');

                // Name Sanity Check
                if (argsArr[0] == "\"\"" || argsArr[0] == "")
                {
                    objName = "!!!";
                }
                else
                {
                    objName = argsArr[0].Replace("\"", string.Empty);
                }
            }
            else {
                objName = "???";
            }
            ObjectNameTextBox.Text = objName;

            CheckForAddObjectErrors();
            if (ErrorLabel.Text == "No Errors")
            {
                AddToModButton.Enabled = true;
            }
            else
            {
                AddToModButton.Enabled = false;
            }

        }

        private void CheckForAddObjectErrors()
        {

            if (!AddToModTextBox.Text.StartsWith("Add"))
            {
                ErrorLabel.Text = "We have to say what we want to do. Right now, we want to \"Add\" a Mod Object!";
                ErrorPanel.BackColor = Color.Red;
            }
            else if (ObjectTypeTextBox.Text == "???") {
                ErrorLabel.Text = "You haven't given an Object type! A 'Block' is an example of a type.";
                ErrorPanel.BackColor = Color.Red;
            }
            else if (!AddToModTextBox.Text.Contains("("))
            {
                ErrorLabel.Text = "You're missing an opening parenthesis, '('!";
                ErrorPanel.BackColor = Color.Red;
            }
            else if (ObjectNameTextBox.Text == "???")
            {
                ErrorLabel.Text = "You haven't given an Object name. Don't forget to put it in \"Quotes\"!";
                ErrorPanel.BackColor = Color.Red;
            }
            else if (argsArr[0] == "")
            {
                ErrorLabel.Text = "Your name has no letters in it!";
                ErrorPanel.BackColor = Color.Red;
            }
            else if (!argsArr[0].StartsWith("\"") || !argsArr[0].EndsWith("\"")) {
                ErrorLabel.Text = "Your name isn't in \"quotes\"!";
                ErrorPanel.BackColor = Color.Red;
            }
            else if (!AddToModTextBox.Text.EndsWith(")") && !AddToModTextBox.Text.EndsWith(");"))
            {
                ErrorLabel.Text = "You're missing a closing parenthesis, ')'!";
                ErrorPanel.BackColor = Color.Red;
            }
            else if (!AddToModTextBox.Text.EndsWith(";"))
            {
                ErrorLabel.Text = "You're missing a semicolon, ';'! It should be after the other stuff you've written.";
                ErrorPanel.BackColor = Color.Red;
            }
            else
            {
                ErrorLabel.Text = "No Errors";
                ErrorPanel.BackColor = Color.Lime;
            }
        }

        private void AddToModButton_Click(object sender, EventArgs e)
        {
            modObjList.Add(new ModObject(ObjectNameTextBox.Text, ObjectTypeTextBox.Text));
            ListViewItem lvi = new ListViewItem(ObjectNameTextBox.Text, ObjectTypeTextBox.Text);
            lvi.Group = ModSummaryListViewBox.Groups[0];
            ModSummaryListViewBox.Items.Add(lvi);
        }
    }
}
