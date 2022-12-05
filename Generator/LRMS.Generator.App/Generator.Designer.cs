namespace LRMS.Generator.App
{
    partial class Generator
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
            this.EntityListBox = new System.Windows.Forms.CheckedListBox();
            this.CoreEntitiesCheckBox = new System.Windows.Forms.CheckBox();
            this.EntitiesCheckBox = new System.Windows.Forms.CheckBox();
            this.SelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.InverseCheckBox = new System.Windows.Forms.CheckBox();
            this.EntitiesGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveSelectedEntities = new System.Windows.Forms.Button();
            this.SelectedEntitiesCounter = new System.Windows.Forms.Label();
            this.SelectedEntities = new System.Windows.Forms.Label();
            this.EntitiesCounter = new System.Windows.Forms.Label();
            this.Reload = new System.Windows.Forms.Button();
            this.CountOfEntities = new System.Windows.Forms.Label();
            this.DbContextGroupBox = new System.Windows.Forms.GroupBox();
            this.DbContextListBox = new System.Windows.Forms.ListBox();
            this.FileSeletionGroupBox = new System.Windows.Forms.GroupBox();
            this.SetLogicLayerLabel = new System.Windows.Forms.Label();
            this.LogicLayerConfigSetButton = new System.Windows.Forms.Button();
            this.SetDbLayerLabel = new System.Windows.Forms.Label();
            this.NoticeOfFileSelection = new System.Windows.Forms.Label();
            this.DbLayerConfigSetButton = new System.Windows.Forms.Button();
            this.PathGroupBox = new System.Windows.Forms.GroupBox();
            this.PahtsCountLabel = new System.Windows.Forms.Label();
            this.CountOfPathsTextLabel = new System.Windows.Forms.Label();
            this.EntitiesPathsListBoxForApplication = new System.Windows.Forms.ListBox();
            this.EntitiesGroupBox.SuspendLayout();
            this.DbContextGroupBox.SuspendLayout();
            this.FileSeletionGroupBox.SuspendLayout();
            this.PathGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EntityListBox
            // 
            this.EntityListBox.FormattingEnabled = true;
            this.EntityListBox.Location = new System.Drawing.Point(6, 50);
            this.EntityListBox.Name = "EntityListBox";
            this.EntityListBox.Size = new System.Drawing.Size(205, 220);
            this.EntityListBox.TabIndex = 4;
            this.EntityListBox.SelectedValueChanged += new System.EventHandler(this.EntityListBox_SelectedValueChanged);
            // 
            // CoreEntitiesCheckBox
            // 
            this.CoreEntitiesCheckBox.AutoSize = true;
            this.CoreEntitiesCheckBox.Location = new System.Drawing.Point(6, 22);
            this.CoreEntitiesCheckBox.Name = "CoreEntitiesCheckBox";
            this.CoreEntitiesCheckBox.Size = new System.Drawing.Size(92, 19);
            this.CoreEntitiesCheckBox.TabIndex = 1;
            this.CoreEntitiesCheckBox.Text = "Core Entities";
            this.CoreEntitiesCheckBox.UseVisualStyleBackColor = true;
            this.CoreEntitiesCheckBox.CheckedChanged += new System.EventHandler(this.CoreEntitiesCheckBox_CheckedChanged);
            // 
            // EntitiesCheckBox
            // 
            this.EntitiesCheckBox.AutoSize = true;
            this.EntitiesCheckBox.Location = new System.Drawing.Point(104, 22);
            this.EntitiesCheckBox.Name = "EntitiesCheckBox";
            this.EntitiesCheckBox.Size = new System.Drawing.Size(107, 19);
            this.EntitiesCheckBox.TabIndex = 2;
            this.EntitiesCheckBox.Text = "Normal Entities";
            this.EntitiesCheckBox.UseVisualStyleBackColor = true;
            this.EntitiesCheckBox.CheckedChanged += new System.EventHandler(this.EntitiesCheckBox_CheckedChanged);
            // 
            // SelectAllCheckBox
            // 
            this.SelectAllCheckBox.AutoSize = true;
            this.SelectAllCheckBox.Location = new System.Drawing.Point(6, 276);
            this.SelectAllCheckBox.Name = "SelectAllCheckBox";
            this.SelectAllCheckBox.Size = new System.Drawing.Size(74, 19);
            this.SelectAllCheckBox.TabIndex = 3;
            this.SelectAllCheckBox.Text = "Select All";
            this.SelectAllCheckBox.UseVisualStyleBackColor = true;
            this.SelectAllCheckBox.CheckedChanged += new System.EventHandler(this.SelectAllCheckBox_CheckedChanged);
            // 
            // InverseCheckBox
            // 
            this.InverseCheckBox.AutoSize = true;
            this.InverseCheckBox.Location = new System.Drawing.Point(104, 276);
            this.InverseCheckBox.Name = "InverseCheckBox";
            this.InverseCheckBox.Size = new System.Drawing.Size(63, 19);
            this.InverseCheckBox.TabIndex = 4;
            this.InverseCheckBox.Text = "Inverse";
            this.InverseCheckBox.UseVisualStyleBackColor = true;
            this.InverseCheckBox.CheckedChanged += new System.EventHandler(this.InverseCheckBox_CheckedChanged);
            // 
            // EntitiesGroupBox
            // 
            this.EntitiesGroupBox.Controls.Add(this.SaveSelectedEntities);
            this.EntitiesGroupBox.Controls.Add(this.SelectedEntitiesCounter);
            this.EntitiesGroupBox.Controls.Add(this.SelectedEntities);
            this.EntitiesGroupBox.Controls.Add(this.EntitiesCounter);
            this.EntitiesGroupBox.Controls.Add(this.CoreEntitiesCheckBox);
            this.EntitiesGroupBox.Controls.Add(this.EntitiesCheckBox);
            this.EntitiesGroupBox.Controls.Add(this.SelectAllCheckBox);
            this.EntitiesGroupBox.Controls.Add(this.InverseCheckBox);
            this.EntitiesGroupBox.Controls.Add(this.Reload);
            this.EntitiesGroupBox.Controls.Add(this.CountOfEntities);
            this.EntitiesGroupBox.Controls.Add(this.EntityListBox);
            this.EntitiesGroupBox.Location = new System.Drawing.Point(15, 15);
            this.EntitiesGroupBox.Name = "EntitiesGroupBox";
            this.EntitiesGroupBox.Size = new System.Drawing.Size(220, 430);
            this.EntitiesGroupBox.TabIndex = 0;
            this.EntitiesGroupBox.TabStop = false;
            this.EntitiesGroupBox.Text = "Entity";
            // 
            // SaveSelectedEntities
            // 
            this.SaveSelectedEntities.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveSelectedEntities.Location = new System.Drawing.Point(6, 359);
            this.SaveSelectedEntities.Name = "SaveSelectedEntities";
            this.SaveSelectedEntities.Size = new System.Drawing.Size(208, 65);
            this.SaveSelectedEntities.TabIndex = 7;
            this.SaveSelectedEntities.Text = "Move to the side  >>>";
            this.SaveSelectedEntities.UseVisualStyleBackColor = true;
            this.SaveSelectedEntities.Click += new System.EventHandler(this.SaveSelectedEntities_Click);
            // 
            // SelectedEntitiesCounter
            // 
            this.SelectedEntitiesCounter.AutoSize = true;
            this.SelectedEntitiesCounter.Location = new System.Drawing.Point(171, 329);
            this.SelectedEntitiesCounter.Name = "SelectedEntitiesCounter";
            this.SelectedEntitiesCounter.Size = new System.Drawing.Size(13, 15);
            this.SelectedEntitiesCounter.TabIndex = 9;
            this.SelectedEntitiesCounter.Text = "0";
            this.SelectedEntitiesCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectedEntities
            // 
            this.SelectedEntities.AutoSize = true;
            this.SelectedEntities.Location = new System.Drawing.Point(70, 329);
            this.SelectedEntities.Name = "SelectedEntities";
            this.SelectedEntities.Size = new System.Drawing.Size(95, 15);
            this.SelectedEntities.TabIndex = 8;
            this.SelectedEntities.Text = "Selected Entities:";
            this.SelectedEntities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EntitiesCounter
            // 
            this.EntitiesCounter.AutoSize = true;
            this.EntitiesCounter.Location = new System.Drawing.Point(176, 305);
            this.EntitiesCounter.Name = "EntitiesCounter";
            this.EntitiesCounter.Size = new System.Drawing.Size(13, 15);
            this.EntitiesCounter.TabIndex = 7;
            this.EntitiesCounter.Text = "0";
            this.EntitiesCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Reload
            // 
            this.Reload.Location = new System.Drawing.Point(6, 305);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(58, 39);
            this.Reload.TabIndex = 5;
            this.Reload.Text = "Reload";
            this.Reload.UseVisualStyleBackColor = true;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // CountOfEntities
            // 
            this.CountOfEntities.AutoSize = true;
            this.CountOfEntities.Location = new System.Drawing.Point(70, 305);
            this.CountOfEntities.Name = "CountOfEntities";
            this.CountOfEntities.Size = new System.Drawing.Size(100, 15);
            this.CountOfEntities.TabIndex = 6;
            this.CountOfEntities.Text = "Count Of Entities:";
            this.CountOfEntities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DbContextGroupBox
            // 
            this.DbContextGroupBox.Controls.Add(this.DbContextListBox);
            this.DbContextGroupBox.Location = new System.Drawing.Point(255, 15);
            this.DbContextGroupBox.Name = "DbContextGroupBox";
            this.DbContextGroupBox.Size = new System.Drawing.Size(200, 85);
            this.DbContextGroupBox.TabIndex = 1;
            this.DbContextGroupBox.TabStop = false;
            this.DbContextGroupBox.Text = "DbContext";
            // 
            // DbContextListBox
            // 
            this.DbContextListBox.FormattingEnabled = true;
            this.DbContextListBox.ItemHeight = 15;
            this.DbContextListBox.Location = new System.Drawing.Point(6, 22);
            this.DbContextListBox.Name = "DbContextListBox";
            this.DbContextListBox.Size = new System.Drawing.Size(188, 49);
            this.DbContextListBox.TabIndex = 0;
            // 
            // FileSeletionGroupBox
            // 
            this.FileSeletionGroupBox.Controls.Add(this.SetLogicLayerLabel);
            this.FileSeletionGroupBox.Controls.Add(this.LogicLayerConfigSetButton);
            this.FileSeletionGroupBox.Controls.Add(this.SetDbLayerLabel);
            this.FileSeletionGroupBox.Controls.Add(this.NoticeOfFileSelection);
            this.FileSeletionGroupBox.Controls.Add(this.DbLayerConfigSetButton);
            this.FileSeletionGroupBox.Location = new System.Drawing.Point(255, 116);
            this.FileSeletionGroupBox.Name = "FileSeletionGroupBox";
            this.FileSeletionGroupBox.Size = new System.Drawing.Size(200, 185);
            this.FileSeletionGroupBox.TabIndex = 2;
            this.FileSeletionGroupBox.TabStop = false;
            this.FileSeletionGroupBox.Text = "File Seletion";
            // 
            // SetLogicLayerLabel
            // 
            this.SetLogicLayerLabel.AutoSize = true;
            this.SetLogicLayerLabel.Location = new System.Drawing.Point(6, 159);
            this.SetLogicLayerLabel.Name = "SetLogicLayerLabel";
            this.SetLogicLayerLabel.Size = new System.Drawing.Size(137, 15);
            this.SetLogicLayerLabel.TabIndex = 5;
            this.SetLogicLayerLabel.Text = "Not Selected Logic Layer";
            // 
            // LogicLayerConfigSetButton
            // 
            this.LogicLayerConfigSetButton.Location = new System.Drawing.Point(6, 131);
            this.LogicLayerConfigSetButton.Name = "LogicLayerConfigSetButton";
            this.LogicLayerConfigSetButton.Size = new System.Drawing.Size(137, 25);
            this.LogicLayerConfigSetButton.TabIndex = 4;
            this.LogicLayerConfigSetButton.Text = "Set Logic Layer File";
            this.LogicLayerConfigSetButton.UseVisualStyleBackColor = true;
            this.LogicLayerConfigSetButton.Click += new System.EventHandler(this.LogicLayerConfigSetButton_Click);
            // 
            // SetDbLayerLabel
            // 
            this.SetDbLayerLabel.AutoSize = true;
            this.SetDbLayerLabel.Location = new System.Drawing.Point(6, 97);
            this.SetDbLayerLabel.Name = "SetDbLayerLabel";
            this.SetDbLayerLabel.Size = new System.Drawing.Size(123, 15);
            this.SetDbLayerLabel.TabIndex = 3;
            this.SetDbLayerLabel.Text = "Not Selected Db Layer";
            // 
            // NoticeOfFileSelection
            // 
            this.NoticeOfFileSelection.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.NoticeOfFileSelection.Location = new System.Drawing.Point(6, 19);
            this.NoticeOfFileSelection.Name = "NoticeOfFileSelection";
            this.NoticeOfFileSelection.Size = new System.Drawing.Size(188, 38);
            this.NoticeOfFileSelection.TabIndex = 0;
            this.NoticeOfFileSelection.Text = "Please select the required files below.";
            // 
            // DbLayerConfigSetButton
            // 
            this.DbLayerConfigSetButton.Location = new System.Drawing.Point(6, 69);
            this.DbLayerConfigSetButton.Name = "DbLayerConfigSetButton";
            this.DbLayerConfigSetButton.Size = new System.Drawing.Size(123, 25);
            this.DbLayerConfigSetButton.TabIndex = 1;
            this.DbLayerConfigSetButton.Text = "Set Db Layer File";
            this.DbLayerConfigSetButton.UseVisualStyleBackColor = true;
            this.DbLayerConfigSetButton.Click += new System.EventHandler(this.DbLayerConfigSetButton_Click);
            // 
            // PathGroupBox
            // 
            this.PathGroupBox.Controls.Add(this.PahtsCountLabel);
            this.PathGroupBox.Controls.Add(this.CountOfPathsTextLabel);
            this.PathGroupBox.Controls.Add(this.EntitiesPathsListBoxForApplication);
            this.PathGroupBox.Location = new System.Drawing.Point(475, 15);
            this.PathGroupBox.Name = "PathGroupBox";
            this.PathGroupBox.Size = new System.Drawing.Size(303, 195);
            this.PathGroupBox.TabIndex = 3;
            this.PathGroupBox.TabStop = false;
            this.PathGroupBox.Text = "Application Paths";
            // 
            // PahtsCountLabel
            // 
            this.PahtsCountLabel.AutoSize = true;
            this.PahtsCountLabel.Location = new System.Drawing.Point(90, 159);
            this.PahtsCountLabel.Name = "PahtsCountLabel";
            this.PahtsCountLabel.Size = new System.Drawing.Size(36, 15);
            this.PahtsCountLabel.TabIndex = 2;
            this.PahtsCountLabel.Text = "None";
            // 
            // CountOfPathsTextLabel
            // 
            this.CountOfPathsTextLabel.AutoSize = true;
            this.CountOfPathsTextLabel.Location = new System.Drawing.Point(6, 159);
            this.CountOfPathsTextLabel.Name = "CountOfPathsTextLabel";
            this.CountOfPathsTextLabel.Size = new System.Drawing.Size(78, 15);
            this.CountOfPathsTextLabel.TabIndex = 1;
            this.CountOfPathsTextLabel.Text = "Paths Count :";
            // 
            // EntitiesPathsListBoxForApplication
            // 
            this.EntitiesPathsListBoxForApplication.FormattingEnabled = true;
            this.EntitiesPathsListBoxForApplication.ItemHeight = 15;
            this.EntitiesPathsListBoxForApplication.Location = new System.Drawing.Point(6, 22);
            this.EntitiesPathsListBoxForApplication.Name = "EntitiesPathsListBoxForApplication";
            this.EntitiesPathsListBoxForApplication.Size = new System.Drawing.Size(291, 124);
            this.EntitiesPathsListBoxForApplication.TabIndex = 0;
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 461);
            this.Controls.Add(this.PathGroupBox);
            this.Controls.Add(this.FileSeletionGroupBox);
            this.Controls.Add(this.DbContextGroupBox);
            this.Controls.Add(this.EntitiesGroupBox);
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "Generator";
            this.Text = "Generator";
            this.Load += new System.EventHandler(this.Generator_Load);
            this.EntitiesGroupBox.ResumeLayout(false);
            this.EntitiesGroupBox.PerformLayout();
            this.DbContextGroupBox.ResumeLayout(false);
            this.FileSeletionGroupBox.ResumeLayout(false);
            this.FileSeletionGroupBox.PerformLayout();
            this.PathGroupBox.ResumeLayout(false);
            this.PathGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox EntitiesGroupBox;
        private CheckedListBox EntityListBox;
        private Label CountOfEntities;
        private Button Reload;
        private CheckBox SelectAllCheckBox;
        private CheckBox InverseCheckBox;
        private CheckBox CoreEntitiesCheckBox;
        private CheckBox EntitiesCheckBox;
        private Label EntitiesCounter;
        private Label SelectedEntitiesCounter;
        private Label SelectedEntities;
        private Button SaveSelectedEntities;
        private GroupBox DbContextGroupBox;
        private ListBox DbContextListBox;
        private GroupBox FileSeletionGroupBox;
        private Label NoticeOfFileSelection;
        private Label SetDbLayerLabel;
        private Button DbLayerConfigSetButton;
        private Label SetLogicLayerLabel;
        private Button LogicLayerConfigSetButton;
        private GroupBox PathGroupBox;
        private ListBox EntitiesPathsListBoxForApplication;
        private Label PahtsCountLabel;
        private Label CountOfPathsTextLabel;
    }
}