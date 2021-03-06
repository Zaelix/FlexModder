﻿namespace FlexModder
{
    partial class MainFormWindow
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Blocks", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Swords", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Bows", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Tools", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormWindow));
            this.ModSummaryLabel = new System.Windows.Forms.Label();
            this.ModSummaryListViewBox = new System.Windows.Forms.ListView();
            this.ObjectNames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ObjectTypes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModObjectLabel = new System.Windows.Forms.Label();
            this.AddToModTextBox = new System.Windows.Forms.TextBox();
            this.AddToModButton = new System.Windows.Forms.Button();
            this.ObjectTypeLabel = new System.Windows.Forms.Label();
            this.ObjectTypeTextBox = new System.Windows.Forms.TextBox();
            this.ObjectNameTextBox = new System.Windows.Forms.TextBox();
            this.ObjectNameLabel = new System.Windows.Forms.Label();
            this.ErrorPanel = new System.Windows.Forms.Panel();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.MaterialPanel = new System.Windows.Forms.Panel();
            this.EnchantabilityTextBox = new System.Windows.Forms.TextBox();
            this.EnchantabilityLabel = new System.Windows.Forms.Label();
            this.DamageTextBox = new System.Windows.Forms.TextBox();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.HarvestSpeedTextBox = new System.Windows.Forms.TextBox();
            this.HarvestSpeedLabel = new System.Windows.Forms.Label();
            this.DurabilityTextBox = new System.Windows.Forms.TextBox();
            this.DurabilityLabel = new System.Windows.Forms.Label();
            this.HarvestLevelTextBox = new System.Windows.Forms.TextBox();
            this.HarvestLevelLabel = new System.Windows.Forms.Label();
            this.SourceComboBox = new System.Windows.Forms.ComboBox();
            this.ErrorPanel.SuspendLayout();
            this.MaterialPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModSummaryLabel
            // 
            this.ModSummaryLabel.AutoSize = true;
            this.ModSummaryLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModSummaryLabel.Location = new System.Drawing.Point(13, 13);
            this.ModSummaryLabel.Name = "ModSummaryLabel";
            this.ModSummaryLabel.Size = new System.Drawing.Size(108, 19);
            this.ModSummaryLabel.TabIndex = 0;
            this.ModSummaryLabel.Text = "Mod Summary";
            // 
            // ModSummaryListViewBox
            // 
            this.ModSummaryListViewBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ObjectNames,
            this.ObjectTypes});
            this.ModSummaryListViewBox.Cursor = System.Windows.Forms.Cursors.Default;
            listViewGroup1.Header = "Blocks";
            listViewGroup1.Name = "SummaryGroup_Block";
            listViewGroup2.Header = "Swords";
            listViewGroup2.Name = "SummaryGroup_Sword";
            listViewGroup3.Header = "Bows";
            listViewGroup3.Name = "SummaryGroup_Bow";
            listViewGroup4.Header = "Tools";
            listViewGroup4.Name = "SummaryGroup_Tool";
            this.ModSummaryListViewBox.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.ModSummaryListViewBox.Location = new System.Drawing.Point(17, 36);
            this.ModSummaryListViewBox.MultiSelect = false;
            this.ModSummaryListViewBox.Name = "ModSummaryListViewBox";
            this.ModSummaryListViewBox.ShowGroups = false;
            this.ModSummaryListViewBox.Size = new System.Drawing.Size(279, 566);
            this.ModSummaryListViewBox.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ModSummaryListViewBox.TabIndex = 1;
            this.ModSummaryListViewBox.UseCompatibleStateImageBehavior = false;
            this.ModSummaryListViewBox.View = System.Windows.Forms.View.Details;
            this.ModSummaryListViewBox.SelectedIndexChanged += new System.EventHandler(this.ModSummaryListViewBox_SelectedIndexChanged);
            // 
            // ObjectNames
            // 
            this.ObjectNames.Text = "Name";
            this.ObjectNames.Width = 195;
            // 
            // ObjectTypes
            // 
            this.ObjectTypes.Text = "Type";
            this.ObjectTypes.Width = 80;
            // 
            // ModObjectLabel
            // 
            this.ModObjectLabel.AutoSize = true;
            this.ModObjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModObjectLabel.Location = new System.Drawing.Point(302, 36);
            this.ModObjectLabel.Name = "ModObjectLabel";
            this.ModObjectLabel.Size = new System.Drawing.Size(186, 24);
            this.ModObjectLabel.TabIndex = 2;
            this.ModObjectLabel.Text = "Mod Object Details";
            // 
            // AddToModTextBox
            // 
            this.AddToModTextBox.BackColor = System.Drawing.Color.Gold;
            this.AddToModTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToModTextBox.Location = new System.Drawing.Point(306, 64);
            this.AddToModTextBox.Name = "AddToModTextBox";
            this.AddToModTextBox.Size = new System.Drawing.Size(585, 26);
            this.AddToModTextBox.TabIndex = 3;
            this.AddToModTextBox.TextChanged += new System.EventHandler(this.AddToModTextBox_TextChanged);
            // 
            // AddToModButton
            // 
            this.AddToModButton.Enabled = false;
            this.AddToModButton.Location = new System.Drawing.Point(897, 64);
            this.AddToModButton.Name = "AddToModButton";
            this.AddToModButton.Size = new System.Drawing.Size(75, 26);
            this.AddToModButton.TabIndex = 4;
            this.AddToModButton.Text = "Add To Mod";
            this.AddToModButton.UseVisualStyleBackColor = true;
            this.AddToModButton.Click += new System.EventHandler(this.AddToModButton_Click);
            // 
            // ObjectTypeLabel
            // 
            this.ObjectTypeLabel.AutoSize = true;
            this.ObjectTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectTypeLabel.Location = new System.Drawing.Point(310, 119);
            this.ObjectTypeLabel.Name = "ObjectTypeLabel";
            this.ObjectTypeLabel.Size = new System.Drawing.Size(109, 20);
            this.ObjectTypeLabel.TabIndex = 5;
            this.ObjectTypeLabel.Text = "Object Type:";
            // 
            // ObjectTypeTextBox
            // 
            this.ObjectTypeTextBox.Enabled = false;
            this.ObjectTypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectTypeTextBox.Location = new System.Drawing.Point(444, 116);
            this.ObjectTypeTextBox.Name = "ObjectTypeTextBox";
            this.ObjectTypeTextBox.Size = new System.Drawing.Size(100, 26);
            this.ObjectTypeTextBox.TabIndex = 6;
            this.ObjectTypeTextBox.Text = "???";
            // 
            // ObjectNameTextBox
            // 
            this.ObjectNameTextBox.Enabled = false;
            this.ObjectNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectNameTextBox.Location = new System.Drawing.Point(682, 116);
            this.ObjectNameTextBox.Name = "ObjectNameTextBox";
            this.ObjectNameTextBox.Size = new System.Drawing.Size(290, 26);
            this.ObjectNameTextBox.TabIndex = 8;
            this.ObjectNameTextBox.Text = "???";
            // 
            // ObjectNameLabel
            // 
            this.ObjectNameLabel.AutoSize = true;
            this.ObjectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectNameLabel.Location = new System.Drawing.Point(559, 119);
            this.ObjectNameLabel.Name = "ObjectNameLabel";
            this.ObjectNameLabel.Size = new System.Drawing.Size(117, 20);
            this.ObjectNameLabel.TabIndex = 7;
            this.ObjectNameLabel.Text = "Object Name:";
            // 
            // ErrorPanel
            // 
            this.ErrorPanel.BackColor = System.Drawing.Color.Red;
            this.ErrorPanel.Controls.Add(this.ErrorLabel);
            this.ErrorPanel.Location = new System.Drawing.Point(306, 502);
            this.ErrorPanel.Name = "ErrorPanel";
            this.ErrorPanel.Size = new System.Drawing.Size(666, 100);
            this.ErrorPanel.TabIndex = 9;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Location = new System.Drawing.Point(4, 4);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(567, 20);
            this.ErrorLabel.TabIndex = 0;
            this.ErrorLabel.Text = "We have to say what we want to do. Right now, we want to \"Add\" a Mod Object!";
            // 
            // MaterialPanel
            // 
            this.MaterialPanel.Controls.Add(this.EnchantabilityTextBox);
            this.MaterialPanel.Controls.Add(this.EnchantabilityLabel);
            this.MaterialPanel.Controls.Add(this.DamageTextBox);
            this.MaterialPanel.Controls.Add(this.DamageLabel);
            this.MaterialPanel.Controls.Add(this.HarvestSpeedTextBox);
            this.MaterialPanel.Controls.Add(this.HarvestSpeedLabel);
            this.MaterialPanel.Controls.Add(this.DurabilityTextBox);
            this.MaterialPanel.Controls.Add(this.DurabilityLabel);
            this.MaterialPanel.Controls.Add(this.HarvestLevelTextBox);
            this.MaterialPanel.Controls.Add(this.HarvestLevelLabel);
            this.MaterialPanel.Location = new System.Drawing.Point(306, 153);
            this.MaterialPanel.Name = "MaterialPanel";
            this.MaterialPanel.Size = new System.Drawing.Size(666, 343);
            this.MaterialPanel.TabIndex = 10;
            this.MaterialPanel.Visible = false;
            // 
            // EnchantabilityTextBox
            // 
            this.EnchantabilityTextBox.Enabled = false;
            this.EnchantabilityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnchantabilityTextBox.Location = new System.Drawing.Point(138, 144);
            this.EnchantabilityTextBox.Name = "EnchantabilityTextBox";
            this.EnchantabilityTextBox.Size = new System.Drawing.Size(100, 26);
            this.EnchantabilityTextBox.TabIndex = 16;
            this.EnchantabilityTextBox.Text = "???";
            // 
            // EnchantabilityLabel
            // 
            this.EnchantabilityLabel.AutoSize = true;
            this.EnchantabilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnchantabilityLabel.Location = new System.Drawing.Point(4, 147);
            this.EnchantabilityLabel.Name = "EnchantabilityLabel";
            this.EnchantabilityLabel.Size = new System.Drawing.Size(127, 20);
            this.EnchantabilityLabel.TabIndex = 15;
            this.EnchantabilityLabel.Text = "Enchantability:";
            // 
            // DamageTextBox
            // 
            this.DamageTextBox.Enabled = false;
            this.DamageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DamageTextBox.Location = new System.Drawing.Point(138, 112);
            this.DamageTextBox.Name = "DamageTextBox";
            this.DamageTextBox.Size = new System.Drawing.Size(100, 26);
            this.DamageTextBox.TabIndex = 14;
            this.DamageTextBox.Text = "???";
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DamageLabel.Location = new System.Drawing.Point(4, 115);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(81, 20);
            this.DamageLabel.TabIndex = 13;
            this.DamageLabel.Text = "Damage:";
            // 
            // HarvestSpeedTextBox
            // 
            this.HarvestSpeedTextBox.Enabled = false;
            this.HarvestSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HarvestSpeedTextBox.Location = new System.Drawing.Point(138, 80);
            this.HarvestSpeedTextBox.Name = "HarvestSpeedTextBox";
            this.HarvestSpeedTextBox.Size = new System.Drawing.Size(100, 26);
            this.HarvestSpeedTextBox.TabIndex = 12;
            this.HarvestSpeedTextBox.Text = "???";
            // 
            // HarvestSpeedLabel
            // 
            this.HarvestSpeedLabel.AutoSize = true;
            this.HarvestSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HarvestSpeedLabel.Location = new System.Drawing.Point(4, 83);
            this.HarvestSpeedLabel.Name = "HarvestSpeedLabel";
            this.HarvestSpeedLabel.Size = new System.Drawing.Size(133, 20);
            this.HarvestSpeedLabel.TabIndex = 11;
            this.HarvestSpeedLabel.Text = "Harvest Speed:";
            // 
            // DurabilityTextBox
            // 
            this.DurabilityTextBox.Enabled = false;
            this.DurabilityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurabilityTextBox.Location = new System.Drawing.Point(138, 48);
            this.DurabilityTextBox.Name = "DurabilityTextBox";
            this.DurabilityTextBox.Size = new System.Drawing.Size(100, 26);
            this.DurabilityTextBox.TabIndex = 10;
            this.DurabilityTextBox.Text = "???";
            // 
            // DurabilityLabel
            // 
            this.DurabilityLabel.AutoSize = true;
            this.DurabilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurabilityLabel.Location = new System.Drawing.Point(4, 51);
            this.DurabilityLabel.Name = "DurabilityLabel";
            this.DurabilityLabel.Size = new System.Drawing.Size(89, 20);
            this.DurabilityLabel.TabIndex = 9;
            this.DurabilityLabel.Text = "Durability:";
            // 
            // HarvestLevelTextBox
            // 
            this.HarvestLevelTextBox.Enabled = false;
            this.HarvestLevelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HarvestLevelTextBox.Location = new System.Drawing.Point(138, 16);
            this.HarvestLevelTextBox.Name = "HarvestLevelTextBox";
            this.HarvestLevelTextBox.Size = new System.Drawing.Size(100, 26);
            this.HarvestLevelTextBox.TabIndex = 8;
            this.HarvestLevelTextBox.Text = "???";
            // 
            // HarvestLevelLabel
            // 
            this.HarvestLevelLabel.AutoSize = true;
            this.HarvestLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HarvestLevelLabel.Location = new System.Drawing.Point(4, 19);
            this.HarvestLevelLabel.Name = "HarvestLevelLabel";
            this.HarvestLevelLabel.Size = new System.Drawing.Size(123, 20);
            this.HarvestLevelLabel.TabIndex = 7;
            this.HarvestLevelLabel.Text = "Harvest Level:";
            // 
            // SourceComboBox
            // 
            this.SourceComboBox.FormattingEnabled = true;
            this.SourceComboBox.Location = new System.Drawing.Point(716, 13);
            this.SourceComboBox.Name = "SourceComboBox";
            this.SourceComboBox.Size = new System.Drawing.Size(256, 21);
            this.SourceComboBox.TabIndex = 11;
            this.SourceComboBox.SelectedIndexChanged += new System.EventHandler(this.SourceComboBox_SelectedIndexChanged);
            // 
            // MainFormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 614);
            this.Controls.Add(this.SourceComboBox);
            this.Controls.Add(this.MaterialPanel);
            this.Controls.Add(this.ErrorPanel);
            this.Controls.Add(this.ObjectNameTextBox);
            this.Controls.Add(this.ObjectNameLabel);
            this.Controls.Add(this.ObjectTypeTextBox);
            this.Controls.Add(this.ObjectTypeLabel);
            this.Controls.Add(this.AddToModButton);
            this.Controls.Add(this.AddToModTextBox);
            this.Controls.Add(this.ModObjectLabel);
            this.Controls.Add(this.ModSummaryListViewBox);
            this.Controls.Add(this.ModSummaryLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFormWindow";
            this.Text = "Flex Modder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ErrorPanel.ResumeLayout(false);
            this.ErrorPanel.PerformLayout();
            this.MaterialPanel.ResumeLayout(false);
            this.MaterialPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ModSummaryLabel;
        private System.Windows.Forms.ListView ModSummaryListViewBox;
        private System.Windows.Forms.ColumnHeader ObjectNames;
        private System.Windows.Forms.ColumnHeader ObjectTypes;
        private System.Windows.Forms.Label ModObjectLabel;
        private System.Windows.Forms.TextBox AddToModTextBox;
        private System.Windows.Forms.Button AddToModButton;
        private System.Windows.Forms.Label ObjectTypeLabel;
        private System.Windows.Forms.TextBox ObjectTypeTextBox;
        private System.Windows.Forms.TextBox ObjectNameTextBox;
        private System.Windows.Forms.Label ObjectNameLabel;
        private System.Windows.Forms.Panel ErrorPanel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Panel MaterialPanel;
        private System.Windows.Forms.TextBox HarvestLevelTextBox;
        private System.Windows.Forms.Label HarvestLevelLabel;
        private System.Windows.Forms.TextBox DurabilityTextBox;
        private System.Windows.Forms.Label DurabilityLabel;
        private System.Windows.Forms.TextBox HarvestSpeedTextBox;
        private System.Windows.Forms.Label HarvestSpeedLabel;
        private System.Windows.Forms.TextBox EnchantabilityTextBox;
        private System.Windows.Forms.Label EnchantabilityLabel;
        private System.Windows.Forms.TextBox DamageTextBox;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.ComboBox SourceComboBox;
    }
}

