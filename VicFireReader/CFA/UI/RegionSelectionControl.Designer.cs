namespace VicFireReader.CFA.UI
{
	partial class RegionSelectionControl
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
			this.regionComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// regionComboBox
			// 
			this.regionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.regionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.regionComboBox.FormattingEnabled = true;
			this.regionComboBox.Items.AddRange(new object[] {
            "All",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
			this.regionComboBox.Location = new System.Drawing.Point(0, 0);
			this.regionComboBox.MaxDropDownItems = 15;
			this.regionComboBox.Name = "regionComboBox";
			this.regionComboBox.Size = new System.Drawing.Size(120, 24);
			this.regionComboBox.TabIndex = 2;
			// 
			// RegionSelectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.regionComboBox);
			this.Name = "RegionSelectionControl";
			this.Size = new System.Drawing.Size(120, 24);
			this.Load += new System.EventHandler(this.RegionSelectionControl_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox regionComboBox;
	}
}
