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
using System.Drawing;
using System.Windows.Forms;
using NDependencyInjection;
using VicFireReader.Images;
using ToolStripButton=NoeticTools.DotNetWrappers.ToolStripButton;


namespace VicFireReader.Simulator.General
{
    public partial class TimeAdvanceToolStripButton : ToolStripButton, ITimeAdvanceToolStripButton
    {
        private readonly ISimulatedClock simulatedClock;

        public TimeAdvanceToolStripButton() : this(new ImageResources(), new SimulatedClock())
        {
        }

        [InjectionConstructor]
        public TimeAdvanceToolStripButton(IImageResources imageResources, ISimulatedClock simulatedClock)
            : base(new System.Windows.Forms.ToolStripButton())
        {
            this.simulatedClock = simulatedClock;
            InitializeComponent();
            Image = imageResources.GetImage("ExpirationHS.png");
            DisplayStyle = ToolStripItemDisplayStyle.Image;
            Visible = true;
            Enabled = true;
            Size = new Size(23, 22);
            ToolTipText = "Advance time by 30 seconds";

            Click += TimeAdvanceToolStripButton_Click;
        }

        private void TimeAdvanceToolStripButton_Click(object sender, EventArgs e)
        {
            simulatedClock.Advance(TimeSpan.FromSeconds(30));
        }
    }
}