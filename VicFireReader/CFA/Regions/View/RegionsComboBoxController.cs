#region Copyright

// The contents of this file are subject to the Mozilla Public License
//  Version 1.1 (the "License"); you may not use this file except in compliance
//  with the License. You may obtain a copy of the License at
//  
//  http://www.mozilla.org/MPL/
//  
//  Software distributed under the License is distributed on an "AS IS"
//  basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
//  License for the specific language governing rights and limitations under 
//  the License.
//  
//  The Initial Developer of the Original Code is Robert Smyth.
//  Portions created by Robert Smyth are Copyright (C) 2008.
//  
//  All Rights Reserved.

#endregion

using System;
using System.Windows.Forms;
using NoeticTools.DotNetWrappers.Windows.Forms;


namespace VicFireReader.CFA.Regions.View
{
    public class RegionsComboBoxController : IRegionsComboBoxController
    {
        private readonly ICfaRegions cfaRegions;
        private readonly IComboBox comboBox;

        public RegionsComboBoxController(IComboBox comboBox, ICfaRegions cfaRegions)
        {
            this.comboBox = comboBox;
            this.cfaRegions = cfaRegions;

            comboBox.MaxDropDownItems = 25;
            comboBox.Sorted = false;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DataSource = cfaRegions;
        }

        public void Start()
        {
            comboBox.SelectedItem = cfaRegions.SelectedRegion;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cfaRegions.SelectedRegion = comboBox.SelectedItem as ICfaRegion;
        }
    }
}