namespace CFAReader.Simulator.General
{
	partial class ConnectionView : IConnectionView
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
			System.Windows.Forms.Label connectionLabel;
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.connectionComboBox1 = new CFAReader.Simulator.General.ConnectionComboBox();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			connectionLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// connectionLabel
			// 
			connectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			connectionLabel.AutoSize = true;
			connectionLabel.Location = new System.Drawing.Point(3, 0);
			connectionLabel.Name = "connectionLabel";
			connectionLabel.Size = new System.Drawing.Size(79, 30);
			connectionLabel.TabIndex = 1;
			connectionLabel.Text = "Connection";
			connectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(connectionLabel, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.connectionComboBox1, 1, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 70);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(241, 78);
			this.tableLayoutPanel.TabIndex = 2;
			// 
			// connectionComboBox1
			// 
			this.connectionComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.connectionComboBox1.FormattingEnabled = true;
			this.connectionComboBox1.Location = new System.Drawing.Point(88, 3);
			this.connectionComboBox1.Name = "connectionComboBox1";
			this.connectionComboBox1.Size = new System.Drawing.Size(150, 24);
			this.connectionComboBox1.TabIndex = 2;
			this.connectionComboBox1.Text = "xOnline";
			// 
			// toolStrip
			// 
			this.toolStrip.Location = new System.Drawing.Point(0, 45);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(241, 25);
			this.toolStrip.TabIndex = 3;
			this.toolStrip.Text = "toolStrip1";
			// 
			// ConnectionView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Khaki;
			this.ClientSize = new System.Drawing.Size(241, 148);
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.toolStrip);
			this.HeaderText = "Simulator";
			this.MinimumSize = new System.Drawing.Size(150, 150);
			this.Name = "ConnectionView";
			this.TabText = "Simulator";
			this.Text = "Simulator";
			this.Controls.SetChildIndex(this.toolStrip, 0);
			this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.ToolStrip toolStrip;
		private ConnectionComboBox connectionComboBox1;
	}
}