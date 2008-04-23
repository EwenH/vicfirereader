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

#endregion

using System;
using System.Windows.Forms;
using NDependencyInjection;


namespace VicFireReader.Simulator.Incidents
{
	public partial class IncidentEditPanel : UserControl
	{
		private readonly IIncidentEditPanelController controller;

		public IncidentEditPanel() : this(null)
		{
		}

		[InjectionConstructor]
		public IncidentEditPanel(IIncidentEditPanelController controller)
		{
			this.controller = controller;
			InitializeComponent();
		}

		private void nextToolStripButton_Click(object sender, System.EventArgs e)
		{
			controller.OnNextButtonClick();
		}

		public void SetGuid(string guid)
		{
			guidTextBox.Text = guid;
		}

		public void SetName(string name)
		{
			nameTextBox.Text = name;
		}

		public void SetLocation(string location)
		{
			locationTextBox.Text = location;
		}

		public void SetType(string type)
		{
			typeTextBox.Text = type;
		}

		public void SetStatus(string status)
		{
			statusTextBox.Text = status;
		}

		public void SetSize(string size)
		{
			sizeTextBox.Text = size;
		}

		public void SetPublicationTime(DateTime time)
		{
			pubDateDateTimePicker.Value = time;
		}

		public void SetUpdateTime(DateTime time)
		{
			updateDateTimePicker.Value = time;
		}

		public void SetRegion(short region)
		{
			regionNumericUpDown.Value = region;
		}

		public void SetVehicles(short appliances)
		{
			vehiclesNumericUpDown.Value = appliances;
		}

		private void IncidentEditPanel_Load(object sender, EventArgs e)
		{
			controller.Start();
		}
	}
}