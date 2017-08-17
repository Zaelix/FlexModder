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
        String versionNum = "0.0.04";
        String[] argsArr;
        String objArgs = "";
        List<ModObject> modObjList = new List<ModObject>();
        bool[] argIsCorrect = new bool[10];
        FlexMod myMod;

        public MainFormWindow()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateModSummary();
            myMod.findFiles();
        }

        private void PopulateModSummary()
        {
            myMod = new FlexMod(this);
            
        }

        private void ModSummaryListViewBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void AddSourceToList(string src) {
            SourceComboBox.Items.Add(src);
        }

        public void SetSelectedSource(string src)
        {
            SourceComboBox.SelectedItem = SourceComboBox.Items[SourceComboBox.Items.IndexOf(src)];
        }

        private void ClearArgCorrectBoolArrays() {
            for (int i  = 0; i < argIsCorrect.Length; i++) {
                argIsCorrect[i] = false;
            }
        }

        private void AddToModTextBox_TextChanged(object sender, EventArgs e)
        {
            String objType = "???";
            String objName = "???";
            ClearArgCorrectBoolArrays();

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
                HarvestLevelTextBox.Text = !string.IsNullOrWhiteSpace(argsArr[1]) ? argsArr[1].Replace(" ", "") : "???";
            }
            if (argsArr.Length > 2)
            {
                DurabilityTextBox.Text = !string.IsNullOrWhiteSpace(argsArr[2]) ? argsArr[2].Replace(" ", "") : "???";
            }
            if (argsArr.Length > 3)
            {
                HarvestSpeedTextBox.Text = !string.IsNullOrWhiteSpace(argsArr[3]) ? argsArr[3].Replace(" ", "") : "???";
            }
            if (argsArr.Length > 4)
            {
                DamageTextBox.Text = !string.IsNullOrWhiteSpace(argsArr[4]) ? argsArr[4].Replace(" ", "") : "???";
            }
            if (argsArr.Length > 5)
            {
                EnchantabilityTextBox.Text = !string.IsNullOrWhiteSpace(argsArr[5]) ? argsArr[5].Replace(" ", "") : "???";
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
            else if (argIsCorrect[0] == false) {
                ErrorLabel.Text = AnalyzeStringArgument(argsArr[0], 0, false);
            }
            // Diverges for Materials and advanced Object error handling
            else if (ObjectTypeTextBox.Text == "Material" && argIsCorrect[0])
            {
                argsAreComplete = CheckForAddMaterialErrors();
            }
            else if (argIsCorrect[0] == true && argsArr.Length > 1)
            {
                argsAreComplete = CheckForAddObjectErrors();
            }
            // Resumes common line ending error handling
            if (argsAreComplete || (argIsCorrect[0] == true && argsArr.Length == 1))
            {
                PostArgumentErrorChecks();
            }
        }

        private int ParenthesisCount() {
            string source = AddToModTextBox.Text;
            int count = 0;
            foreach (char c in source)
                if (c == ')') count++;
            return count;
        }

        private int QuoteCount(string arg) {
            string source = arg;
            int count = 0;
            foreach (char c in source)
                if (c == '"') count++;
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
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[1], 1, 3, false, desc, 1, false);
            }
            if (argsArr.Length >= 3)
            {
                string desc = "The third thing in the list should also be a number, between 1 and 1 million.\r\nThis is the Durability of your material.\r\nThe higher this is, the longer you can use a tool made out of your material before it breaks.";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[2], 1, 1000000, false, desc, 2, false);
            }
            if (argsArr.Length >= 4)
            {
                string desc = "The fourth thing in the list is another number, between 1 and 100.\r\nThis is the Harvest Speed of your material.\r\nThe higher this is, the faster you will break blocks with a tool made out of your material.\r\nThis number NEEDS to end with the letter F!";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[3], 1, 100, true, desc, 3, false);
            }
            if (argsArr.Length >= 5)
            {
                string desc = "The fifth thing in the list is yet another number, between 1 and 2000.\r\nThis is the Damage of your material.\r\nThe higher this is, the faster you will kill enemies with tools make out of your material.\r\nThis number NEEDS to end with the letter F!";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[4], 1, 2000, true, desc, 4, false);
            }
            if (argsArr.Length == 6)
            {
                string desc = "The sixth thing in the list is the final number, between 1 and 100.\r\nThis is the Enchantability of your material.\r\nThe higher this is, the more powerfully you can enchant tools made out of your material.";
                ErrorLabel.Text = AnalyzeNumberArgument(argsArr[5], 1, 100, false, desc, 5, true);
                if (ErrorLabel.Text == "We're done with our list!") {
                    return true;
                }
            }
            return false;
        }

        private string AnalyzeNumberArgument(string arg, int min, int max, bool isFloat, string description, int argNum, bool finalArg) {
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
                argIsCorrect[argNum] = true;
            }
            else {
                ret = "We're done with our list!";
                argIsCorrect[argNum] = true;
            }
            argIsCorrect[argNum] = false;
            return ret;
        }

        private string AnalyzeStringArgument(string arg, int argNum, bool finalArg)
        {
            string ret = "Error";
            if (!arg.StartsWith("\""))
            {
                ret = "We need to start the name with a set of \"Quotes\"!";
            }
            else if (arg.StartsWith("\"") && arg.Length == 1)
            {
                ret = "Now we need to type our object's name!";
            }
            else if (arg.StartsWith("\"") && arg.Length >= 2 && !arg.EndsWith("\""))
            {
                ret = "Now we need a set of ending quotes!";
            }
            else if (!arg.StartsWith("\"") || !arg.EndsWith("\""))
            {
                ret = "Your name isn't in \"quotes\"!";
            }
            else if (QuoteCount(arg) > 2) {
                ret = "You have extra quotes!";
            }
            else {
                argIsCorrect[argNum] = true;
                return "We did it!";
            }
            argIsCorrect[argNum] = false;
            return ret;
        }

        private void PostArgumentErrorChecks() {
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
                ErrorLabel.Text = "You have an extra closing parenthesis, ')', in your line of code!";
            }
            else
            {
                ErrorLabel.Text = "No Errors Found";
            }
        }

        public void AddToModSummary(string name, string type) {
            modObjList.Add(new ModObject(name, type));
            String[] lviArr = { name, type };
            ListViewItem lvi = new ListViewItem(lviArr);
            lvi.Group = ModSummaryListViewBox.Groups[0];
            ModSummaryListViewBox.Items.Add(lvi);
        }

        private void AddToModButton_Click(object sender, EventArgs e)
        {
            // Captures the object properties
            String name = ObjectNameTextBox.Text;
            String type = ObjectTypeTextBox.Text;

            // Adds the new object to the summary
            AddToModSummary(name, type);

            // Makes the relevant changes to the Forge Mod source files
            if (type == "Block")
            {
                myMod.addObject(name, "Block", type, " ");
            }
            else if (type == "Sword")
            {
                if (argsArr.Length > 1)
                {
                    myMod.addObject(name, "Item", type, argsArr[1]);
                }
                else
                {
                    myMod.addObject(name, "Item", type, " ");
                }
            }
            else if (type == "Bow")
            {
                myMod.addObject(name, "Item", type, " ");
            }
            else if (type == "Material" && argsArr.Length > 5)
            {
                myMod.addMaterial(name, int.Parse(argsArr[1]), int.Parse(argsArr[2]), int.Parse(argsArr[3]), int.Parse(argsArr[4]), int.Parse(argsArr[5]));
            }

            // Clears the Add text input field
            AddToModTextBox.Text = "";
        }

        private void SourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
