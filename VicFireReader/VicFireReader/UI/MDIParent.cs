#region Copyright

/*---------------------------------------------------------------------------
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 * 
 * http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an "AS IS"
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
 * License for the specific language governing rights and limitations under 
 * the License.
 * 
 * The Initial Developer of the Original Code is Robert Smyth.
 * Portions created by Robert Smyth are Copyright (C) 2008.
 * 
 * All Rights Reserved.
 *---------------------------------------------------------------------------*/

#endregion //Copyright

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VicFireReader;
using WeifenLuo.WinFormsUI.Docking;
using NDependencyInjection;


namespace VicFireReader.UI
{
	public partial class MDIParent : Form
	{
		private readonly DockPanel dockPanel;
		private int childFormNumber = 0;

		public MDIParent()
		{
			InitializeComponent();
		}

		[InjectionConstructor]
		public MDIParent(DockPanel dockPanel, string title)
		{
			this.dockPanel = dockPanel;

			InitializeComponent();

			CreateDockPanel();
			Controls.Add(dockPanel);
			dockPanel.BringToFront();

			Text = title;
		}

		private void ShowNewForm(object sender, EventArgs e)
		{
			Form childForm = new Form();
			childForm.MdiParent = this;
			childForm.Text = "Window " + childFormNumber++;
			childForm.Show();
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			VicFireReaderApplication.Exit();
		}

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				childForm.Close();
			}
		}

		private void MDIParent_Load(object sender, EventArgs e)
		{
			dockPanel.DockLeftPortion = 0.3;
			dockPanel.DockBottomPortion = 0.50;
		}

		private void CreateDockPanel()
		{
			dockPanel.ActiveAutoHideContent = null;
			dockPanel.Dock = DockStyle.Fill;
			dockPanel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.World);
			dockPanel.Name = "dockPanel";
		}

		private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
		{
			string panelsConfigFile = GetPanelsConfigFilePath();
			dockPanel.SaveAsXml(panelsConfigFile);
		}

		private static string GetPanelsConfigFilePath()
		{
			string applicationFolder = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VicFireReader");
			if (!Directory.Exists(applicationFolder))
			{
				Directory.CreateDirectory(applicationFolder);
			}

			return Path.Combine(applicationFolder, "Panels.config");
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HelpAboutForm form = new HelpAboutForm();
			form.ShowDialog(this);
		}
	}
}