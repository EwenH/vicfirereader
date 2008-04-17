using IncidentEditPanel=VicFireReader.Simulator.Incidents.IIncidentEditPanel;


namespace VicFireReader.Simulator.Incidents
{
	partial class IncidentEditView : IIncidentEditView
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
			this.SuspendLayout();
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
			this.HeaderText = "Incidents Simulator";
			this.MinimumSize = new System.Drawing.Size(200, 200);
			this.Name = "IncidentEditView";
			this.TabText = "Incidents Simulator";
			this.Text = "Incidents Simulator";
			this.ResumeLayout(false);

		}

		#endregion


	}
}