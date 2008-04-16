using VicFireReader;
using VicFireReader.CFA.UI;
using NoeticTools.Windows.Forms;
using CFADataSet=VicFireReader.CFA.Data.CFADataSet;


namespace VicFireReader.CFA.Incidents.View
{
	partial class IncidentsView
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
			this.components = new System.ComponentModel.Container();
			this.cFADataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cFADataSet = new VicFireReader.CFA.Data.CFADataSet();
			this.incidentsGridViewPlaceHolder = new NoeticTools.Windows.Forms.PlaceHolderControl();
			((System.ComponentModel.ISupportInitialize)(this.cFADataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cFADataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// cFADataSetBindingSource
			// 
			this.cFADataSetBindingSource.DataMember = "Incidents";
			this.cFADataSetBindingSource.DataSource = this.cFADataSet;
			// 
			// cFADataSet
			// 
			this.cFADataSet.DataSetName = "CFADataSet";
			this.cFADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// incidentsGridViewPlaceHolder
			// 
			this.incidentsGridViewPlaceHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.incidentsGridViewPlaceHolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incidentsGridViewPlaceHolder.Location = new System.Drawing.Point(0, 45);
			this.incidentsGridViewPlaceHolder.Name = "incidentsGridViewPlaceHolder";
			this.incidentsGridViewPlaceHolder.Size = new System.Drawing.Size(840, 215);
			this.incidentsGridViewPlaceHolder.TabIndex = 3;
			// 
			// IncidentsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(840, 260);
			this.ControlBox = false;
			this.Controls.Add(this.incidentsGridViewPlaceHolder);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.HeaderText = "Incidents";
			this.MinimumSize = new System.Drawing.Size(600, 30);
			this.Name = "IncidentsView";
			this.TabText = "Incidents";
			this.Text = "Incidents";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IncidentsView_FormClosing);
			this.Load += new System.EventHandler(this.IncidentsView_Load);
			this.Controls.SetChildIndex(this.incidentsGridViewPlaceHolder, 0);
			((System.ComponentModel.ISupportInitialize)(this.cFADataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cFADataSet)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource cFADataSetBindingSource;
		private CFADataSet cFADataSet;
		private PlaceHolderControl incidentsGridViewPlaceHolder;
	}
}