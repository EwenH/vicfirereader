using IncidentEditPanel=VicFireReader.Simulator.Incidents.IncidentEditPanel;


namespace VicFireReader.Simulator.Incidents
{
	partial class IncidentEditView
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
			this.incidentView = new IncidentEditPanel();
			this.SuspendLayout();
			// 
			// incidentView
			// 
			this.incidentView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incidentView.Location = new System.Drawing.Point(0, 45);
			this.incidentView.MinimumSize = new System.Drawing.Size(100, 260);
			this.incidentView.Name = "incidentView";
			this.incidentView.Size = new System.Drawing.Size(229, 284);
			this.incidentView.TabIndex = 2;
			// 
			// IncidentEditView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.Khaki;
			this.ClientSize = new System.Drawing.Size(229, 329);
			this.CloseButton = false;
			this.ControlBox = false;
			this.Controls.Add(this.incidentView);
			this.HeaderText = "Incidents Simulator";
			this.MinimumSize = new System.Drawing.Size(200, 200);
			this.Name = "IncidentEditView";
			this.TabText = "Incidents Simulator";
			this.Text = "Incidents Simulator";
			this.Controls.SetChildIndex(this.incidentView, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private IncidentEditPanel incidentView;

	}
}