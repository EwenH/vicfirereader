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

using System.Windows.Forms;
using VicFireReader.CFA.UI;
using NoeticTools.DotNetWrappers;


namespace VicFireReader.CFA.Regions
{
	public class ToolBarRegionSelectionController : IToolBarRegionSelectionController
	{
		private readonly IToolStripComboBox comboBox;
		private readonly ICfaRegions regions;

		public ToolBarRegionSelectionController(IToolStripComboBox comboBox, ICfaRegions regions)
		{
			this.comboBox = comboBox;
			this.regions = regions;

			comboBox.MaxDropDownItems = 25;
			comboBox.Sorted = false;
			comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox.ComboBox.DataSource = regions;

			comboBox.SelectedItem = regions.SelectedRegion;
			comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
		}

		void comboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			regions.SelectedRegion = comboBox.SelectedItem as ICfaRegion;
		}
	}
}