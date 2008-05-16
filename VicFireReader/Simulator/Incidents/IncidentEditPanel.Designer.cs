namespace VicFireReader.Simulator.Incidents
{
	partial class IncidentEditPanel : IIncidentEditPanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label idLabel;
			System.Windows.Forms.Label nameLabel;
			System.Windows.Forms.Label statusLabel;
			System.Windows.Forms.Label sizeLabel;
			System.Windows.Forms.Label pubDateLabel;
			System.Windows.Forms.Label regionLabel;
			System.Windows.Forms.Label vehiclesLabel;
			System.Windows.Forms.Label locationLabel;
			System.Windows.Forms.Label typeLabel;
			System.Windows.Forms.Label updateTimeLabel;
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.statusTextBox = new System.Windows.Forms.TextBox();
			this.sizeTextBox = new System.Windows.Forms.TextBox();
			this.pubDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.regionNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.vehiclesNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.guidTextBox = new System.Windows.Forms.TextBox();
			this.locationTextBox = new System.Windows.Forms.TextBox();
			this.typeTextBox = new System.Windows.Forms.TextBox();
			this.updateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.prevToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			idLabel = new System.Windows.Forms.Label();
			nameLabel = new System.Windows.Forms.Label();
			statusLabel = new System.Windows.Forms.Label();
			sizeLabel = new System.Windows.Forms.Label();
			pubDateLabel = new System.Windows.Forms.Label();
			regionLabel = new System.Windows.Forms.Label();
			vehiclesLabel = new System.Windows.Forms.Label();
			locationLabel = new System.Windows.Forms.Label();
			typeLabel = new System.Windows.Forms.Label();
			updateTimeLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.regionNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vehiclesNumericUpDown)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// idLabel
			// 
			idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			idLabel.AutoSize = true;
			idLabel.Location = new System.Drawing.Point(3, 0);
			idLabel.Name = "idLabel";
			idLabel.Size = new System.Drawing.Size(42, 28);
			idLabel.TabIndex = 0;
			idLabel.Text = "GUID";
			idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nameLabel
			// 
			nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			nameLabel.AutoSize = true;
			nameLabel.Location = new System.Drawing.Point(3, 28);
			nameLabel.Name = "nameLabel";
			nameLabel.Size = new System.Drawing.Size(45, 28);
			nameLabel.TabIndex = 1;
			nameLabel.Text = "Name";
			nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusLabel
			// 
			statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			statusLabel.AutoSize = true;
			statusLabel.Location = new System.Drawing.Point(3, 112);
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new System.Drawing.Size(48, 28);
			statusLabel.TabIndex = 2;
			statusLabel.Text = "Status";
			statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sizeLabel
			// 
			sizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			sizeLabel.AutoSize = true;
			sizeLabel.Location = new System.Drawing.Point(3, 140);
			sizeLabel.Name = "sizeLabel";
			sizeLabel.Size = new System.Drawing.Size(35, 28);
			sizeLabel.TabIndex = 3;
			sizeLabel.Text = "Size";
			sizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pubDateLabel
			// 
			pubDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			pubDateLabel.AutoSize = true;
			pubDateLabel.Location = new System.Drawing.Point(3, 168);
			pubDateLabel.Name = "pubDateLabel";
			pubDateLabel.Size = new System.Drawing.Size(71, 28);
			pubDateLabel.TabIndex = 4;
			pubDateLabel.Text = "Pub. Date";
			pubDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// regionLabel
			// 
			regionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			regionLabel.AutoSize = true;
			regionLabel.Location = new System.Drawing.Point(3, 224);
			regionLabel.Name = "regionLabel";
			regionLabel.Size = new System.Drawing.Size(53, 28);
			regionLabel.TabIndex = 5;
			regionLabel.Text = "Region";
			regionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// vehiclesLabel
			// 
			vehiclesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			vehiclesLabel.AutoSize = true;
			vehiclesLabel.Location = new System.Drawing.Point(3, 252);
			vehiclesLabel.Name = "vehiclesLabel";
			vehiclesLabel.Size = new System.Drawing.Size(61, 28);
			vehiclesLabel.TabIndex = 6;
			vehiclesLabel.Text = "Vehicles";
			vehiclesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// locationLabel
			// 
			locationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			locationLabel.AutoSize = true;
			locationLabel.Location = new System.Drawing.Point(3, 56);
			locationLabel.Name = "locationLabel";
			locationLabel.Size = new System.Drawing.Size(62, 28);
			locationLabel.TabIndex = 15;
			locationLabel.Text = "Location";
			locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// typeLabel
			// 
			typeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			typeLabel.AutoSize = true;
			typeLabel.Location = new System.Drawing.Point(3, 84);
			typeLabel.Name = "typeLabel";
			typeLabel.Size = new System.Drawing.Size(40, 28);
			typeLabel.TabIndex = 17;
			typeLabel.Text = "Type";
			typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// updateTimeLabel
			// 
			updateTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			updateTimeLabel.AutoSize = true;
			updateTimeLabel.Location = new System.Drawing.Point(3, 196);
			updateTimeLabel.Name = "updateTimeLabel";
			updateTimeLabel.Size = new System.Drawing.Size(84, 28);
			updateTimeLabel.TabIndex = 19;
			updateTimeLabel.Text = "Update time";
			updateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(idLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(nameLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(statusLabel, 0, 4);
			this.tableLayoutPanel1.Controls.Add(sizeLabel, 0, 5);
			this.tableLayoutPanel1.Controls.Add(pubDateLabel, 0, 6);
			this.tableLayoutPanel1.Controls.Add(regionLabel, 0, 8);
			this.tableLayoutPanel1.Controls.Add(vehiclesLabel, 0, 9);
			this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.statusTextBox, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.sizeTextBox, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.pubDateDateTimePicker, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.regionNumericUpDown, 1, 8);
			this.tableLayoutPanel1.Controls.Add(this.vehiclesNumericUpDown, 1, 9);
			this.tableLayoutPanel1.Controls.Add(this.guidTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(locationLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.locationTextBox, 1, 2);
			this.tableLayoutPanel1.Controls.Add(typeLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.typeTextBox, 1, 3);
			this.tableLayoutPanel1.Controls.Add(updateTimeLabel, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.updateDateTimePicker, 1, 7);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 11;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 320);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// nameTextBox
			// 
			this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.nameTextBox.Location = new System.Drawing.Point(93, 31);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(124, 22);
			this.nameTextBox.TabIndex = 8;
			// 
			// statusTextBox
			// 
			this.statusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statusTextBox.Location = new System.Drawing.Point(93, 115);
			this.statusTextBox.Name = "statusTextBox";
			this.statusTextBox.Size = new System.Drawing.Size(124, 22);
			this.statusTextBox.TabIndex = 9;
			// 
			// sizeTextBox
			// 
			this.sizeTextBox.AcceptsReturn = true;
			this.sizeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sizeTextBox.Location = new System.Drawing.Point(93, 143);
			this.sizeTextBox.Name = "sizeTextBox";
			this.sizeTextBox.Size = new System.Drawing.Size(124, 22);
			this.sizeTextBox.TabIndex = 10;
			// 
			// pubDateDateTimePicker
			// 
			this.pubDateDateTimePicker.CustomFormat = "d/MM/yy hh:mm tt";
			this.pubDateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pubDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.pubDateDateTimePicker.Location = new System.Drawing.Point(93, 171);
			this.pubDateDateTimePicker.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
			this.pubDateDateTimePicker.Name = "pubDateDateTimePicker";
			this.pubDateDateTimePicker.ShowUpDown = true;
			this.pubDateDateTimePicker.Size = new System.Drawing.Size(124, 22);
			this.pubDateDateTimePicker.TabIndex = 11;
			this.pubDateDateTimePicker.Value = new System.DateTime(2008, 4, 4, 0, 0, 0, 0);
			// 
			// regionNumericUpDown
			// 
			this.regionNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.regionNumericUpDown.Location = new System.Drawing.Point(93, 227);
			this.regionNumericUpDown.Name = "regionNumericUpDown";
			this.regionNumericUpDown.Size = new System.Drawing.Size(124, 22);
			this.regionNumericUpDown.TabIndex = 12;
			// 
			// vehiclesNumericUpDown
			// 
			this.vehiclesNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vehiclesNumericUpDown.Location = new System.Drawing.Point(93, 255);
			this.vehiclesNumericUpDown.Name = "vehiclesNumericUpDown";
			this.vehiclesNumericUpDown.Size = new System.Drawing.Size(124, 22);
			this.vehiclesNumericUpDown.TabIndex = 13;
			// 
			// guidTextBox
			// 
			this.guidTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.guidTextBox.Location = new System.Drawing.Point(93, 3);
			this.guidTextBox.Name = "guidTextBox";
			this.guidTextBox.Size = new System.Drawing.Size(124, 22);
			this.guidTextBox.TabIndex = 14;
			// 
			// locationTextBox
			// 
			this.locationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.locationTextBox.Location = new System.Drawing.Point(93, 59);
			this.locationTextBox.Name = "locationTextBox";
			this.locationTextBox.Size = new System.Drawing.Size(124, 22);
			this.locationTextBox.TabIndex = 16;
			// 
			// typeTextBox
			// 
			this.typeTextBox.AcceptsReturn = true;
			this.typeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.typeTextBox.Location = new System.Drawing.Point(93, 87);
			this.typeTextBox.Name = "typeTextBox";
			this.typeTextBox.Size = new System.Drawing.Size(124, 22);
			this.typeTextBox.TabIndex = 18;
			// 
			// updateDateTimePicker
			// 
			this.updateDateTimePicker.CustomFormat = "d/MM/yy hh:mm tt";
			this.updateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.updateDateTimePicker.Location = new System.Drawing.Point(93, 199);
			this.updateDateTimePicker.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
			this.updateDateTimePicker.Name = "updateDateTimePicker";
			this.updateDateTimePicker.ShowUpDown = true;
			this.updateDateTimePicker.Size = new System.Drawing.Size(124, 22);
			this.updateDateTimePicker.TabIndex = 20;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prevToolStripButton,
            this.nextToolStripButton,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(220, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// prevToolStripButton
			// 
			this.prevToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.prevToolStripButton.Image = global::VicFireReader.Simulator.Resource.GoToPrevious;
			this.prevToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.prevToolStripButton.Name = "prevToolStripButton";
			this.prevToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.prevToolStripButton.Text = "pevToolStripButton";
			this.prevToolStripButton.ToolTipText = "Previous incident";
			this.prevToolStripButton.Click += new System.EventHandler(this.prevToolStripButton_Click);
			// 
			// nextToolStripButton
			// 
			this.nextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.nextToolStripButton.Image = global::VicFireReader.Simulator.Resource.GoToNextHS;
			this.nextToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.nextToolStripButton.Name = "nextToolStripButton";
			this.nextToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.nextToolStripButton.Text = "toolStripButton2";
			this.nextToolStripButton.ToolTipText = "Next incident";
			this.nextToolStripButton.Click += new System.EventHandler(this.nextToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = global::VicFireReader.Simulator.Resource.NewDocumentHS;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "toolStripButton3";
			this.toolStripButton3.ToolTipText = "New incident";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::VicFireReader.Simulator.Resource.DeleteHS;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.ToolTipText = "Delete this incident";
			// 
			// IncidentEditPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.toolStrip1);
			this.MinimumSize = new System.Drawing.Size(100, 240);
			this.Name = "IncidentEditPanel";
			this.Size = new System.Drawing.Size(220, 345);
			this.Load += new System.EventHandler(this.IncidentEditPanel_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.regionNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vehiclesNumericUpDown)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.TextBox statusTextBox;
		private System.Windows.Forms.TextBox sizeTextBox;
		private System.Windows.Forms.DateTimePicker pubDateDateTimePicker;
		private System.Windows.Forms.NumericUpDown regionNumericUpDown;
		private System.Windows.Forms.NumericUpDown vehiclesNumericUpDown;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton prevToolStripButton;
		private System.Windows.Forms.ToolStripButton nextToolStripButton;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.TextBox locationTextBox;
		private System.Windows.Forms.TextBox typeTextBox;
		private System.Windows.Forms.DateTimePicker updateDateTimePicker;
		private System.Windows.Forms.TextBox guidTextBox;
	}
}