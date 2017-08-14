﻿using System;
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
        String objArgs = "";
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
            else if (AddToModTextBox.Text.Contains("AddMaterial"))
            {
                objType = "Material";
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

                objArgs = AddToModTextBox.Text.Substring(argsStart, argsLength);
                argsArr = objArgs.Split(',');

                UpdateArgumentTextBoxes();

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

            CheckForAddErrors();
            if (ErrorLabel.Text == "No Errors Found")
            {
                ErrorPanel.BackColor = Color.Lime;
                AddToModButton.Enabled = true;
            }
            else
            {
                ErrorPanel.BackColor = Color.Red;
                AddToModButton.Enabled = false;
            }

        }

        private void UpdateArgumentTextBoxes() {
            ModObjectLabel.Text = "Mod Object Details - Argument Count: " + argsArr.Length;
            if (argsArr.Length > 1)
            {
                MaterialPanel.Visible = true;
                HarvestLevelTextBox.Text = (argsArr[1] != "" && argsArr[1] != " ") ? argsArr[1].Replace(" ", "") : "???";
            }
            if (argsArr.Length > 2)
            {
                DurabilityTextBox.Text = !string.IsNullOrWhiteSpace(argsArr[2]) ? argsArr[2].Replace(" ", "") : "???";
            }
            else if (argsArr.Length == 1)
            {
                MaterialPanel.Visible = false;
            }
        }

        private void CheckForAddErrors() {
            bool argsAreComplete = false;
            if (!AddToModTextBox.Text.StartsWith("Add"))
            {
                ErrorLabel.Text = "We have to say what we want to do. Right now, we want to \"Add\" a Mod Object!";
            }
            else if (ObjectTypeTextBox.Text == "???")
            {
                ErrorLabel.Text = "You haven't given an Object type! A 'Block' is an example of a type.";
            }
            else if (!AddToModTextBox.Text.Contains("("))
            {
                ErrorLabel.Text = "You're missing an opening parenthesis, '('!";
            }
            else if (ObjectNameTextBox.Text == "???")
            {
                ErrorLabel.Text = "You haven't given an Object name. Don't forget to put it in \"Quotes\"!";
            }
            else if (argsArr[0] == "" || argsArr[0] == "\"\"")
            {
                ErrorLabel.Text = "Your name has no letters in it!";
            }
            else if (argsArr[0] == "\"")
            {
                ErrorLabel.Text = "You have no ending quotes!";
            }
            else if (!argsArr[0].StartsWith("\"") || !argsArr[0].EndsWith("\""))
            {
                ErrorLabel.Text = "Your name isn't in \"quotes\"!";
            }
            // Diverges for Materials and advanced Object error handling
            else if (ObjectTypeTextBox.Text == "Material")
            {
                argsAreComplete = CheckForAddMaterialErrors();
            }
            else if (ObjectTypeTextBox.Text != "???" && argsArr.Length > 1)
            {
                argsAreComplete = CheckForAddObjectErrors();
            }
            else {
                argsAreComplete = true;
            }
            // Resumes common line ending error handling
            if (argsAreComplete)
            {

                if (!AddToModTextBox.Text.Contains(")"))
                {
                    ErrorLabel.Text = "You're missing a closing parenthesis, ')'!";
                }
                else if (AddToModTextBox.Text.Contains(")") && (!AddToModTextBox.Text.EndsWith(")") && !AddToModTextBox.Text.EndsWith(");")))
                {
                    ErrorLabel.Text = "You have stuff after the closing parenthesis, ')', that shouldn't be there!";
                }
                else if (!AddToModTextBox.Text.EndsWith(";"))
                {
                    ErrorLabel.Text = "You're missing a semicolon, ';'! It should be after all the other stuff you've written.";
                }
                else if (ParenthesisCount() > 1)
                {
                    string source = AddToModTextBox.Text;
                    int count = 0;
                    foreach (char c in source)
                        if (c == ')') count++;
                    if (count > 1) {
                        ErrorLabel.Text = "You have an extra closing parenthesis, ')', in your line of code!";
                    }
                }
                else
                {
                    ErrorLabel.Text = "No Errors Found";
                }
            }
        }

        private int ParenthesisCount() {
            string source = AddToModTextBox.Text;
            int count = 0;
            foreach (char c in source)
                if (c == ')') count++;
            return count;
        }

        private bool CheckForAddObjectErrors()
        {
            return true;
        }

        private bool CheckForAddMaterialErrors() {
            if (argsArr.Length == 1 && !AddToModTextBox.Text.EndsWith(","))
            {
                ErrorLabel.Text = "You're missing a comma, ','! We need a comma after our material's name to tell the computer \r\nwe're making a list.";
            }
            if (argsArr.Length >= 2)
            {
                string desc = "The second thing in the list should be a number, between 1 and 3. \r\nThis is the Harvest Level of your material.\r\nYour material's harvest level needs to be as high as the harvest level of whatever block you're \r\ntrying to mine";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[1], 1, 3, false, desc, false);
            }
            if (argsArr.Length >= 3)
            {
                string desc = "The third thing in the list should also be a number, between 1 and 1 million.\r\nThis is the Durability of your material.\r\nThe higher this is, the longer you can use a tool made out of your material before it breaks.";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[2], 1, 1000000, false, desc, false);
            }
            if (argsArr.Length >= 4)
            {
                string desc = "The fourth thing in the list is another number, between 1 and 100.\r\nThis is the Harvest Speed of your material.\r\nThe higher this is, the faster you will break blocks with a tool made out of your material.\r\nThis number NEEDS to end with the letter F!";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[3], 1, 100, true, desc, false);
            }
            if (argsArr.Length >= 5)
            {
                string desc = "The fifth thing in the list is yet another number, between 1 and 2000.\r\nThis is the Damage of your material.\r\nThe higher this is, the faster you will kill enemies with tools make out of your material.\r\nThis number NEEDS to end with the letter F!";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[4], 1, 2000, true, desc, false);
            }
            if (argsArr.Length == 6)
            {
                string desc = "The sixth thing in the list is the final number, between 1 and 100.\r\nThis is the Enchantability of your material.\r\nThe higher this is, the more powerfully you can enchant tools made out of your material.";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[5], 1, 100, false, desc, true);
                if (ErrorLabel.Text == "We're done with our list!") {
                    return true;
                }
            }
            return false;
        }

        private string AnalyzeNumberArgument(string arg, int min, int max, bool isFloat, string description, bool finalArg) {
            string ret = "Error";
            string modArg = isFloat ? arg.TrimEnd('F').TrimStart(' ') : arg.TrimStart(' ');
            if (string.IsNullOrWhiteSpace(modArg))
            {
                ret = description;
            }
            else if (!modArg.All(Char.IsDigit))
            {
                ret = "You have letters in your number that shouldn't be there!";
            }
            else if (!(int.Parse(modArg) >= min && int.Parse(modArg) <= max))
            {
                ret = "Your number is not between " + min + " and " + max + "!";
            }
            else if (isFloat && !arg.EndsWith("F"))
            {
                ret = "Your number needs to end with the letter F!";
            }
            else if (!finalArg)
            {
                ret = "Now we need another comma!";
            }
            else {
                ret = "We're done with our list!";
            }
            return ret;
        }

        private void AddToModButton_Click(object sender, EventArgs e)
        {
            // Captures the object properties
            String name = ObjectNameTextBox.Text;
            String type = ObjectTypeTextBox.Text;

            // Adds the new object to the summary
            modObjList.Add(new ModObject(ObjectNameTextBox.Text, ObjectTypeTextBox.Text));
            String[] lviArr = { ObjectNameTextBox.Text, ObjectTypeTextBox.Text };
            ListViewItem lvi = new ListViewItem(lviArr);
            lvi.Group = ModSummaryListViewBox.Groups[0];
            ModSummaryListViewBox.Items.Add(lvi);

            // Makes the relevant changes to the Forge Mod source files
            if (type == "Block")
            {
                FlexMod.addObject(name, "Block", type, " ");
            }
            else if (type == "Sword")
            {
                if (argsArr.Length > 1)
                {
                    FlexMod.addObject(name, "Item", type, argsArr[1]);
                }
                else
                {
                    FlexMod.addObject(name, "Item", type, " ");
                }
            }
            else if (type == "Bow")
            {
                FlexMod.addObject(name, "Item", type, " ");
            }
            else if (type == "Material" && argsArr.Length > 5)
            {
                FlexMod.addMaterial(name, int.Parse(argsArr[1]), int.Parse(argsArr[2]), int.Parse(argsArr[3]), int.Parse(argsArr[4]), int.Parse(argsArr[5]));
            }

            // Clears the Add text input field
            AddToModTextBox.Text = "";
        }
    }
}
