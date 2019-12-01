namespace Assignment_1
{
    partial class FormMain
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
            this.submitShipButton = new System.Windows.Forms.Button();
            this.shipOutputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fishOutputBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.licenseTextBox = new System.Windows.Forms.TextBox();
            this.maxLoadTextBox = new System.Windows.Forms.TextBox();
            this.speciesComboBox1 = new System.Windows.Forms.ComboBox();
            this.speciesComboBox2 = new System.Windows.Forms.ComboBox();
            this.speciesComboBox3 = new System.Windows.Forms.ComboBox();
            this.speciesComboBox4 = new System.Windows.Forms.ComboBox();
            this.quotaFilledTextBox1 = new System.Windows.Forms.TextBox();
            this.quotaFilledTextBox2 = new System.Windows.Forms.TextBox();
            this.quotaFilledTextBox3 = new System.Windows.Forms.TextBox();
            this.quotaFilledTextBox4 = new System.Windows.Forms.TextBox();
            this.boatSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.quotaOutputBox = new System.Windows.Forms.TextBox();
            this.kgButton = new System.Windows.Forms.Button();
            this.tonneButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitShipButton
            // 
            this.submitShipButton.Location = new System.Drawing.Point(6, 87);
            this.submitShipButton.Name = "submitShipButton";
            this.submitShipButton.Size = new System.Drawing.Size(153, 22);
            this.submitShipButton.TabIndex = 1;
            this.submitShipButton.Text = "Submit";
            this.submitShipButton.UseVisualStyleBackColor = true;
            this.submitShipButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SubmitShipButton_MouseClick);
            // 
            // shipOutputBox
            // 
            this.shipOutputBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.shipOutputBox.Location = new System.Drawing.Point(13, 174);
            this.shipOutputBox.Multiline = true;
            this.shipOutputBox.Name = "shipOutputBox";
            this.shipOutputBox.ReadOnly = true;
            this.shipOutputBox.Size = new System.Drawing.Size(273, 283);
            this.shipOutputBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "License";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Max Load";
            // 
            // fishOutputBox
            // 
            this.fishOutputBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fishOutputBox.Location = new System.Drawing.Point(292, 175);
            this.fishOutputBox.Multiline = true;
            this.fishOutputBox.Name = "fishOutputBox";
            this.fishOutputBox.ReadOnly = true;
            this.fishOutputBox.Size = new System.Drawing.Size(277, 136);
            this.fishOutputBox.TabIndex = 38;
            this.fishOutputBox.TextChanged += new System.EventHandler(this.FormMain_Load);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(59, 9);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 39;
            // 
            // licenseTextBox
            // 
            this.licenseTextBox.Location = new System.Drawing.Point(59, 34);
            this.licenseTextBox.Name = "licenseTextBox";
            this.licenseTextBox.Size = new System.Drawing.Size(100, 20);
            this.licenseTextBox.TabIndex = 40;
            // 
            // maxLoadTextBox
            // 
            this.maxLoadTextBox.Location = new System.Drawing.Point(59, 60);
            this.maxLoadTextBox.Name = "maxLoadTextBox";
            this.maxLoadTextBox.Size = new System.Drawing.Size(100, 20);
            this.maxLoadTextBox.TabIndex = 42;
            // 
            // speciesComboBox1
            // 
            this.speciesComboBox1.FormattingEnabled = true;
            this.speciesComboBox1.Location = new System.Drawing.Point(6, 19);
            this.speciesComboBox1.MaxDropDownItems = 10;
            this.speciesComboBox1.Name = "speciesComboBox1";
            this.speciesComboBox1.Size = new System.Drawing.Size(109, 21);
            this.speciesComboBox1.TabIndex = 43;
            this.speciesComboBox1.SelectedIndexChanged += new System.EventHandler(this.speciesComboBox1_SelectedIndexChanged);
            // 
            // speciesComboBox2
            // 
            this.speciesComboBox2.FormattingEnabled = true;
            this.speciesComboBox2.Location = new System.Drawing.Point(6, 46);
            this.speciesComboBox2.MaxDropDownItems = 10;
            this.speciesComboBox2.Name = "speciesComboBox2";
            this.speciesComboBox2.Size = new System.Drawing.Size(109, 21);
            this.speciesComboBox2.TabIndex = 44;
            this.speciesComboBox2.SelectedIndexChanged += new System.EventHandler(this.speciesComboBox2_SelectedIndexChanged);
            // 
            // speciesComboBox3
            // 
            this.speciesComboBox3.FormattingEnabled = true;
            this.speciesComboBox3.Location = new System.Drawing.Point(6, 73);
            this.speciesComboBox3.MaxDropDownItems = 10;
            this.speciesComboBox3.Name = "speciesComboBox3";
            this.speciesComboBox3.Size = new System.Drawing.Size(109, 21);
            this.speciesComboBox3.TabIndex = 45;
            this.speciesComboBox3.SelectedIndexChanged += new System.EventHandler(this.speciesComboBox3_SelectedIndexChanged);
            // 
            // speciesComboBox4
            // 
            this.speciesComboBox4.FormattingEnabled = true;
            this.speciesComboBox4.Location = new System.Drawing.Point(7, 100);
            this.speciesComboBox4.MaxDropDownItems = 11;
            this.speciesComboBox4.Name = "speciesComboBox4";
            this.speciesComboBox4.Size = new System.Drawing.Size(108, 21);
            this.speciesComboBox4.TabIndex = 46;
            this.speciesComboBox4.SelectedIndexChanged += new System.EventHandler(this.speciesComboBox4_SelectedIndexChanged);
            // 
            // quotaFilledTextBox1
            // 
            this.quotaFilledTextBox1.Location = new System.Drawing.Point(6, 20);
            this.quotaFilledTextBox1.Name = "quotaFilledTextBox1";
            this.quotaFilledTextBox1.Size = new System.Drawing.Size(86, 20);
            this.quotaFilledTextBox1.TabIndex = 47;
            // 
            // quotaFilledTextBox2
            // 
            this.quotaFilledTextBox2.Location = new System.Drawing.Point(6, 47);
            this.quotaFilledTextBox2.Name = "quotaFilledTextBox2";
            this.quotaFilledTextBox2.Size = new System.Drawing.Size(86, 20);
            this.quotaFilledTextBox2.TabIndex = 48;
            // 
            // quotaFilledTextBox3
            // 
            this.quotaFilledTextBox3.Location = new System.Drawing.Point(6, 74);
            this.quotaFilledTextBox3.Name = "quotaFilledTextBox3";
            this.quotaFilledTextBox3.Size = new System.Drawing.Size(86, 20);
            this.quotaFilledTextBox3.TabIndex = 49;
            // 
            // quotaFilledTextBox4
            // 
            this.quotaFilledTextBox4.Location = new System.Drawing.Point(6, 101);
            this.quotaFilledTextBox4.Name = "quotaFilledTextBox4";
            this.quotaFilledTextBox4.Size = new System.Drawing.Size(86, 20);
            this.quotaFilledTextBox4.TabIndex = 50;
            // 
            // boatSelectionComboBox
            // 
            this.boatSelectionComboBox.FormattingEnabled = true;
            this.boatSelectionComboBox.Location = new System.Drawing.Point(13, 142);
            this.boatSelectionComboBox.Name = "boatSelectionComboBox";
            this.boatSelectionComboBox.Size = new System.Drawing.Size(146, 21);
            this.boatSelectionComboBox.TabIndex = 51;
            this.boatSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.boatSelectionComboBox_SelectedIndexChanged);
            // 
            // quotaOutputBox
            // 
            this.quotaOutputBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.quotaOutputBox.Location = new System.Drawing.Point(293, 318);
            this.quotaOutputBox.Multiline = true;
            this.quotaOutputBox.Name = "quotaOutputBox";
            this.quotaOutputBox.ReadOnly = true;
            this.quotaOutputBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.quotaOutputBox.Size = new System.Drawing.Size(276, 139);
            this.quotaOutputBox.TabIndex = 52;
            // 
            // kgButton
            // 
            this.kgButton.Location = new System.Drawing.Point(169, 140);
            this.kgButton.Name = "kgButton";
            this.kgButton.Size = new System.Drawing.Size(117, 23);
            this.kgButton.TabIndex = 54;
            this.kgButton.Text = "KG";
            this.kgButton.UseVisualStyleBackColor = true;
            this.kgButton.Click += new System.EventHandler(this.kgButton_Click);
            // 
            // tonneButton
            // 
            this.tonneButton.Location = new System.Drawing.Point(292, 141);
            this.tonneButton.Name = "tonneButton";
            this.tonneButton.Size = new System.Drawing.Size(103, 23);
            this.tonneButton.TabIndex = 55;
            this.tonneButton.Text = "Tonne";
            this.tonneButton.UseVisualStyleBackColor = true;
            this.tonneButton.Click += new System.EventHandler(this.tonneButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Assignment_1.Properties.Resources.boat_513;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(401, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 151);
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.speciesComboBox1);
            this.groupBox1.Controls.Add(this.speciesComboBox2);
            this.groupBox1.Controls.Add(this.speciesComboBox3);
            this.groupBox1.Controls.Add(this.speciesComboBox4);
            this.groupBox1.Location = new System.Drawing.Point(165, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 126);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Species Selection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.quotaFilledTextBox4);
            this.groupBox2.Controls.Add(this.quotaFilledTextBox3);
            this.groupBox2.Controls.Add(this.quotaFilledTextBox2);
            this.groupBox2.Controls.Add(this.quotaFilledTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(297, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 126);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quota (KG)";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(6, 112);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(153, 23);
            this.updateButton.TabIndex = 60;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.updateButton_MouseClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 469);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tonneButton);
            this.Controls.Add(this.kgButton);
            this.Controls.Add(this.quotaOutputBox);
            this.Controls.Add(this.boatSelectionComboBox);
            this.Controls.Add(this.maxLoadTextBox);
            this.Controls.Add(this.licenseTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.fishOutputBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shipOutputBox);
            this.Controls.Add(this.submitShipButton);
            this.Name = "FormMain";
            this.Text = "CCCU Fisheries";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button submitShipButton;
        private System.Windows.Forms.TextBox shipOutputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fishOutputBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox licenseTextBox;
        private System.Windows.Forms.TextBox maxLoadTextBox;
        private System.Windows.Forms.ComboBox speciesComboBox1;
        private System.Windows.Forms.ComboBox speciesComboBox2;
        private System.Windows.Forms.ComboBox speciesComboBox3;
        private System.Windows.Forms.ComboBox speciesComboBox4;
        private System.Windows.Forms.TextBox quotaFilledTextBox1;
        private System.Windows.Forms.TextBox quotaFilledTextBox2;
        private System.Windows.Forms.TextBox quotaFilledTextBox3;
        private System.Windows.Forms.TextBox quotaFilledTextBox4;
        private System.Windows.Forms.ComboBox boatSelectionComboBox;
        private System.Windows.Forms.TextBox quotaOutputBox;
        private System.Windows.Forms.Button kgButton;
        private System.Windows.Forms.Button tonneButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button updateButton;
    }
}

