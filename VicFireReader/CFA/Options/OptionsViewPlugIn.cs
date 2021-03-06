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
using System.Collections.Generic;
using System.Windows.Forms;
using NoeticTools.DotNetWrappers;
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Options;
using VicFireReader.Images;
using WeifenLuo.WinFormsUI.Docking;


namespace VicFireReader.CFA.Options
{
    public class OptionsViewPlugin : IPlugin, IOptionsView
    {
        private readonly List<IOptions> options = new List<IOptions>();
        private IPluginHostServices hostServices;
        private IToolStripMenuItem menuItem;
        private DockContent optionsView;

        void IOptionsView.AddProperties(IOptions optionProperties)
        {
            options.Add(optionProperties);
        }

        void IPlugin.Accept(IPluginHostServices services)
        {
            hostServices = services;

            menuItem = hostServices.MenuBar.AddMenuItem("&Tools|&Options");
            menuItem.Click += menuItem_Click;

            ImageResources imageResources = new ImageResources();

            hostServices.ToolStrip.AddButton("Options", imageResources.GetImage("PropertiesHS.png"),
                                             onOptionsButtonClick, "Options");
        }

        private void onOptionsButtonClick(object sender, EventArgs e)
        {
            ShowOptionsView();
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            ShowOptionsView();
        }

        private void ShowOptionsView()
        {
            if (optionsView == null)
            {
                OptionsView view = new OptionsView(options.ToArray(), new PropertyGrid());
                view.Closed += view_Closed;

                optionsView = view;
                hostServices.Show(optionsView, DockState.Document);
            }
            else
            {
                optionsView.Activate();
            }
        }

        private void view_Closed(object sender, EventArgs e)
        {
            optionsView = null;
        }
    }
}