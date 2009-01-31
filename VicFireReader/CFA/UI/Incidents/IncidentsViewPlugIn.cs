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
using NoeticTools.DotNetWrappers;
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Persistence;


namespace VicFireReader.CFA.UI.Incidents
{
    public class IncidentsViewPlugIn : IPlugin, IOnOpenListener
    {
        private readonly IIncidentsViewFactory factory;
        private IncidentsViewPlugInConfig config;
        private IPluginHostServices hostServices;
        private int nextIncidentsViewID;

        public IncidentsViewPlugIn(IIncidentsViewFactory factory)
        {
            this.factory = factory;
        }

        void IOnOpenListener.OnOpen(IPluginHostServices services)
        {
            hostServices = services;

            IPersistenceService persistenceService = hostServices.GetService<IPersistenceService>();

            config = persistenceService.RegisterScope("IncidentsViewPlugIn", UpdateConfig,
                                                      new IncidentsViewPlugInConfig());

            IToolStripMenuItem menuItem = hostServices.MenuBar.AddMenuItem("&Incidents|Add &View");
            menuItem.Click += addIncidentsViewMenuItem_Click;

            NewIncidentsView();
        }

        void IOnOpenListener.OnClosing()
        {
        }

        void IPlugin.Accept(IPluginHostServices services)
        {
            hostServices = services;
            hostServices.AddOnOpenListener(this);
        }

        private void addIncidentsViewMenuItem_Click(object sender, EventArgs e)
        {
            NewIncidentsView();
        }

        private void NewIncidentsView()
        {
            IIncidentsViewController controller = factory.Create(hostServices, ++nextIncidentsViewID);
            controller.Show(hostServices);
        }

        private object UpdateConfig()
        {
            return config;
        }
    }
}