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
using NDependencyInjection;


namespace VicFireReader.Simulator.General
{
    public partial class ConnectionComboBox : ComboBox, IConnectionComboBox
    {
        private readonly ISimulatedConnection simulatedConnection;

        public ConnectionComboBox() : this(new SimulatedConnection())
        {
        }

        [InjectionConstructor]
        public ConnectionComboBox(ISimulatedConnection simulatedConnection)
        {
            this.simulatedConnection = simulatedConnection;
            InitializeComponent();

            Items.Clear();
            Items.Add("Online");
            Items.Add("Offline");

            SelectedIndex = 0;
            SelectedIndexChanged += ConnectionComboBox_SelectedIndexChanged;
        }

        private void ConnectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            simulatedConnection.SetOnline((SelectedItem as string) == "Online");
        }
    }
}